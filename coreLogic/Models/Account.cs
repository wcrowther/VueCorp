using System.ComponentModel.DataAnnotations;

namespace coreApi.Models;

public class Account
{
    [Required]
	public int AccountId { get; set; }

	[Required, MaxLength(50)]
    public string AccountName { get; set; } = "";

	[Required, EmailAddress]
    public string AccountEmail { get; set; } = "";

	public string AccountUrl { get; set; } = "";

	[Required, Phone]
	public string AccountPhone { get; set; } = "";

	[Required, MaxLength(50)]
	public string StreetAddress { get; set; } = "";

	[Required, MaxLength(50)]
	public string City { get; set; } = "";

	[Required, MaxLength(2)]
	public string StateProvince { get; set; } = "";

	[Required, MaxLength(10)]
	public string PostalCode { get; set; } = "";

	public bool IsInvoice { get; set; }

	public bool IsAutoPay { get; set; }

	public bool IsActive { get; set; } = true;

	// public Address AccountAddress { get; set; }

	public override string ToString() => $"{AccountName} AccountId: {AccountId}";
}