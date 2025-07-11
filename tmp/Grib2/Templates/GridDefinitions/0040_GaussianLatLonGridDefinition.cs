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
 *
 * Edited by reagafonov@yandex.ru
 * Adopted from GribApi.Xp
 */

using System.Data;
using NGrib.Helpers;

namespace NGrib.Grib2.Templates.GridDefinitions;

public class GaussianLatLonGridDefinition : XyEarthGridDefinition
{
    private const long Maxiter = 1000;

    private const double MPi = Math.PI;

    private static readonly double[] GaussValues;
    protected double Ratio { get; }

    /// <summary> .</summary>
    /// <returns> Angle as a int
    /// 
    /// </returns>
    public long Angle { get; }

    /// <summary> .</summary>
    /// <returns> Subdivisionsangle as a int
    /// 
    /// </returns>
    public long Subdivisionsangle { get; }

    /// <summary> .</summary>
    /// <returns> La1 as a double
    /// 
    /// </returns>
    public double La1 { get; }

    /// <summary> .</summary>
    /// <returns> Lo1 as a double
    /// 
    /// </returns>
    public double Lo1 { get; }

    /// <summary> .</summary>
    /// <returns> Resolution as a int
    /// 
    /// </returns>
    public int Resolution { get; }

    /// <summary> .</summary>
    /// <returns> La2 as a double
    /// 
    /// </returns>
    public double La2 { get; }

    /// <summary> .</summary>
    /// <returns> Lo2 as a double
    /// 
    /// </returns>
    public double Lo2 { get; }

    /// <summary> Get x-increment/distance between two grid points.
    /// 
    /// </summary>
    /// <returns> x-increment
    /// </returns>
    public double Dx { get; }

    /// <summary> Number of latitudes in full grid.
    /// 
    /// </summary>
    /// <returns> 
    /// </returns>
    public long N { get; }

    /// <summary> Get scan mode.
    /// 
    /// </summary>
    /// <returns> scan mode
    /// </returns>
    public ScanMode ScanMode { get; }

    public IEnumerable<double> Latitudes { get; }

    static GaussianLatLonGridDefinition()
    {
        GaussValues = new[]
        {
            2.4048255577E0, 5.5200781103E0,
            8.6537279129E0, 11.7915344391E0, 14.9309177086E0,
            18.0710639679E0, 21.2116366299E0, 24.3524715308E0,
            27.4934791320E0, 30.6346064684E0, 33.7758202136E0,
            36.9170983537E0, 40.0584257646E0, 43.1997917132E0,
            46.3411883717E0, 49.4826098974E0, 52.6240518411E0,
            55.7655107550E0, 58.9069839261E0, 62.0484691902E0,
            65.1899648002E0, 68.3314693299E0, 71.4729816036E0,
            74.6145006437E0, 77.7560256304E0, 80.8975558711E0,
            84.0390907769E0, 87.1806298436E0, 90.3221726372E0,
            93.4637187819E0, 96.6052679510E0, 99.7468198587E0,
            102.8883742542E0, 106.0299309165E0, 109.1714896498E0,
            112.3130502805E0, 115.4546126537E0, 118.5961766309E0,
            121.7377420880E0, 124.8793089132E0, 128.0208770059E0,
            131.1624462752E0, 134.3040166383E0, 137.4455880203E0,
            140.5871603528E0, 143.7287335737E0, 146.8703076258E0,
            150.0118824570E0, 153.1534580192E0, 156.2950342685E0
        };
    }

        
    static void gauss_first_guess(long trunc, ref double[] vals)
    {
        long i, numVals;

        numVals = GaussValues.Length;
        for (i = 0; i < trunc; i++)
        {
            if (i < numVals)
                vals[i] = GaussValues[i];
            else
                vals[i] = vals[i - 1] + MPi;
        }
    }

