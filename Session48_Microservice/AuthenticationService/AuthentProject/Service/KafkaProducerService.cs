using System.Text.Json;
using Confluent.Kafka;

namespace AuthentProject.Service
{
    public class KafkaProducerService
    {
        private readonly IProducer<string, string> _producer;
        private const string Topic = "user-registered"; // giống với topic trong kafka ở docker
        public KafkaProducerService()
        {
            //kết nối toiw kafka
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };
            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        // viết hàm để send tới kafka message broker
        public async Task PublishUserRegisteredEvent(string email, string username)
        {
            //define new message
            var message = new
            {
                Email = email,
                Username = username,
                Timestamp = DateTime.UtcNow
            };
            // convert dạng json
            var jsonMessage = JsonSerializer.Serialize(message);

            //gửi message tới kafka xử lí
            await _producer.ProduceAsync(topic: Topic, new Message<string, string>
            {
                Key = email,
                Value = jsonMessage
            });
        }

        // define hàm dọn vùng nhwos đi close producer --> tạo event thì đã tạo vùng nhớ ---> bắn nó đi r mà vũng nhớ vẫn tồn tại --> clear nó đi
        public void Dispose()
        {
            _producer.Dispose(); // bắt buộc phải có

        }
    }
}

