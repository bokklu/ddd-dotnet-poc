namespace POC.DDD.Shared
{
    public class ResultError
    {
        public ResultErrorStatus Status { get; }
        public List<string> Messages { get; } = [];

        public ResultError(ResultErrorStatus status, string message)
        {
            Status = status;
            Messages.Add(message);
        }

        public ResultError(ResultErrorStatus status, IEnumerable<string> messages)
        {
            Messages.AddRange(messages);
        }
    }
}
