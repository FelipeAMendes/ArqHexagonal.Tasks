namespace ArqHexagonal.Tasks.Lib.Shared;

public class Results<T>(bool succeeded, string message, T data) where T : class
{
    private bool _succeeded = succeeded;
    private string _message = message;
    private T _data = data;

    public bool Succeeded => _succeeded;
    public T Result => _data;
    public string Message => _message;

    public static Results<T> Success()
    {
        return new Results<T>(true, string.Empty, default);
    }

    public static Results<T> Success(T data)
    {
        return new Results<T>(true, string.Empty, data);
    }

    public static Results<T> Failure(string message)
    {
        return new Results<T>(false, message, default);
    }
}
