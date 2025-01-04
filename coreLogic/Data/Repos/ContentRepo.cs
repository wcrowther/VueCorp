using coreApi.Models;
using coreApi.Data.Interfaces;
using coreLogic.Models;
using SeedPacket.Extensions;
using System.Collections.Generic;

namespace coreApi.Data;

public class ContentRepo : IContentRepo
{
	private readonly CoreApiDataContext _dataContext;

	public ContentRepo()
	{
		_dataContext = new CoreApiDataContext();
	}

	public async Task<IEnumerable<Image>> GetImages()
	{
		return await Task.FromResult(new List<Image>().Seed(10));
	}
}
