namespace Fruitable.Utilities
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        public Result()
        {
            Errors = new List<string>();
        }

        public static Result<T> SuccessResult(T data, string message = "")
        {
            return new Result<T>
            {
                Success = true,
                Data = data,
                Message = message
            };
        }

        public static Result<T> ErrorResult(string error)
        {
            return new Result<T>
            {
                Success = false,
                Errors = new List<string> { error }
            };
        }

        public static Result<T> ErrorResult(List<string> errors)
        {
            return new Result<T>
            {
                Success = false,
                Errors = errors
            };
        }
    }
}
