using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace NGrib.Tests
{
	internal static class TestUtils
	{
		public static IEnumerable<float?> ReadCsvValues(string fileName)
		{
			foreach (var line in File.ReadLines(fileName))
			{
				if (string.IsNullOrEmpty(line))
				{
					continue;
				}

				foreach (var textValue in line.Split(','))
				{
					if (textValue == "NaN")
					{
						yield return null;
					}
					else
					{
						yield return float.Parse(textValue, CultureInfo.InvariantCulture);
					}
				}
			}
		}
	}
}