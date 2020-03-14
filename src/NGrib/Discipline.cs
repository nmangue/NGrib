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
 
namespace NGrib
{
	
	/// <summary> Class which represents a discipline from from a parameter table.
	/// A parameter consists of a discipline( ie Meteorological_products), 
	/// a Category( ie Temperature ) and a number that refers to a name( ie Temperature)
	/// 
	/// see <a href="../../Parameters.txt">Parameters.txt</a>
	/// </summary>
	public sealed class Discipline
	{
		//UPGRADE_NOTE: Respective javadoc comments were merged.  It should be changed in order to comply with .NET documentation conventions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1199'"
		/// <summary> returns number of this Discipline.</summary>
		/// <returns> number
		/// </returns>
		/// <summary> sets number of this Discipline.</summary>
		/// <param name="number">of this Discipline
		/// </param>
		public int Number
		{
			get
			{
				return number;
			}
			
			set
			{
				this.number = value;
			}
			
		}
		//UPGRADE_NOTE: Respective javadoc comments were merged.  It should be changed in order to comply with .NET documentation conventions. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1199'"
		/// <summary> returns name of this Discipline.</summary>
		/// <returns> name
		/// </returns>
		/// <summary> sets name of this Discipline.</summary>
		/// <param name="name">of this Discipline
		/// </param>
		public System.String Name
		{
			get
			{
				return name;
			}
			
			set
			{
				this.name = value;
			}
			
		}
		
		/// <summary> each discipline has a unique number.</summary>
		private int number;
		/// <summary> each discipline has a name.</summary>
		private System.String name;
		/// <summary> category - stores array of Category objests.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'category '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		//UPGRADE_TODO: Class 'java.util.HashMap' was converted to 'System.Collections.Hashtable' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMap'"
		private System.Collections.Hashtable category;
		
		/// <summary> Constructor for Discipline.</summary>
		public Discipline()
		{
			number = - 1;
			name = "undefined";
			//UPGRADE_TODO: Class 'java.util.HashMap' was converted to 'System.Collections.Hashtable' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMap'"
			category = new System.Collections.Hashtable();
		}
		
		// --Commented out by Inspection START (11/21/05 10:51 AM):
		//   public Discipline(int number, String name) {
		//      this.number = number;
		//      this.name = name;
		//      this.category = new HashMap();
		//   }
		// --Commented out by Inspection STOP (11/21/05 10:51 AM)
		
		/// <summary> returns a Category for this Discipline given a Category number.</summary>
		/// <param name="cat">
		/// </param>
		/// <returns> Category
		/// </returns>
		public Category getCategory(int cat)
		{
			if (category.ContainsKey(System.Convert.ToString(cat)))
			{
				//UPGRADE_TODO: Method 'java.util.HashMap.get' was converted to 'System.Collections.Hashtable.Item' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMapget_javalangObject'"
				return (Category) category[System.Convert.ToString(cat)];
			}
			else
			{
				return null;
			}
		}
		
		/// <summary> adds a Category to this Discipline.</summary>
		/// <param name="cat">of this Discipline
		/// </param>
		public void  setCategory(Category cat)
		{
			category[System.Convert.ToString(cat.Number)] = cat;
		}
	}
}