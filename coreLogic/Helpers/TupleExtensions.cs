using coreLogic.Models.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildHare.Extensions;

namespace coreLogic.Helpers;

public static class TupleExtensions
{
	public static Res Map<Data, Res>(
		this (Data, Errors) source,
		Func<Data, Res> mapData,
		Func<Errors, Res> mapError)
	{
		return source.Item2 is null ? mapData(source.Item1) : mapError(source.Item2);
	}

	public static bool IsSuccess<Data>(this (Data, Errors) source) => !source.Item2.Any();

	public static bool IsFailure<Data>(this (Data, Errors) source) => source.Item2.Any();


}

