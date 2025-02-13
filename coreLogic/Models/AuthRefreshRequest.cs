namespace coreLogic.Models
{
	public class AuthRefreshRequest
	{
		public int UserId { get; set; }

		public string RefreshToken { get; set; }
	}
}