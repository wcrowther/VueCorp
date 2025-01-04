using coreApi.Models;
using coreLogic.Models;

namespace coreApi.Data.Interfaces;

public interface IContentRepo
{
	Task<IEnumerable<Image>> GetImages();
}