    internal GaussianLatLonGridDefinition(BufferedBinaryReader reader) : base(reader)
    {
        Angle = reader.ReadUInt32();
        Subdivisionsangle = reader.ReadUInt32();
        if (Angle == 0)
        {
            Ratio = 1e-6;
        }
        else
        {
            Ratio = (double)Angle /  Subdivisionsangle;
        }

        La1 = reader.ReadInt32() * Ratio;
        Lo1 = reader.ReadInt32() * Ratio;
        Resolution = reader.ReadUInt8();
        La2 = reader.ReadUInt32() * Ratio;
        Lo2 = reader.ReadUInt32() * Ratio;
        Dx = reader.ReadUInt32() * Ratio;
        N = reader.ReadUInt32();

        ScanMode = new ScanMode(reader.ReadUInt8());

        var latitudes = new double[2 * N];
        grib_get_gaussian_latitudes(N, ref latitudes);
            
        var minLat = Math.Min(La1, La2);
            
        Latitudes = latitudes.OrderBy(x => x).SkipWhile(x => minLat > x).Take((int) Ny);
            
        if (minLat > La1)
            Latitudes = Latitudes.Reverse();
            
        Latitudes = Latitudes.ToList();
    }

    private void grib_get_gaussian_latitudes(long trunc, ref double[] lats)
    {
        long jlat;
        long iter;
        long legi;
        double convval;
        double root;
        double legfonc = 0;
        double mem1, mem2, conv;
        double denom;
        double precision = 1.0E-14;
        long nlat = trunc * 2;

        var rad2deg = 180.0d / MPi;

        convval = (1.0d - ((2.0d / MPi) * (2.0d / MPi)) * 0.25d);

        gauss_first_guess(trunc, ref lats);
        denom = Math.Sqrt(((nlat + 0.5d) * (nlat + 0.5d)) + convval);

        for (jlat = 0; jlat < trunc; jlat++)
        {
            /*   First approximation for root      */
            root = Math.Cos(lats[jlat] / denom);

            /*   Perform loop of Newton iterations  */
            iter = 0;
            conv = 1;

            while (Math.Abs(conv) >= precision)
            {
                mem2 = 1.0;
                mem1 = root;

                /*  Compute Legendre polynomial  */
                for (legi = 0; legi < nlat; legi++)
                {
                    legfonc = ((2.0 * (legi + 1) - 1.0) * root * mem1 - legi * mem2) / (legi + 1);
                    mem2 = mem1;
                    mem1 = legfonc;
                }

                /*  Perform Newton iteration  */
                conv = legfonc / ((nlat * (mem2 - root * legfonc)) / (1.0d - (root * root)));
                root -= conv;

                /*  Routine fails if no convergence after MAXITER iterations  */
                if (iter++ > Maxiter)
                {
                    throw new DataException("Non converge");
                }
            }

            /*   Set North and South values using symmetry */
            lats[jlat] = Math.Asin(root) * rad2deg;
            lats[nlat - 1 - jlat] = -lats[jlat];
        }

        if (nlat != (trunc * 2))
            lats[trunc + 1] = 0.0;
    }

    public override IEnumerable<Coordinate> EnumerateGridPoints()
    {
        if (ScanMode.RowsZigzag || ScanMode.IsYDirectionOffset
                                || ScanMode.IsXDirectionEvenOffset || ScanMode.RowsNxNyPoints
                                || ScanMode.IsXDirectionOddRowsOffset
                                || ScanMode.IsXIncrement
                                || ScanMode.IsYIncrement
                                || ScanMode.IsNortherly
                                || Lo2<=Lo1)
            throw new NotImplementedException();

        var dx = (Lo2 - Lo1) / (Nx - 1);
        return GetXConsecutiveCoordinates(dx);
    }

    private IEnumerable<Coordinate> GetXConsecutiveCoordinates(double dx)
    {
        foreach (var lat in Latitudes)
        {
            for (var x = 0; x < Nx; x++)
            {
                var lon = Lo1 + x * dx;
                var coordinate = new Coordinate(lat, lon);
                yield return coordinate;
            }
        }
    }
}