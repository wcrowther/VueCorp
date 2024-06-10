using coreApi.Models.Generic;
using System.ComponentModel.DataAnnotations;

namespace coreApi.Models;

public class SearchForAccount : Search
{
	public string StateProvinceFilter { get; set; } = "";

	public string PostalCodeFilter { get; set; } = "";

}
