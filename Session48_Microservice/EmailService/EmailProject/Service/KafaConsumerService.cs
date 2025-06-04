using System.Text.Json;
using Confluent.Kafka;

namespace EmailProject.Service
{
    // ví nó là hứng , chờ đợi 1 message gửi tới nên nó kế thừa background service --> message nòa tới xử lí trả về
    public class KafaConsumerService : BackgroundService
    {
        private readonly IConsumer<string, string> _consumer;
        private readonly IEmailservice _emailService;
        private const string Topic = "user-registered";


        public KafaConsumerService(IEmailservice emailService)
        {
            //config consumer
            var config = new ConsumerConfig
            {
                BootstrapServers = "kafka:9092",
                GroupId = "email-service", //consumer group
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _consumer = new ConsumerBuilder<string, string>(config).Build();
            _emailService = emailService;
        }

        // phải truyền đúng nha
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //subcribe topic --> để luôn được nhận  cái mới giống như youtube
            _consumer.Subscribe(Topic);
            Console.WriteLine($"Consumer started subcribe topic {Topic}");
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumerResult = _consumer.Consume(stoppingToken);
                    // chuyển dạng json sang dạng object
                    var message = JsonSerializer.Deserialize<UserRegistered>(consumerResult.Value);
                    if (message != null)
                    {
                        await _emailService.SendWellcomeEmailAsync(message.Email, message.Username);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error message: {ex.Message}");
                }
                ;
            }
        }
        public override void Dispose()
        {
            _consumer?.Dispose();
            base.Dispose();
        }
    }

    public class UserRegistered
    {

        public required string Email { get; set; }
        public required string Username { get; set; }
        public DateTime timestamp { get; set; }
    }

}