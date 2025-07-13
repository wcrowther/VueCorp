using coreLogic.Interfaces;
using coreLogic.Models.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreApi.Models;

public class MessageNew 
{
	[Required, MaxLength(500)]
    public string MessageText { get; set; } = "";

	public int CreatorId { get; set; }

	public override string ToString() => $"UserId: {CreatorId} Text: {MessageText} ";
}