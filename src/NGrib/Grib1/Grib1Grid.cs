/*
 * This file is part of NGrib.
 *
 * Copyright © 2020 Nicolas Mangué
 * 
 * Copyright 2006-2010 Seaware AB, PO Box 1244, SE-131 28 
 * Nacka Strand, Sweden, info@seaware.se.
 * 
 * Copyright 1997-2006 Unidata Program Center/University 
 * Corporation for Atmospheric Research, P.O. Box 3000, Boulder, CO 80307,
 * support@unidata.ucar.edu.
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

namespace NGrib.Grib1
{
	/// <summary> A class that represents a canned grid definition section (GDS) .</summary>
	public sealed class Grib1Grid : Grib1GridDefinitionSection
	{
		/// <summary> Constructs a <tt>Grib1Grid</tt> object from a pds.
		/// 
		/// </summary>
		/// <param name="pds">Grib1ProductDefinitionSection to formulate grib
		/// 
		/// </param>
		internal Grib1Grid(Grib1ProductDefinitionSection pds) : base()
		{
			int generatingProcess = pds.Process_Id;
			int gridNumber = pds.Grid_Id;

			// checksum = 1000 + grid number
			checksum = "1000" + System.Convert.ToString(gridNumber);

			switch (gridNumber)
			{
				case 21:
				case 22:
				case 23:
				case 24:
				{
					type = 0; // Latitude/Longitude
					name = getName(type);

					// (Nx - number of points along x-axis)
					nx = 37;

					// (Ny - number of points along y-axis)
					ny = 37;

					// (resolution and component flags).  See Table 7
					resolution = 0x88;

					// (Dx - Longitudinal Direction Increment )
					dx = 5.0;

					// (Dy - Latitudinal Direction Increment )
					dy = 2.5;

					// (Scanning mode)  See Table 8
					scan = 64;

					if (gridNumber == 21)
					{
						// (La1 - latitude of first grid point)
						lat1 = 0.0;

						// (Lo1 - longitude of first grid point)
						lon1 = 0.0;

						// (La2 - latitude of last grid point)
						lat2 = 90.0;

						// (Lo2 - longitude of last grid point)
						lon2 = 180.0;
					}
					else if (gridNumber == 22)
					{
						// (La1 - latitude of first grid point)
						lat1 = 0.0;

						// (Lo1 - longitude of first grid point)
						lon1 = -180.0;

						// (La2 - latitude of last grid point)
						lat2 = 90.0;

						// (Lo2 - longitude of last grid point)
						lon2 = 0.0;
					}
					else if (gridNumber == 23)
					{
						// (La1 - latitude of first grid point)
						lat1 = -90.0;

						// (Lo1 - longitude of first grid point)
						lon1 = 0.0;

						// (La2 - latitude of last grid point)
						lat2 = 0.0;

						// (Lo2 - longitude of last grid point)
						lon2 = 180.0;
					}
					else if (gridNumber == 24)
					{
						// (La1 - latitude of first grid point)
						lat1 = -90.0;

						// (Lo1 - longitude of first grid point)
						lon1 = -180.0;

						// (La2 - latitude of last grid point)
						lat2 = 0.0;

						// (Lo2 - longitude of last grid point)
						lon2 = 0.0;
					}
				}
					break;


				case 25:
				case 26:
				{
					type = 0; // Latitude/Longitude
					name = getName(type);

					// (Nx - number of points along x-axis)
					nx = 72;

					// (Ny - number of points along y-axis)
					ny = 19;

					// (resolution and component flags).  See Table 7
					resolution = 0x88;

					// (Dx - Longitudinal Direction Increment )
					dx = 5.0;

					// (Dy - Latitudinal Direction Increment )
					dy = 5.0;

					// (Scanning mode)  See Table 8
					scan = 64;

					if (gridNumber == 25)
					{
						// (La1 - latitude of first grid point)
						lat1 = 0.0;

						// (Lo1 - longitude of first grid point)
						lon1 = 0.0;

						// (La2 - latitude of last grid point)
						lat2 = 90.0;

						// (Lo2 - longitude of last grid point)
						lon2 = 355.0;
					}
					else if (gridNumber == 26)
					{
						// (La1 - latitude of first grid point)
						lat1 = -90.0;

						// (Lo1 - longitude of first grid point)
						lon1 = 0.0;

						// (La2 - latitude of last grid point)
						lat2 = 0.0;

						// (Lo2 - longitude of last grid point)
						lon2 = 355.0;
					}
				}
					break;


				case 61:
				case 62:
				case 63:
				case 64:
				{
					type = 0; // Latitude/Longitude
					name = getName(type);

					// (Nx - number of points along x-axis)
					nx = 91;

					// (Ny - number of points along y-axis)
					ny = 46;

					// (resolution and component flags).  See Table 7
					resolution = 0x88;

					// (Dx - Longitudinal Direction Increment )
					dx = 2.0;

					// (Dy - Latitudinal Direction Increment )
					dy = 2.0;

					// (Scanning mode)  See Table 8
					scan = 64;

					if (gridNumber == 61)
					{
						// (La1 - latitude of first grid point)
						lat1 = 0.0;

						// (Lo1 - longitude of first grid point)
						lon1 = 0.0;

						// (La2 - latitude of last grid point)
						lat2 = 90.0;

						// (Lo2 - longitude of last grid point)
						lon2 = 180.0;
					}
					else if (gridNumber == 62)
					{
						// (La1 - latitude of first grid point)
						lat1 = 0.0;

						// (Lo1 - longitude of first grid point)
						lon1 = -180.0;

						// (La2 - latitude of last grid point)
						lat2 = 90.0;

						// (Lo2 - longitude of last grid point)
						lon2 = 0.0;
					}
					else if (gridNumber == 63)
					{
						// (La1 - latitude of first grid point)
						lat1 = -90.0;

						// (Lo1 - longitude of first grid point)
						lon1 = 0.0;

						// (La2 - latitude of last grid point)
						lat2 = 0.0;

						// (Lo2 - longitude of last grid point)
						lon2 = 180.0;
					}
					else if (gridNumber == 64)
					{
						// (La1 - latitude of first grid point)
						lat1 = -90.0;

						// (Lo1 - longitude of first grid point)
						lon1 = -180.0;

						// (La2 - latitude of last grid point)
						lat2 = 0.0;

						// (Lo2 - longitude of last grid point)
						lon2 = 0.0;
					}

					break;
				}

				default:
					System.Console.Out.WriteLine("Grid " + gridNumber + " not configured yet");
					break;
			}
		} // end Grib1Grid
	} // end Grib1Grid
}