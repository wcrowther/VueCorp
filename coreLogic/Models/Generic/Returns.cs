
namespace coreLogic.Models.Generic;

public class Returns<T>
{
	public T Data { get; init; }

	public Exception Exception { get; init; }

	public bool Success => Exception is null;

	public bool HasData => Data is not null;


	public static implicit operator Returns<T>(T data) => new() { Data = data };

	public static implicit operator Returns<T>(Exception ex) => new() { Exception = ex };


	public static Returns<T> Ok(T data) => new() { Data = data };

	public static Returns<T> Error(string message, T data = default) => new() { Exception = new Exception(message), Data = data };

	public static Returns<T> Error(Exception exception, T data = default) => new() { Exception = exception, Data = data };
}

public class Returns : Returns<string>
{
	public static implicit operator Returns(string data) => new() { Data = data };

	public static implicit operator Returns(Exception ex) => new() { Exception = ex };

	public override string ToString() => Success ? Data : Exception.Message;
}

