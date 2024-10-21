namespace POC.DDD.Shared
{
    public readonly struct Result<T>
    {
        private readonly bool _success;
        public readonly T Value;
        public readonly ResultError Error;

        private Result(T v, ResultError e, bool success)
        {
            Value = v;
            Error = e;
            _success = success;
        }

        public bool IsOk => _success;

        public static Result<T> Success(T v)
        {
            return new(v, default(ResultError), true);
        }

        public static Result<T> Fail(ResultError e)
        {
            return new(default(T), e, false);
        }

        public static implicit operator Result<T>(T v) => new(v, default(ResultError), true);
        public static implicit operator Result<T>(ResultError e) => new(default(T), e, false);

        public R Match<R>(
            Func<T, R> onSuccess,
            Func<ResultError, R> onFailure) =>
        _success ? onSuccess(Value) : onFailure(Error);
    }
}
