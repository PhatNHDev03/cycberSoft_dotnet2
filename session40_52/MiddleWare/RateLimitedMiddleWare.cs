using System.Net;
using Microsoft.Extensions.Options;
using session40_52.Models;
using StackExchange.Redis;

namespace session40_52.MiddleWare
{
    public class RateLimitedMiddleWare
    {
        private readonly RequestDelegate _next;
        public readonly RateLimitSettings _settings;
        public readonly IConnectionMultiplexer _redis;
        public RateLimitedMiddleWare(RequestDelegate next, IOptions<RateLimitSettings> settings, IConnectionMultiplexer redis)
        {
            _next = next;
            _settings = settings.Value;
            _redis = redis;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!_settings.Enabled)
            {
                await _next(context);
                return;
            }

            // Lấy IP của client
            var clientIp = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var db = _redis.GetDatabase(); // ket toi redis

            // Tạo key cho IP này
            var key = $"ratelimit:ip:{clientIp}"; // luu theo dang key va value

            // Tăng số lượng request và lấy giá trị mới
            var requestCount = await db.StringIncrementAsync(key);

            // Nếu đây là request đầu tiên, set thời gian hết hạn
            if (requestCount == 1)
            {
                await db.KeyExpireAsync(key, TimeSpan.FromSeconds(_settings.Window));
            }

            // Kiểm tra có vượt quá giới hạn không
            if (requestCount > _settings.MaxRequests)
            {
                context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                context.Response.Headers["Retry-After"] = _settings.Window.ToString();
                await context.Response.WriteAsJsonAsync(new
                {
                    error = "Too many requests",
                    message = "Rate limit exceeded. Please try again later.",
                    retryAfter = _settings.Window
                });
                return;
            }

            // Nếu không vượt quá giới hạn, tiếp tục xử lý request
            await _next(context);
        }

    }
}