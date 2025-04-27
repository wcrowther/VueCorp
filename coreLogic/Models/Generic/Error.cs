
namespace coreLogic.Models.Generic;

public class Errors : List<Error>
{
	public Errors(params IEnumerable<Error> errors) : base(errors) { }
	
	public string Message => this.First()?.Message; 

	public static Errors Empty => new Errors();

	public static Errors One(string message, Error innerError = null) => new Errors(new Error(message, innerError));

};

public class Error(string message, Error innerError = null)
{
	public string Message { get => message; }

	public Error InnerError { get => innerError; }

	public static implicit operator Error(Exception ex) 
		=> new Error(ex.Message, ex.InnerException);
}
