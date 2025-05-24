# Lý Thuyết Về Apache Kafka

## 1. Các Khái Niệm Cơ Bản

### 1.1. Broker
- **Định nghĩa**: Broker là một server Kafka, nơi lưu trữ và quản lý các topic
- **Vai trò**:
  - Lưu trữ dữ liệu
  - Xử lý các request từ producer và consumer
  - Quản lý partition và replication
- **Trong source code hiện tại**:
  ```csharp
  var config = new ProducerConfig
  {
      BootstrapServers = "localhost:9092"  // Địa chỉ của broker
  };
  ```

### 1.2. Topic
- **Định nghĩa**: Topic là một luồng dữ liệu có tên, nơi producer gửi message và consumer đọc message
- **Đặc điểm**:
  - Có thể có nhiều partition
  - Dữ liệu được lưu trữ theo thứ tự
  - Có thể có nhiều consumer đọc cùng một topic
- **Trong source code hiện tại**:
  ```csharp
  private const string Topic = "user-registered";  // Topic cho sự kiện đăng ký user
  ```

### 1.3. Partition
- **Định nghĩa**: Partition là một phần của topic, cho phép topic có thể mở rộng
- **Đặc điểm**:
  - Mỗi partition là một chuỗi message có thứ tự
  - Có thể chạy song song trên nhiều broker
  - Tăng hiệu suất đọc/ghi
- **Khi nào sử dụng nhiều partition**:
  - Khi cần xử lý song song
  - Khi cần tăng throughput
  - Khi có nhiều consumer trong cùng một group

### 1.4. Consumer Group
- **Định nghĩa**: Một nhóm các consumer cùng đọc một topic
- **Đặc điểm**:
  - Mỗi partition chỉ được đọc bởi một consumer trong group
  - Các consumer trong group chia sẻ việc đọc dữ liệu
  - Mỗi consumer group có offset riêng
- **Trong source code hiện tại**:
  ```csharp
  var config = new ConsumerConfig
  {
      GroupId = "email-service-group",  // ID của consumer group
      AutoOffsetReset = AutoOffsetReset.Earliest
  };
  ```

## 2. Cách Tạo và Quản Lý Topic

### 2.1. Tạo Topic
```bash
# Tạo topic với 1 partition và replication factor là 1
kafka-topics.sh --create \
    --topic user-registered \
    --bootstrap-server localhost:9092 \
    --partitions 1 \
    --replication-factor 1
```

### 2.2. Các Tham Số Quan Trọng
- **partitions**: Số lượng partition (ảnh hưởng đến khả năng mở rộng)
- **replication-factor**: Số bản sao của dữ liệu (ảnh hưởng đến độ tin cậy)
- **retention.ms**: Thời gian lưu trữ message
- **cleanup.policy**: Chính sách dọn dẹp dữ liệu cũ

## 3. Các Pattern Sử Dụng Kafka

### 3.1. Message Queue
- **Mục đích**: Giao tiếp bất đồng bộ giữa các service
- **Ví dụ trong code hiện tại**:
  - AuthenticationService gửi event đăng ký
  - EmailService nhận và xử lý event

### 3.2. Event Sourcing
- **Mục đích**: Lưu trữ lịch sử thay đổi
- **Cách áp dụng**:
  - Lưu mọi thay đổi dưới dạng event
  - Có thể replay lại các event

### 3.3. Log Aggregation
- **Mục đích**: Tập trung log từ nhiều service
- **Cách áp dụng**:
  - Các service gửi log đến Kafka
  - Hệ thống log tập trung đọc và xử lý

## 4. Best Practices

### 4.1. Producer
- Sử dụng key để đảm bảo thứ tự message
- Xử lý lỗi và retry
- Sử dụng transaction khi cần

### 4.2. Consumer
- Xử lý message theo batch
- Commit offset đúng cách
- Xử lý lỗi và dead letter queue

### 4.3. Topic Design
- Đặt tên topic rõ ràng
- Chọn số partition phù hợp
- Cấu hình retention policy

## 5. Monitoring và Maintenance

### 5.1. Metrics Quan Trọng
- Lag của consumer
- Throughput của topic
- Số lượng message trong topic

### 5.2. Công Cụ Quản Lý
- Kafka Manager
- Conduktor
- Kafka Tool

## 6. Áp Dụng Vào Source Code Hiện Tại

### 6.1. Cải Thiện Producer
```csharp
public async Task PublishUserRegisteredEvent(string email, string username)
{
    try
    {
        var message = new
        {
            Email = email,
            Username = username,
            Timestamp = DateTime.UtcNow
        };

        var jsonMessage = JsonSerializer.Serialize(message);
        
        // Thêm retry logic
        var retryCount = 3;
        while (retryCount > 0)
        {
            try
            {
                await _producer.ProduceAsync(Topic, new Message<string, string>
                {
                    Key = email,
                    Value = jsonMessage
                });
                break;
            }
            catch (Exception ex)
            {
                retryCount--;
                if (retryCount == 0) throw;
                await Task.Delay(1000); // Đợi 1 giây trước khi retry
            }
        }
    }
    catch (Exception ex)
    {
        // Log lỗi
        throw;
    }
}
```

### 6.2. Cải Thiện Consumer
```csharp
protected override async Task ExecuteAsync(CancellationToken stoppingToken)
{
    _consumer.Subscribe(Topic);

    while (!stoppingToken.IsCancellationRequested)
    {
        try
        {
            var consumeResult = _consumer.Consume(stoppingToken);
            
            // Xử lý message theo batch
            var messages = new List<ConsumeResult<string, string>>();
            messages.Add(consumeResult);
            
            // Thử lấy thêm message nếu có
            while (messages.Count < 100) // Batch size = 100
            {
                var nextMessage = _consumer.Consume(TimeSpan.FromMilliseconds(100));
                if (nextMessage == null) break;
                messages.Add(nextMessage);
            }

            // Xử lý batch
            foreach (var message in messages)
            {
                try
                {
                    var userEvent = JsonSerializer.Deserialize<UserRegisteredEvent>(message.Message.Value);
                    if (userEvent != null)
                    {
                        await _emailService.SendWelcomeEmail(userEvent.Email, userEvent.Username);
                    }
                }
                catch (Exception ex)
                {
                    // Log lỗi và gửi đến dead letter queue
                    await SendToDeadLetterQueue(message);
                }
            }

            // Commit offset sau khi xử lý thành công
            _consumer.Commit();
        }
        catch (Exception ex)
        {
            // Log lỗi
            await Task.Delay(1000); // Đợi 1 giây trước khi thử lại
        }
    }
}
``` 