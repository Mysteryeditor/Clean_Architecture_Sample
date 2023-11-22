namespace CleanArchitectureSample.Shared.Result
{
    public class Result<T>
    {
        public static ResultModel<T> ReturnResult(int statuscode, string message, T Data)
        {
            return new ResultModel<T>()
            {
                Statuscode = statuscode,
                Message = message,
                Data = Data
            };
        }
    }
}