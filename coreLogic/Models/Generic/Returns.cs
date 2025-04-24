
namespace coreLogic.Models.Generic;

public class Returns<T>(T data = default, Error error = null)
{
	public T Data { get => data; }

	public Error Error { get => error; }

	public bool Ok => Error is null;

	public bool HasData => Data is not null;

	public static Returns<T> Success(T data)
		=> new(data);

	public static Returns<T> Result(T data, string errorMessage = "No data returned.")
		=> data is not null ? new(data) : Failure(errorMessage);

	public static Returns<T> Failure(string errorMessage)
		=> new(error: new Error(errorMessage));

	public static Returns<T> Failure(Error error) => new(error: error);

	public static Returns<T> Failure(Exception exception) => new(error: exception);


	public static implicit operator Returns<T>(T data)				=> Success(data);

	public static implicit operator Returns<T>(Error error)			=> Failure(error);

	public static implicit operator Returns<T>(Exception exception) => Failure(exception);
}

public class Returns(string data = "", Error error = null) : Returns<string>(data, error);
