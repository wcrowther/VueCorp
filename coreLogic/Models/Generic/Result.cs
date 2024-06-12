using Microsoft.AspNetCore.Http.HttpResults;
using System;

namespace coreApi.Models.Generic;

public class Result
{
    public bool Success { get; init; }

    public string Message { get; init; }

    public Exception Exception { get; init; }

	public static Result Ok(string message = "")
	{
		return new() { Success = true, Message = message };
	}

	public static Result Error(string message, Exception exception = null)
	{
		return new() { Success = false, Message = message, Exception = exception };
	}
}

public class Result<T> : Result
{
    public T Data { get; set; }

	public static new Result<T> Ok(string message = "")
	{
		return new() { Success = true, Message = message };
	}

	public static Result<T> Error(string message, T data, Exception exception = null)
	{
		return new() { Success = false, Message = message, Data = data, Exception = exception };
	}
}
