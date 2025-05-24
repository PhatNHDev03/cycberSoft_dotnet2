# Hướng Dẫn Tạo và Quản Lý Topic trong Kafka

## 1. Lệnh Tạo Topic

### 1.1. Cú Pháp Đầy Đủ
```bash
docker exec -it session48_microservice_kafka_1 kafka-topics.sh --create --topic user-registered --bootstrap-server localhost:9092 --partitions 1 --replication-factor 1
```

### 1.2. Giải Thích Chi Tiết

#### 1.2.1. Phần Docker
```bash
docker exec -it session48_microservice_kafka_1
```
- `docker exec`: Lệnh để thực thi một lệnh trong container đang chạy
- `-it`: 
  - `-i`: Giữ STDIN mở
  - `-t`: Phân bổ một pseudo-TTY (terminal)
- `session48_microservice_kafka_1`: Tên của container Kafka

#### 1.2.2. Phần Kafka Topics
```bash
kafka-topics.sh --create
```
- `kafka-topics.sh`: Script quản lý topic trong Kafka
  - Script này có sẵn trong container Kafka tại `/opt/kafka/bin/kafka-topics.sh`
  - Là một phần của Kafka distribution, được cài đặt tự động khi chạy container
  - Có thể xem danh sách các script khác bằng lệnh: `docker exec -it session48_microservice_kafka_1 ls /opt/kafka/bin/`
  - Các script phổ biến khác:
    - `kafka-console-producer.sh`: Tạo message từ command line
    - `kafka-console-consumer.sh`: Đọc message từ command line
    - `kafka-configs.sh`: Quản lý cấu hình
    - `kafka-server-start.sh`: Khởi động Kafka server
- `--create`: Lệnh tạo topic mới

#### 1.2.3. Các Tham Số
```bash
--topic user-registered
```
- Tên của topic cần tạo
- Trong trường hợp này là "user-registered"
- Topic này sẽ được sử dụng để gửi thông tin đăng ký user

```bash
--bootstrap-server localhost:9092
```
- Địa chỉ của Kafka broker
- `localhost:9092`: Địa chỉ và port của broker
- Broker này sẽ quản lý topic được tạo

```bash
--partitions 1
```
- Số lượng partition của topic
- Partition = 1 nghĩa là topic chỉ có một partition
- Mỗi partition là một chuỗi message có thứ tự
- Trong môi trường production, thường dùng nhiều partition hơn để tăng throughput

```bash
--replication-factor 1
```
- Số lượng bản sao của dữ liệu
- Replication-factor = 1 nghĩa là dữ liệu chỉ được lưu một bản
- Trong môi trường production, thường dùng replication-factor > 1 để đảm bảo tính sẵn sàng

## 2. Các Lệnh Quản Lý Topic Khác

### 2.1. Liệt Kê Topic
```bash
docker exec -it session48_microservice_kafka_1 kafka-topics.sh --list --bootstrap-server localhost:9092
```
- Hiển thị danh sách tất cả các topic trong Kafka cluster

### 2.2. Xem Thông Tin Chi Tiết Topic
```bash
docker exec -it session48_microservice_kafka_1 kafka-topics.sh --describe --topic user-registered --bootstrap-server localhost:9092
```
- Hiển thị thông tin chi tiết về topic:
  - Số partition
  - Replication factor
  - Leader partition
  - ISR (In-Sync Replicas)

### 2.3. Xóa Topic
```bash
docker exec -it session48_microservice_kafka_1 kafka-topics.sh --delete --topic user-registered --bootstrap-server localhost:9092
```
- Xóa topic và tất cả dữ liệu của nó

## 3. Lưu Ý Quan Trọng

### 3.1. Môi Trường Development
- Cấu hình hiện tại (1 partition, 1 replication) là phù hợp
- Đơn giản và dễ quản lý
- Phù hợp cho việc phát triển và test

### 3.2. Môi Trường Production
- Nên tăng số partition nếu cần xử lý song song
- Nên tăng replication-factor để đảm bảo tính sẵn sàng
- Ví dụ cấu hình production:
  ```bash
  docker exec -it session48_microservice_kafka_1 kafka-topics.sh --create \
      --topic user-registered \
      --bootstrap-server localhost:9092 \
      --partitions 3 \
      --replication-factor 2
  ```

### 3.3. Các Tham Số Khác
- `--config`: Cấu hình thêm cho topic
- `--if-not-exists`: Chỉ tạo nếu topic chưa tồn tại
- `--if-exists`: Chỉ thực hiện nếu topic đã tồn tại

## 4. Best Practices

### 4.1. Đặt Tên Topic
- Sử dụng tên có ý nghĩa
- Tuân theo quy ước đặt tên
- Ví dụ: `user-registered`, `order-created`, `payment-processed`

### 4.2. Số Lượng Partition
- Số partition nên là bội số của số broker
- Ước tính dựa trên throughput cần thiết
- Cân nhắc số lượng consumer trong group

### 4.3. Replication Factor
- Tối thiểu là 2 trong môi trường production
- Không nên lớn hơn số lượng broker
- Cân nhắc giữa độ tin cậy và chi phí lưu trữ 