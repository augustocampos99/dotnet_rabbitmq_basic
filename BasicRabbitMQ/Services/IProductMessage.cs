namespace BasicRabbitMQ.Services
{
    public interface IProductMessage
    {
        void Send<T> (T message);
    }
}
