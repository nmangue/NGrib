using System;

namespace NGrib.Grib2.CodeTables
{
	[Flags]
	public enum ScanningMode
	{
		ScanIReverse = 128,
		ScanJPositive = 64,
		AdjacentPointsInJConsecutive = 32,
		AdjacentRowsScanInOppositeDirection = 16,
		DxOffOdd = 8,
		DxOffEven = 4,
		DyOff = 2,
		ReducedGrid = 1,
		Default = 0
	}
}
