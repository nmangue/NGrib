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
	
	/// <summary>
	/// Class which represents a Category from a parameter table.
	/// A parameter consists of a discipline( ie Meteorological_products), 
	/// a Category( ie Temperature ) and a number that refers to a name( ie Temperature)
	/// 
	/// see <a href="../../Parameters.txt">Parameters.txt</a>
	/// 
	/// </summary>
	public sealed class Category
	{
		/// <summary> returns the number of this Category.</summary>
		/// <returns> int
		/// </returns>
		/// <summary> number value of this Category.</summary>
		/// <param name="number">of Category
		/// </param>
		public int Number
		{
			// --Commented out by Inspection START (11/21/05 10:35 AM):
			//   /**
			//    *
			//     * @param number
			//    * @param name
			//    * @param description
			//    */
			//   public Category(int number, String name, String description) {
			//      this.number = number;
			//      this.name = name;
			//      this.description = description;
			//      this.parameter = new HashMap();
			//   }
			// --Commented out by Inspection STOP (11/21/05 10:35 AM)
			
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
		/// <summary> returns name of this Category.</summary>
		/// <returns> name
		/// </returns>
		/// <summary> sets the name of this Category.</summary>
		/// <param name="name">of Category
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
		
		/// <summary> each category has a unique number.</summary>
		private int number;
		/// <summary> each category has a name.</summary>
		private System.String name;
		// --Commented out by Inspection START (12/8/05 1:05 PM):
		//   /**
		//    * each category has a description.
		//    */
		//   private String description;
		// --Commented out by Inspection STOP (12/8/05 1:05 PM)
		
		/// <summary> parameter - a HashMap of Parameters.</summary>
		//UPGRADE_NOTE: Final was removed from the declaration of 'parameter '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
		//UPGRADE_TODO: Class 'java.util.HashMap' was converted to 'System.Collections.Hashtable' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMap'"
		private System.Collections.Hashtable parameter;
		
		/// <summary>  Constructor for a Category.</summary>
		public Category()
		{
			number = - 1;
			name = "undefined";
			//description = "undefined";
			//UPGRADE_TODO: Class 'java.util.HashMap' was converted to 'System.Collections.Hashtable' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMap'"
			parameter = new System.Collections.Hashtable();
		}
		
		// --Commented out by Inspection START (11/21/05 10:35 AM):
		//   public final String getDescription(){
		//      return description;
		//   }
		// --Commented out by Inspection STOP (11/21/05 10:35 AM)
		
		/// <summary> given a Parameter number returns Parameter object for this Category.</summary>
		/// <param name="paramNumber">
		/// </param>
		/// <returns> Parameter
		/// </returns>
		public Parameter getParameter(int paramNumber)
		{
			if (parameter.ContainsKey(System.Convert.ToString(paramNumber)))
			{
				//UPGRADE_TODO: Method 'java.util.HashMap.get' was converted to 'System.Collections.Hashtable.Item' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMapget_javalangObject'"
				return (Parameter) parameter[System.Convert.ToString(paramNumber)];
			}
			else
			{
				return new Parameter(paramNumber, "Unknown", "Unknown", "Unknown");
			}
		}
		
		// --Commented out by Inspection START (11/21/05 10:34 AM):
		//   public final void setDescription( String description ){
		//      this.description = description ;
		//   }
		// --Commented out by Inspection STOP (11/21/05 10:34 AM)
		
		/// <summary> add this Parameter to this Category.</summary>
		/// <param name="param">object
		/// </param>
		public void  setParameter(Parameter param)
		{
			parameter[System.Convert.ToString(param.Number)] = param;
		}
	} // end Category
}