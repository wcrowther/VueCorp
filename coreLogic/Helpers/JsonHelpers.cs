﻿using System.Text.Json;
using System.Text.Json.Nodes;

namespace coreLogic.Helpers;

public static class JsonHelpers
{
	/// <summary>Masks JSON values for keys like 'Password', 'Token', etc</summary>
	public static string MaskJsonSecrets(this string json, params string[] propertiesToMask)
	{
		bool indent		= true;
		var root		= JsonNode.Parse(json);

		if (root == null) return json;

		MaskNodesRecursive(root, new HashSet<string>(propertiesToMask, StringComparer.OrdinalIgnoreCase));

		return root.ToJsonString(new JsonSerializerOptions { WriteIndented = indent});
	}

	// =================================================================================================================

	private static void MaskNodesRecursive(JsonNode node, HashSet<string> propertiesToMask)
	{
		if (node is JsonObject obj)
		{
			foreach (var prop in obj.ToList()) 
			{
				if (propertiesToMask.Contains(prop.Key))
				{
					obj[prop.Key] = MaskValue(prop.Value?.ToString() ?? "");
				}
			}

			foreach (var prop in obj)
			{
				MaskNodesRecursive(prop.Value, propertiesToMask);
			}
		}
		else if (node is JsonArray array)
		{
			foreach (var item in array)
			{
				MaskNodesRecursive(item, propertiesToMask);
			}
		}
	}

	private static string MaskValue(string value)
	{
		// Return a masked value with the same length as the original value
		return new string('*', value.Length);
	}
}

// =================================================================================================================
// string masked = json.MaskJsonWithOriginalLength("password", "token");
// Console.WriteLine(masked);
