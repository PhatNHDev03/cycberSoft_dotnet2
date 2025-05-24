# Hướng Dẫn Setup GatewayService (YARP) Cho Microservice

## 1. Tạo Project GatewayService
```bash
dotnet new webapi -n GatewayService
cd GatewayService
```

## 2. Thêm Package YARP
```bash
dotnet add package Yarp.ReverseProxy
```

## 3. Thêm Package Swagger (tùy chọn, để test nội bộ)
```bash
dotnet add package Swashbuckle.AspNetCore
```

## 4. Cấu Hình Program.cs
```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.MapReverseProxy();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
```

## 5. Cấu Hình appsettings.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ReverseProxy": {
    "Routes": {
      "auth-route": {
        "ClusterId": "auth-cluster",
        "Match": {
          "Path": "/api/auth/{**catch-all}"
        }
      },
      "email-route": {
        "ClusterId": "email-cluster",
        "Match": {
          "Path": "/api/email/{**catch-all}"
        }
      }
    },
    "Clusters": {
      "auth-cluster": {
        "Destinations": {
          "auth-destination": {
            "Address": "http://localhost:5001"
          }
        }
      },
      "email-cluster": {
        "Destinations": {
          "email-destination": {
            "Address": "http://localhost:5002"
          }
        }
      }
    }
  }
}
```

## 6. Cấu Hình launchSettings.json (nếu muốn chạy port 5000)
```json
{
  "profiles": {
    "http": {
      "applicationUrl": "http://localhost:5000"
    },
    "https": {
      "applicationUrl": "https://localhost:44300;http://localhost:5000"
    }
  }
}
```

## 7. Chạy Các Service
```bash
# Terminal 1
cd AuthenticationService
 dotnet run --urls="http://localhost:5001"

# Terminal 2
cd EmailService
 dotnet run --urls="http://localhost:5002"

# Terminal 3
cd GatewayService
 dotnet run
```

## 8. Test API Qua Gateway
### Đăng ký user
```bash
curl -X POST http://localhost:5000/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "email": "test@example.com",
    "password": "Test123!",
    "firstName": "Test",
    "lastName": "User"
  }'
```

### Gửi email
```bash
curl -X POST http://localhost:5000/api/email/send \
  -H "Content-Type: application/json" \
  -d '{
    "to": "test@example.com",
    "subject": "Test Email",
    "body": "This is a test email"
  }'
```

## 9. Lưu Ý
- Swagger UI của Gateway chỉ hiển thị các controller nội bộ (nếu có).
- Để test API thực tế, hãy dùng curl hoặc Postman gọi qua Gateway.
- Đảm bảo các service phía sau (auth, email) đang chạy đúng port.
- Có thể mở rộng cấu hình route/cluster cho các service khác. 