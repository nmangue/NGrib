using System;
using System.Collections.Generic;
using System.Text;

namespace NGrib.CodeTables
{
	[Flags]
	public enum ResolutionAndComponents
	{
		IDirectionIncrementGiven = 32,
		JDirectionIncrementGiven = 16,
		RelativeDefinedGrid = 8
	}
}
