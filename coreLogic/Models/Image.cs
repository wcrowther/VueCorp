using System.ComponentModel.DataAnnotations;

namespace coreLogic.Models
{
	public class Image
	{
		[Required]
		public int AccountId { get; set; }

		[Required]
		public string ImageSrc { get; set; }
	}
}