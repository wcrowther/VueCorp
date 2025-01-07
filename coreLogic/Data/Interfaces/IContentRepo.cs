using coreApi.Models;
using coreApi.Models.Generic;
using coreLogic.Models;

namespace coreApi.Data.Interfaces;

public interface IContentRepo
{
	List<Image> GetImages();

	PagedList<Image> GetPagedImages(Pager pager);
}
