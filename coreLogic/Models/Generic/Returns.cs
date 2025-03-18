
namespace coreLogic.Models.Generic;

public class Returns<T>
{
	public T Data { get; init; }

	public Fault Fault { get; init; }

	public bool Success => Fault is null;

	public bool HasData => Data is not null;


	public static implicit operator Returns<T>(T data) => new() { Data = data };

	public static implicit operator Returns<T>(Fault fault) => new() { Fault = fault };


	public static Returns<T> Ok(T data) => new() { Data = data };

	public static Returns<T> Error(string message, T data = default) => new() { Fault = new Fault { Message = message }, Data = data };

	public static Returns<T> Error(Fault fault, T data = default) => new() { Fault = fault, Data = data };
}

public class Returns : Returns<string>
{
	public static implicit operator Returns(string data) => new() { Data = data };

	public static implicit operator Returns(Fault fault) => new() { Fault = fault };

	public override string ToString() => Success ? Data : Fault.Message;
}

public class Fault 
{
	public string Message { get; set; }

	public Fault InnerFault { get; set; }


	public static implicit operator Fault(Exception ex)
	{
		return new()
		{
			Message     = ex.Message,
			InnerFault  = ex.InnerException
		};
	}
}
