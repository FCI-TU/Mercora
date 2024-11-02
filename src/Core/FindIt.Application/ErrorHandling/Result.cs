using Microsoft.AspNetCore.Authentication;

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
	public static Result<T> Success(T data, Status? status=null)
	{
		return new Result<T>(data, status ?? new Status(200));
	}
	public static Result<T> Failure(Status status)
	{
		return new Result<T>(default, status);
	}

	public Result(Status error)
	{
		_data = default;
		_error = error;
	}
	public Result(T data)
	{
		_data = data;
		_error = default;
	}


	T GetData()
	{
		return _data!;
	}
}


public class Result : Result<string>
{
	public Result(Status error) : base(error)
	{
	}

	public Result(string data) : base(data)
	{
	}

	public Result(string data, Status error) : base(data, error)
	{
	}
}