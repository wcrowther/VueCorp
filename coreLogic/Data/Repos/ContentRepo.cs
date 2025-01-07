using coreApi.Models;
using coreApi.Data.Interfaces;
using coreLogic.Models;
using SeedPacket.Extensions;
using System.Collections.Generic;
using WildHare.Extensions;
using coreApi.Models.Generic;

namespace coreApi.Data;

public class ContentRepo : IContentRepo
{
	private readonly CoreApiDataContext _dataContext;

	public ContentRepo()
	{
		_dataContext = new CoreApiDataContext();
	}


	public List<Image> GetImages()
	{
		string directoryPath	= @"C:\Git\VueCorp\vueapp\public\images";
		string[] fileExtensions	= [".png", ".jpg", ".gif", ".webp"];
		var imageFiles			= new DirectoryInfo(directoryPath)
									.GetFiles("*", SearchOption.TopDirectoryOnly)
									.Where(f => fileExtensions.Any(a => f.Name.EndsWith(a, true)));

		var images = imageFiles.Select(i => new Image { ImageSrc = i.Name, ImageId = Guid.NewGuid() }).ToList();

		return images;
	}

	public PagedList<Image> GetPagedImages(Pager pager)
	{
		var images = GetImages();

		pager.TotalCount = images.Count;
		var listItems	 = images.Skip(pager.FirstRecordInPage - 1)
								 .Take(pager.PageSize)
								 .ToList();

		var pagedList = new PagedList<Image>
		{
			ListItems   = listItems,
			Pager       = pager
		};

		return pagedList;
	}
}
