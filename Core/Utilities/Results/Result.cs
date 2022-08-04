namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        

        public Result(bool success, string message):this(success) //execute "one parameter constructor" of result.
        {
           Message = message;
        }
        public Result(bool success)
        {         
           Success = success;
        }


        public bool Success { get; } 

        public string Message { get; }//Read onlies can set with constructor.
    }
}