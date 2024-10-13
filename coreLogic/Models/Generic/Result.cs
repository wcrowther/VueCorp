
using WildHare.Extensions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace coreApi.Models.Generic;

public class Result<T>
{
	public bool Success { get; init; }

	public string Message { get; init; }

	public Exception Exception { get; init; }

	public T Data { get; init; }

	public static Result<T> Ok (T data = default, string message = null)
	{
		return new() { Success = true, Data = data, Message = message };
	}

	public static Result<T> Error(string message, Exception exception = null)
	{
		return new() { Success = false, Message = message, Exception = exception };
	}

	public static Result<T> HasData(T data = default, string message = "", string noDataMessage = "")
	{
		bool hasData = data is not null;
		return new() { Success = hasData, Data = data, Message = hasData ? message : noDataMessage };
	}

	public static Result<T> HasCount(T data = default, string message = "", string noDataMessage = "")
	{
		string nullError = noDataMessage.IsNullOrEmpty() ? "HasCount() data type cannot be null" : noDataMessage;
		string ienumerableError = "HasCount() data type must be able to be converted to type IEnumerable<object>";

		if (data is null)
			return Error(nullError, new Exception(nullError));
		
		if (data is IEnumerable<object> e)
			return new() { Success = e.Any(), Data = data, Message = e.Any() ? message : noDataMessage };
		
		return Error(ienumerableError, new Exception(ienumerableError));
	}
}

public class Result : Result<int>
{
	public static new Result Ok(int data = default, string message = null) => new Result { Data = data, Message = message };

	public static new Result Error(string message, Exception exception = null) => new Result { Message = message, Exception = exception};
}

