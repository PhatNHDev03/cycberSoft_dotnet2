# Hướng Dẫn Cài Đặt Docker Cho Microservices

## Mục Lục
1. [Cấu Trúc Dockerfile Cho Từng Service](#cấu-trúc-dockerfile-cho-từng-service)
2. [Cài Đặt Kafka](#cài-đặt-kafka)
3. [Cài Đặt Kafka UI](#cài-đặt-kafka-ui)
4. [Cấu Hình Docker Network](#cấu-hình-docker-network)
5. [Các Lỗi Thường Gặp Và Cách Khắc Phục](#các-lỗi-thường-gặp-và-cách-khắc-phục)

## Cấu Trúc Dockerfile Cho Từng Service

### 1. AuthenticationService Dockerfile
```dockerfile
# Sử dụng .NET SDK để build ứng dụng
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project file và restore dependencies
COPY [AuthenticationService/AuthenticationService.csproj, AuthenticationService/]
RUN dotnet restore "AuthenticationService/AuthenticationService.csproj"

# Copy toàn bộ source code
COPY . .
WORKDIR /src/AuthenticationService

# Build và publish ứng dụng
RUN dotnet build "AuthenticationService.csproj" -c Release -o /app/build
RUN dotnet publish "AuthenticationService.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Sử dụng runtime image nhẹ hơn
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

# Copy các file đã publish từ build stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
```

**Giải thích từng bước:**
1. `FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build`: Sử dụng .NET SDK image để build ứng dụng
2. `WORKDIR /src`: Tạo và chuyển đến thư mục làm việc
3. `COPY [AuthenticationService/AuthenticationService.csproj, AuthenticationService/]`: Copy file project để restore dependencies
4. `RUN dotnet restore`: Khôi phục các package dependencies
5. `COPY . .`: Copy toàn bộ source code vào container
6. `RUN dotnet build`: Build ứng dụng
7. `RUN dotnet publish`: Publish ứng dụng với cấu hình Release
8. `FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base`: Sử dụng runtime image nhẹ hơn
9. `COPY --from=publish /app/publish .`: Copy các file đã publish vào runtime image

### 2. EmailService Dockerfile
```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY [EmailService/EmailService.csproj, EmailService/]
RUN dotnet restore "EmailService/EmailService.csproj"

COPY . .
WORKDIR /src/EmailService

RUN dotnet build "EmailService.csproj" -c Release -o /app/build
RUN dotnet publish "EmailService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
```

Cấu trúc tương tự như AuthenticationService, chỉ khác tên service.

### 3. GatewayAPI Dockerfile
```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY [GatewayAPI/GatewayAPI.csproj, GatewayAPI/]
RUN dotnet restore "GatewayAPI/GatewayAPI.csproj"

COPY . .
WORKDIR /src/GatewayAPI

RUN dotnet build "GatewayAPI.csproj" -c Release -o /app/build
RUN dotnet publish "GatewayAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
```

## Cài Đặt Kafka

### 1. Kafka Dockerfile
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

**Giải thích các biến môi trường:**
1. `KAFKA_CFG_NODE_ID`: ID của node Kafka
2. `KAFKA_CFG_PROCESS_ROLES`: Vai trò của node (broker và controller)
3. `KAFKA_CFG_LISTENERS`: Các cổng lắng nghe
   - `PLAINTEXT://:9092`: Cho kết nối nội bộ trong Docker network
   - `CONTROLLER://:9093`: Cho kết nối controller
   - `PLAINTEXT_HOST://:29092`: Cho kết nối từ máy host
4. `KAFKA_CFG_ADVERTISED_LISTENERS`: Địa chỉ được quảng cáo cho clients
   - `PLAINTEXT://kafka:9092`: Cho các service trong Docker network
   - `PLAINTEXT_HOST://localhost:29092`: Cho kết nối từ máy host

## Cài Đặt Kafka UI

### 1. Kafka UI Dockerfile
```dockerfile
FROM provectuslabs/kafka-ui:latest

ENV KAFKA_CLUSTERS_0_NAME=local
ENV KAFKA_CLUSTERS_0_BOOTSTRAPSERVERS=kafka:9092
ENV KAFKA_CLUSTERS_0_ZOOKEEPER=zookeeper:2181

EXPOSE 8080
```

**Giải thích:**
1. Sử dụng image `provectuslabs/kafka-ui` - một công cụ quản lý Kafka với giao diện web
2. Cấu hình kết nối tới Kafka broker thông qua hostname `kafka:9092`
3. Expose port 8080 cho web interface

## Cấu Hình Docker Network

### 1. Tạo Network
```bash
docker network create dotnet-network
```

### 2. Tại Sao Kafka Cần Network Riêng?

#### 2.1 Vấn Đề Với Network Default
- Network default của Docker là một bridge network đơn giản
- Trong network default, các container có thể giao tiếp với nhau thông qua IP động
- IP của container có thể thay đổi mỗi khi container restart
- Kafka cần một hostname cố định để các service khác có thể kết nối tới

#### 2.2 Lý Do Cần Network Riêng Cho Kafka

1. **DNS Resolution:**
   - Trong network riêng, Docker cung cấp DNS resolution tự động
   - Các container có thể giao tiếp với nhau thông qua hostname (ví dụ: `kafka:9092`)
   - Hostname này sẽ không thay đổi ngay cả khi container restart

2. **Cấu Hình Advertised Listeners:**
   - Kafka sử dụng `advertised.listeners` để quảng cáo địa chỉ kết nối
   - Trong network riêng, chúng ta có thể cấu hình:
     ```properties
     PLAINTEXT://kafka:9092  # Cho các service trong network
     PLAINTEXT_HOST://localhost:29092  # Cho kết nối từ máy host
     ```
   - Nếu dùng network default, hostname `kafka` sẽ không được resolve

3. **Bảo Mật:**
   - Network riêng giúp cô lập Kafka và các service liên quan
   - Chỉ các container trong cùng network mới có thể kết nối tới Kafka
   - Giảm rủi ro bảo mật từ các container không liên quan

#### 2.3 Lỗi Khi Dùng Network Default

1. **Connection Refused:**
   ```
   Connection refused (after 0ms in state CONNECT)
   ```
   - Các service không thể resolve hostname `kafka`
   - Không thể kết nối tới Kafka broker

2. **Broker Not Available:**
   ```
   Broker may not be available
   ```
   - Kafka broker không thể quảng cáo địa chỉ của mình đúng cách
   - Các client không biết phải kết nối tới đâu

#### 2.4 Lợi Ích Của Network Riêng

1. **Ổn Định:**
   - Hostname cố định, không phụ thuộc vào IP động
   - Không bị ảnh hưởng khi container restart

2. **Dễ Cấu Hình:**
   - Các service có thể kết nối thông qua hostname
   - Không cần biết IP của container

3. **Bảo Mật:**
   - Cô lập traffic giữa các service
   - Kiểm soát được quyền truy cập

4. **Quản Lý:**
   - Dễ dàng quản lý và debug các kết nối
   - Có thể xem logs và monitor traffic

5. **Khả Năng Mở Rộng:**
   - Dễ dàng thêm service mới vào network
   - Không cần thay đổi cấu hình khi thêm service

### 3. Ví Dụ Cấu Hình Đúng

```bash
# Tạo network riêng
docker network create dotnet-network

# Chạy Kafka trong network riêng
docker run -d --name kafka \
  --network dotnet-network \
  -p 9092:9092 -p 29092:29092 \
  -e KAFKA_CFG_ADVERTISED_LISTENERS=PLAINTEXT://kafka:9092,PLAINTEXT_HOST://localhost:29092 \
  kafka

# Chạy service trong cùng network
docker run -d --name auth-service \
  --network dotnet-network \
  -e KAFKA__BOOTSTRAPSERVERS=kafka:9092 \
  auth-service
```

## Các Lỗi Thường Gặp Và Cách Khắc Phục

### 1. Lỗi Kafka Connection
```
Connection refused (after 0ms in state CONNECT)
```
**Nguyên nhân:**
- Container không trong cùng network
- Sai port hoặc hostname
- Kafka chưa sẵn sàng khi service khởi động

**Cách khắc phục:**
- Đảm bảo tất cả container trong cùng network
- Kiểm tra cấu hình Kafka trong appsettings.json
- Thêm retry logic trong service

### 2. Lỗi Port Conflict
```
Bind for 0.0.0.0:8082 failed: port is already allocated
```
**Cách khắc phục:**
- Kiểm tra và dừng container đang sử dụng port
- Hoặc sử dụng port khác

### 3. Lỗi Swagger Không Hiển Thị
**Nguyên nhân:**
- Swagger chỉ được bật trong môi trường Development
- Container đang chạy ở môi trường Production

**Cách khắc phục:**
```bash
docker run -d --name service-name --network dotnet-network -p port:80 -e ASPNETCORE_ENVIRONMENT=Development service-image
```

### 4. Lỗi Kafka UI Không Kết Nối Được
**Nguyên nhân:**
- Sai cấu hình bootstrap servers
- Network không đúng

**Cách khắc phục:**
- Kiểm tra biến môi trường KAFKA_CLUSTERS_0_BOOTSTRAPSERVERS
- Đảm bảo Kafka UI trong cùng network với Kafka 