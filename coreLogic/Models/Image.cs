using System.ComponentModel.DataAnnotations;

namespace coreLogic.Models
{
	public class Image
	{
		[Required]
		public Guid ImageId { get; set; }

		[Required]
		public string ImageSrc { get; set; }
	}
}