﻿using System;
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

		public static string[] Split(this string str, string separator, bool removeEmptyEntries, bool trimEntries = true)
		{
			StringSplitOptions options = trimEntries ? StringSplitOptions.TrimEntries : StringSplitOptions.None;
			options |= removeEmptyEntries ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None;

			return str.Split(separator, options);
		}

		public static byte[] ToUtf8Bytes(this string str)
		{
			return Encoding.UTF8.GetBytes(str);
		}
	}
}
