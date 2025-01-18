namespace POC.DDD.Application.DTOs.Output.Base
{
    public class ErrorResponse
    {
        public IEnumerable<string> Errors { get; init; }

        public ErrorResponse(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}
