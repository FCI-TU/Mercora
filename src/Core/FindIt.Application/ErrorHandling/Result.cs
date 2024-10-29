namespace FindIt.Application.ErrorHandling;
public class Result<T>
{
	private T? _data { get; set; }
	private Status? _error { get; set; }


	public Result(T data, Status error)
	{
		_data = data;
		_error = error;
	}
	public Result(T data)
	{
		_data = data;
		_error = null;
	}

	public Result(Status error)
	{
		_data = default;
		_error = error;
	}

	T GetValue()
	{
		return _data;
	}
}

public class Result : Result<string>
{
	public Result(string data) : base(data)
	{
	}
	public Result(Status error) : base(error)
	{
	}
}
