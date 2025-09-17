using coreApi.Models.Generic;

namespace coreApi.Models;

public class SearchForUser : Search
{
	public string RoleFilter { get; set; } = "";

	public readonly static new SearchForUser Default = new();
}
