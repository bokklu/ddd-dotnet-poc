using POC.DDD.Application.Abstractions;

namespace POC.DDD.Infra.Broker
{
    /// <summary>
    /// Message broker consumer goes here, it will read DTOs
    /// </summary>
    public class XConsumer : IConsumer<string>
    {
        public Task ConsumeAsync(Func<string, Task> onMessage)
        {
            throw new NotImplementedException();
        }
    }
}
