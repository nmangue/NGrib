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

namespace NGrib.Sections.Templates.GridDefinitionTemplates
{
	public abstract class GridPointEarthGridDefinition : XyEarthGridDefinition
	{
		/// <summary> .</summary>
		/// <returns> La1 as a float
		/// 
		/// </returns>
		public double La1 { get; }

		/// <summary> .</summary>
		/// <returns> Lo1 as a float
		/// 
		/// </returns>
		public double Lo1 { get; }

		/// <summary> .</summary>
		/// <returns> Resolution as a int
		/// 
		/// </returns>
		public int Resolution { get; }


		private protected GridPointEarthGridDefinition(BufferedBinaryReader reader) : base(reader)
		{
			La1 = reader.ReadInt32() * 1e-6;
			Lo1 = reader.ReadUInt32() * 1e-6;
			Resolution = reader.ReadUInt8();
		}
	}
}