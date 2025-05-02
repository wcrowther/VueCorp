using coreApi.Models;
using coreLogic.Models.Generic;

namespace coreLogic.Interfaces
{
	public interface IUserClaimsManager
	{
		public int? GetCurrentUserId();

		public string GetCurrentUsername();
	}
}