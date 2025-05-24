# Hướng Dẫn Sử Dụng Kafka Trong Project

## 1. Cấu Trúc Kafka Dockerfile
```dockerfile
FROM bitnami/kafka:latest

ENV KAFKA_CFG_NODE_ID=1
ENV KAFKA_CFG_PROCESS_ROLES=broker,controller
ENV KAFKA_CFG_CONTROLLER_QUORUM_VOTERS=1@kafka:9093
ENV KAFKA_CFG_LISTENERS=PLAINTEXT://:9092,CONTROLLER://:9093,PLAINTEXT_HOST://:29092
ENV KAFKA_CFG_ADVERTISED_LISTENERS=PLAINTEXT://kafka:9092,PLAINTEXT_HOST://localhost:29092
ENV KAFKA_CFG_LISTENER_SECURITY_PROTOCOL_MAP=CONTROLLER:PLAINTEXT,PLAINTEXT:PLAINTEXT,PLAINTEXT_HOST:PLAINTEXT
ENV KAFKA_CFG_CONTROLLER_LISTENER_NAMES=CONTROLLER
ENV KAFKA_CFG_INTER_BROKER_LISTENER_NAME=PLAINTEXT
ENV ALLOW_PLAINTEXT_LISTENER=yes

EXPOSE 9092 29092
```

## 2. Chạy Kafka

### 2.1. Build và Chạy Kafka Container
```bash
# Build Kafka image từ Dockerfile
docker build -t kafka -f kafka/Dockerfile .

# Tạo network (nếu chưa có)
docker network create dotnet-network

# Chạy Kafka container
docker run -d --name kafka \
  --network dotnet-network \
  -p 9092:9092 -p 29092:29092 \
  kafka
```

### 2.2. Kiểm Tra Kafka Đang Chạy
```bash
# Kiểm tra container status
docker ps | grep kafka

# Kiểm tra logs
docker logs kafka
```

## 3. Quản Lý Topics

### 3.1. Tạo Topics
```bash
# Vào container Kafka
docker exec -it kafka /bin/bash

# Tạo topic user-registered cho Authentication và Email Service
kafka-topics.sh --create \
  --bootstrap-server localhost:9092 \
  --topic user-registered \
  --partitions 3 \
  --replication-factor 1
```

### 3.2. Kiểm Tra Topics
```bash
# Liệt kê tất cả topics
kafka-topics.sh --list --bootstrap-server localhost:9092

# Xem chi tiết topic
kafka-topics.sh --describe \
  --bootstrap-server localhost:9092 \
  --topic user-registered
```

### 3.3. Gửi và Nhận Messages

#### Gửi Message
```bash
# Vào Kafka console producer
kafka-console-producer.sh \
  --bootstrap-server localhost:9092 \
  --topic user-registered

# Nhập message (mỗi dòng là một message)
{"userId": "123", "event": "registered", "timestamp": "2024-03-20T10:00:00Z"}
{"userId": "124", "event": "registered", "timestamp": "2024-03-20T10:01:00Z"}
```

#### Nhận Message
```bash
# Vào Kafka console consumer
kafka-console-consumer.sh \
  --bootstrap-server localhost:9092 \
  --topic user-registered \
  --from-beginning

# Consumer với group
kafka-console-consumer.sh \
  --bootstrap-server localhost:9092 \
  --topic user-registered \
  --group auth-service-group \
  --from-beginning
```

## 4. Cấu Hình Trong Ứng Dụng

### 4.1. Cấu Hình Kafka trong appsettings.json
```json
{
  "Kafka": {
    "BootstrapServers": "kafka:9092",
    "GroupId": "auth-service-group",
    "Topics": {
      "UserRegistered": "user-registered"
    }
  }
}
```

### 4.2. Chạy Service với Kafka
```bash
# Chạy Authentication Service
docker run -d --name auth-service \
  --network dotnet-network \
  -p 8080:80 \
  -e ASPNETCORE_ENVIRONMENT=Development \
  -e KAFKA__BOOTSTRAPSERVERS=kafka:9092 \
  auth-service

# Chạy Email Service
docker run -d --name email-service \
  --network dotnet-network \
  -p 8081:80 \
  -e ASPNETCORE_ENVIRONMENT=Development \
  -e KAFKA__BOOTSTRAPSERVERS=kafka:9092 \
  email-service
```

## 5. Troubleshooting

### 5.1. Kiểm Tra Kết Nối
```bash
# Kiểm tra Kafka đang chạy
docker exec kafka kafka-topics.sh --bootstrap-server localhost:9092 --list

# Kiểm tra consumer groups
docker exec kafka kafka-consumer-groups.sh \
  --bootstrap-server localhost:9092 \
  --list
```

### 5.2. Các Lỗi Thường Gặp

1. **Connection Refused:**
   ```
   Connection refused (after 0ms in state CONNECT)
   ```
   **Cách khắc phục:**
   - Kiểm tra container trong cùng network
   - Kiểm tra Kafka đang chạy
   - Kiểm tra port mapping

2. **Topic Not Found:**
   ```
   Topic 'user-registered' not found
   ```
   **Cách khắc phục:**
   - Kiểm tra topic đã được tạo
   - Kiểm tra quyền truy cập
   - Kiểm tra bootstrap servers

3. **Consumer Group Issues:**
   ```
   Consumer group 'auth-service-group' not found
   ```
   **Cách khắc phục:**
   - Kiểm tra group ID trong cấu hình
   - Kiểm tra consumer đã subscribe
   - Kiểm tra consumer health

## 6. Best Practices

1. **Topic Naming:**
   - Sử dụng dấu gạch ngang (-)
   - Thêm prefix cho môi trường (dev-, prod-)
   - Đặt tên có ý nghĩa

2. **Partitioning:**
   - Số partitions = số consumers
   - Không quá nhiều partitions
   - Cân nhắc throughput

3. **Monitoring:**
   - Theo dõi consumer lag
   - Kiểm tra disk usage
   - Monitor broker health

4. **Security:**
   - Sử dụng network riêng
   - Kiểm soát quyền truy cập
   - Không expose port không cần thiết 