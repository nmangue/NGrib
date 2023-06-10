using System;
using System.Collections;

namespace NGrib.Tests
{
	internal static class GribFileSamples
	{
		public static string ValidFile { get; } = "samples/gfs.20200314.t00z.pgrb2.0p25.anl";

		/// <summary>
		/// Octet No.    Octet No.      Value        Meaning
		/// 1-4          1-4            GRIB         “GRIB” (coded according to the International Alphabet No. 5)
		/// 5-7          5-6            All 1’s      Reserved
		/// 7            7              0            This GRIB2 message contains meteorological products (the product discipline)
		/// 8            8              2            The GRIB Edition Number is 2
		/// 9-16         9-16           207          The total length of this GRIB message is 207 octets
		/// 1-4          17-20          21           This Section is 21 octets long
		/// 5            21             1            This is Section 1
		/// 6-7          22-23          74           The originating/generating centre is the U.K. Meteorological Office
		/// 8-9          24-25          0            There is no originating/generating sub-centre
		/// 10           26             1            GRIB Master Tables Version Number 1 is used
		/// 11           27             0            No GRIB Local Tables are used
		/// 12           28             1            The Reference Time is the start of the forecast
		/// 13-14        29-30          2003         Year = 2003   |
		/// 15           31             5            Month = April |
		/// 16           32             1            Day = 1       | Reference time of data
		/// 17           33             0            Hour = 0      |
		/// 18           34             0            Minute = 0    |
		/// 19           35             0            Second = 0    |
		/// 20           36             0            This GRIB2 message contains operational products
		/// 21           37             1            This GRIB2 message contains forecast products
		/// 1-4          38-41          65           This Section is 65 octets long
		/// 5            42             3            This is Section 3
		/// 6            43             0            This grid is specified in Code Table 3.1
		/// 7-10         44-47          25           There are 25 data points in this grid
		/// 11           48             0            There is no optional list of numbers defining number of points
		/// 12           49             0            Since there is no optional list of numbers, no interpretation is needed
		/// 13-14        50-51          20           The Grid Definition Template Number is 3.20 – a polar stereographic projection
		/// 15           52             1            The earth is assumed to be spherical with radius specified by the data producer
		/// 16           53             3            The scale factor for the radius of the spherical earth is 3
		/// 17-20        54-57          6350000      The scaled value of the radius of the spherical earth is 6350000 km
		/// 21           58             all 1’s      There is no scale factor for the major axis of an oblate spheroid earth 
		/// 22-25        59-62          all 1’s      There is no scaled value for the major axis of an oblate spheroid earth
		/// 26           63             all 1’s      There is no scale factor for the minor axis of an oblate spheroid earth
		/// 27-30        64-67          all 1’s      There is no scaled value for the minor axis of an oblate spheroid earth
		/// 31-34        68-71          5            There are 5 points along the X-axis (Nx)
		/// 35-38        72-75          5            There are 5 points along the Y-axis (Ny)
		/// 39-42        76-79          40000001     The latitude of the first grid point is 40.000001 0 north (La1)
		/// 43-46        80-83          349999999    The longitude of the first grid point is 349.999999 0 east (or 10.000001 0 west) (Lo1)
		/// 47           84             00000000     No resolution and component flag are turned on(see flag table 3.3 and Note 1)
		/// 48-51        85-88          40000001     Dx and Dy are specified at 40.000001 0 north ((LaD)
		/// 52-55        89-92          0            The 0 degree meridian is parallel to the Y-axis (LoV)
		/// 56-59        93-96          100000000    The X direction grid length is 100.000 km (Dx)
		/// 60-63        97-100         100000000    The Y direction grid length is 100.000 km (Dy)
		/// 64           101            00           The north pole is on the projection plane and only one projection centre is used
		/// 65           102            01000000     Points scan in the +i (+x) direction, rows in the +j (+Y) direction, adjacent points in the (x) direction are consecutive, and all rows scan in the same direction
		/// 1-4          103-106        34           This Section is 34 octets long
		/// 5            107            4            This is Section 4
		/// 6-7          108-109        0            There are no coordinate values after the Product Definition Template
		/// 8-9          110-111        0            The Product Definition Template Number is 4.0 – an analysis or forecast at a horizontal level or in a horizontal layer at a point in time
		/// 10           112            3            The parameter category is 3 – mass products
		/// 11           113            5            The parameter number is 5 – geopotential height (in geopotential meters)
		/// 12           114            2            A forecast generated this product (the generating process)
		/// 13           115            All 1’s      No information on the background generating process is provided
		/// 14           116            All 1’s      No further information on the forecast generating process is provided
		/// 15-16        117-118        3            The observational data cut-off was 3 hours after the reference time
		/// 17           119            30           The observational data cut-off was 30 minutes after the observational cut-off hour
		/// 18           120            1            The time is given in hours
		/// 19-22        121-124        12           The forecast time is 12 hours after the reference time
		/// 23           125            100          The first fixed surface is a pressure surface
		/// 24           126            0            The scale factor of first fixed surface is 0
		/// 25-28        127-130        500          The scaled value of first fixed surface is 500 (500 hPa)
		/// 29           131            All 1’s      There is no second fixed surface
		/// 30           132            All 1’s      The scale factor of the second fixed surface is missing since it is not needed
		/// 31-34        133-136        All 1’s      The scaled value of the second fixed surface is missing since it is not needed 
		/// 1-4          137-140        21           This Section is 21 octets long
		/// 5            141            5            This is Section 5
		/// 6-9          142-145        25           There are 25 data points for which values are specified in Section
		/// 10-11        146-147        0            The Data Representation Template Number is 5.0 - Grid point data – simple packing
		/// 12-15        148-151        53400        The reference value (R) is 53400.0 (IEEE 32-bit floating-point value)
		/// 16-17        152-153        0            The binary scale factor (E) is 0: binary scaling is not used
		/// 18-19        154-155        1            The decimal scale factor (D) is 1: precision is 0.1 geopotential meters
		/// 20           156            11           11 bits are used for each packed value in the Data Section
		/// 21           157            0            The original field values were floating point numbers
		/// 1-4          158-161        6            This Section is 6 octets long
		/// 5            162            6            This is Section 6
		/// 6            163            255          There is no bit-map
		/// 1-4          164-167        40           This Section is 40 octets long
		/// 5            168            7            This is Section 7
		/// 6-40         169-203        ...          25 scaled integers, 25 binary data values, each using 11 bits. The binary values thus occupy 275 bits last 5 bits set to 0 5 additional bits set to zero are therefore necessary to end on an octet boundary.
		/// 1-4          204-207        7777        “7777” coded according to the International Alphabet No. 5
		/// </summary>
		public static string WmoOneDataSetMessage { get; } = "samples/wmo-one_dataset-message.grb2";

