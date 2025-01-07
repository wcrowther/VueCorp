using coreApi.Models;
using coreApi.Models.Generic;
using coreLogic.Models;

namespace coreLogic.Interfaces
{
	public interface IContentManager
	{
		Task<List<Image>> GetImages();

		Task<PagedList<Image>> GetPagedImages(Pager pager);
	}
}