/*
 * This file is part of NGrib.
 *
 * Copyright © 2020 Nicolas Mangué
 * 
 * NGrib is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 * 
 * NGrib is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public License
 * along with NGrib.  If not, see <https://www.gnu.org/licenses/>.
 */

using NGrib.Grib2.CodeTables;
using System;
using System.Collections.Generic;

namespace NGrib.Grib2.Templates
{
	public abstract class Template
	{
		private readonly Dictionary<TemplateContent, Func<object>> _accessors = new Dictionary<TemplateContent, Func<object>>();

		protected Template()
		{
		}

		protected void RegisterContent<T>(TemplateContent<T> content, Func<T> accesor)
		{
			_accessors[content] = () => accesor();
		}

		public bool TryGet<T>(TemplateContent<T> content, out T result)
		{
			if (_accessors.TryGetValue(content, out var methodInfo))
			{
				result = (T) methodInfo.Invoke();
				return true;
			}

			result = default;
			return false;
		}

		protected TimeSpan? CalculateTimeRangeFrom(TimeRangeUnit rangeUnit, long value)
		{
			switch(rangeUnit)
			{
				case TimeRangeUnit.Minute:
					return TimeSpan.FromMinutes(value);
				case TimeRangeUnit.Hour:
					return TimeSpan.FromHours(value);
				case TimeRangeUnit.Day:
					return TimeSpan.FromDays(value);
				case TimeRangeUnit.Month:
					return TimeSpan.FromDays(value);
				case TimeRangeUnit.Hours3:
					return TimeSpan.FromHours(value*3);
				case TimeRangeUnit.Hours6:
					return TimeSpan.FromDays(value*6);
				case TimeRangeUnit.Hours12:
					return TimeSpan.FromDays(value*12);
				case TimeRangeUnit.Second:
					return TimeSpan.FromSeconds(value);
				default:
					// The other TimeRangeUnit (i.e. Month) can't be
					// converted to a TimeSpan without some convention.
					return null;
			}
		}
	}
}