		/// <summary>
		/// NCEP GFS 20200330/18+12 Forecasts (0.25 degree grid):
		///   - lon 55 - 55.5
		///   - lat -21 - -21.25
		/// Contains Surface TMP and APCP.
		/// </summary>
		public static string NcepGfsTmpApcpFile { get; } = "samples/gfs.20200330.t18z.pgrb2.0p25.f012";

		/// <summary>
		/// NCEP GEFS 20200815/06+06 Forecasts (0.5 degree grid)
		/// Contains all variable on subregion
		/// </summary>
		public static string NcepGefsAvgFile { get; } = "samples/geavg.t06z.pgrb2a.0p50.f006";

		/// <summary>
		/// NCEP GEFS P8 20200825/06+02 Forecasts (0.5 degree grid)
		/// Contains all variable on subregion
		/// </summary>
		public static string NcepGefsPerturbationFile { get; } = "samples/gep08.t00z.pgrb2a.0p50.f012";


		/// <summary>
		/// Météo France AROME
		/// Contains Temperature data with a Jpeg2000 Data Representation.
		/// </summary>
		public static string MfAromeTemperatureFile { get; } = "samples/W_fr-meteofrance,MODEL,AROME+0025+SP1+00H06H_C_LFPW_202010310600--Temperature.grib2";

		/// <summary>
		/// DWD COSMO
		/// Uses a bitmap section.
		/// </summary>
		public static string DwdCosmoTotalPrecipitationFile { get; } = "samples/cosmo-d2_germany_regular-lat-lon_single-level_2020103112_012_TOT_PREC.grib2";

		/// <summary>
		/// Harmonie Netherlands
		/// Contains a subset of data for one hour 
		/// </summary>
		public static string HarmonieOneHourFile { get; } = "samples/HA40_N55_202306100000_00100_GB";
	}
}