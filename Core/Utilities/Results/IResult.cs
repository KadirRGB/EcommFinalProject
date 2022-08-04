namespace Core.Utilities.Results
{
    public interface IResult
    {
         bool Success { get; } //Read only
         string Message{ get; }
    }
}