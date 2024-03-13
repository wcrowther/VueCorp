using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildHare.Extensions;

namespace coreLogic.Helpers
{
	public static class Extensions
	{
		public static bool IsNumeric(this string input)
		{
			if (input.IsNullOrSpace()) return false;

			foreach (char c in input)
			{
				if (!c.IsDigit()) return false;
			}
			return true;
		}
	}
}
