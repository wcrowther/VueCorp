namespace coreApi.Models;

public class AppSettings
{
	public string AuthSigningKey { get; set; }

	public string AuthIssuer { get; set; }

	public string AuthAudience { get; set; }

	public int TokenExpirationMinutes { get; set; }

	public int RefreshTokenExpirationDays { get; set; }
}