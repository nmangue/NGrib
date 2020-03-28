using System;

namespace NGrib.Grib2.CodeTables
{
	[Flags]
	public enum ResolutionAndComponents
	{
		IDirectionIncrementGiven = 32,
		JDirectionIncrementGiven = 16,
		RelativeDefinedGrid = 8
	}
}
