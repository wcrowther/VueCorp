using System;
using System.Collections.Generic;
using WildHare.Extensions;

namespace coreLogic.Models.Generic;

public class Result(bool ok, string message = "") 
{
	public bool Ok { get; } = ok;

	public string Message { get; } = message;

	public List<Result> History { get; } = [];

	public static Result Error(string errorMessage) => new Result(false, errorMessage);

	public override string ToString() => Ok ? "Success" : Message;
};

public static class ResultExtensions
{
	public static (T Data, Result Result) ToResult<T>(this	T data, Result ifError)
	{
		var eResult = ifError ?? new Result(false, "ToResult - Data is null");

		return data is null ? (data, eResult) : (data, new Result(true));
	}

	public static (T Data, Result Result) ToResult<T>(this T data, string errorMessage)
	{
		return data is null ? (data, Result.Error(errorMessage)) : (data, new Result(true));
	}

	public static (T Data, Result Result) Success<T>(this T data)
	{
		return (data, new Result(true));
	}

	public static (T Data, Result Result) Failure<T>(this T data, string message)
	{
		return (data, new Result(false, message));
	}
}