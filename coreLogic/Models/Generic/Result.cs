
using WildHare.Extensions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace coreApi.Models.Generic;

public class Result<T>
{
	private T _data;

	public bool Success => Exception is null && Data is not null;

	public Exception Exception { get; init; }

	public T Data { get; init; }

	public static implicit operator Result<T>(T data) => new() { Data = data };

	public static implicit operator Result<T>(Exception ex) => new() { Exception = ex };

	public static Result<T> Ok(T data) => new() { Data = data };

	public static Result<T> Error(string message, T data = default) => new() { Exception = new Exception(message), Data = data };

	public static Result<T> Error(Exception exception, T data = default) => new() { Exception = exception, Data = data };
}

public class Result : Result<string>
{
	public static implicit operator Result(string data) => new() { Data = data };

	public static implicit operator Result(Exception ex) => new() { Exception = ex };

	public override string ToString() => Success ? Data : Exception.Message;
}

