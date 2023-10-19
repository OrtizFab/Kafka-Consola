namespace dotNetKakfaConsle.Repositories
{
    public interface IdotnetKafkaConsumer
    {
        void Listen(Action<string> message);
    }
}
