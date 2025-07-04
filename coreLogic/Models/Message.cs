using coreLogic.Interfaces;
using coreLogic.Models.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreApi.Models;

public class Message : IAuditable
{
    [Required]
	public int MessageId { get; set; }

	[Required, MaxLength(500)]
    public string MessageText { get; set; } = "";

	public DateTime DateCreated { get; set; }

	public DateTime DateModified { get; set; }

	public int CreatorId { get; set; }

	public int ModifierId { get; set; }

	[NotMapped]
	public string CreatorName { get; set; }

	[NotMapped]
	public string ModifierName { get; set; }

	public override string ToString() => $"{MessageId} UserId: {CreatorId} Text: {MessageText} ";
}