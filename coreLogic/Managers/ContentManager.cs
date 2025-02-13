using coreApi.Data.Interfaces;
using coreApi.Models.Generic;
using coreLogic.Interfaces;
using coreLogic.Models;

namespace coreApi.Logic;

public class ContentManager( IContentRepo contentRepo) 
: IContentManager
{
	public async Task<List<Image>> GetImages()
	{
		return await Task.FromResult(contentRepo.GetImages());
	}

	public async Task<PagedList<Image>> GetPagedImages(Pager pager)
	{
		return await Task.FromResult(contentRepo.GetPagedImages(pager));
	}
}