using Microsoft.Extensions.Options;
using coreApi.Data.Interfaces;
using coreApi.Models;
using coreApi.Models.Generic;
using coreApi.Logic.Interfaces;
using coreLogic.Interfaces;
using coreLogic.Models;
using coreApi.Data;

namespace coreApi.Logic;

public class ContentManager : IContentManager
{
    private readonly AppSettings _appSettings;
    private readonly IContentRepo _contentRepo;

    public ContentManager( IOptions<AppSettings> appSettings,
                           IContentRepo contentRepo)
    {
        _appSettings = appSettings.Value;
		_contentRepo = contentRepo;
    }

	public async Task<List<Image>> GetImages()
	{
		return await Task.FromResult(_contentRepo.GetImages());
	}

	public async Task<PagedList<Image>> GetPagedImages(Pager pager)
	{
		return await Task.FromResult(_contentRepo.GetPagedImages(pager));
	}
}