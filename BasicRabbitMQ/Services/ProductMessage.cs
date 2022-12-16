using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace BasicRabbitMQ.Services
{
    public class ProductMessage : IProductMessage
    {
        public void Send<T>(T message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            // Create Queue
            channel.QueueDeclare("product.create", exclusive: false);

            // Prepare body
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            // Publish message
            channel.BasicPublish(exchange: "", routingKey: "product.create", body: body);
        }
    }
}
