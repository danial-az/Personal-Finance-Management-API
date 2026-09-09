namespace Personal_Finance_Management_API.Models;

public sealed class OperationResult<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public string? Error { get; }

    private OperationResult(bool isSuccess, T? value, string? error)
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }
    public static OperationResult<T> Success(T? value)
    {
        return new OperationResult<T>(true, value, null);
    }
    
    
    public static OperationResult<T> Failure(string error)
    {
        return new OperationResult<T>(false, default(T), error);
    }
}
public sealed class OperationResult
{
    public bool IsSuccess { get; }
    public string? Error { get; }

    private OperationResult(bool isSuccess, string? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static OperationResult Success()
    {
        return new OperationResult(true, null);
    }

    public static OperationResult Failure(string error)
    {
        return new OperationResult(false, error);
    }
}