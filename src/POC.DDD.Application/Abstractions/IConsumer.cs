namespace POC.DDD.Application.Abstractions
{
    /// <summary>
    /// This is the abstraction that will represent the consumer of the Broker in the Infra Layer
    /// </summary>
    public interface IConsumer<T> where T : class
    {
        Task ConsumeAsync(Func<T, Task> onMessage);
    }
}
