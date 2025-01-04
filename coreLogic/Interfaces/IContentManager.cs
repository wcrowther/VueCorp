using coreApi.Models;
using coreLogic.Models;

namespace coreLogic.Interfaces
{
	public interface IContentManager
	{
		Task<IEnumerable<Image>> GetImages();
	}
}