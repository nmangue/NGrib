/*
 * This file is part of NGrib.
 *
 * Copyright � 2020 Nicolas Mangu�
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

namespace NGrib.Grib1;

/// <summary> A class used to extract data from a GRIB1 file. 
/// see <a href="../../../IndexFormat.txt"> IndexFormat.txt</a>
/// </summary>
public sealed class Grib1Data
{
    /* 
    *  used to hold open file descriptor
    */
    //UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
    private System.IO.Stream raf;

    private readonly Grib1File _grib1File;

    // *** constructors *******************************************************

    /// <summary> Constructs a Grib2Data object from a stream.
    /// 
    /// </summary>
    /// <param name="raf">ucar.unidata.io.RandomAccessFile with GRIB content.
    /// 
    /// </param>
    //UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
    public Grib1Data(System.IO.Stream raf, Grib1File grib1File)
    {
        this.raf = raf;
        _grib1File = grib1File;
    }

    public void setFilename(string filename)
    {
        raf = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);
    }

    public void closeFile()
    {
        raf.Close();
    }

    public double[] getData(long offset, int DecimalScale, bool bmsExists) =>
        _grib1File.getData(raf, offset, DecimalScale, bmsExists);

    // end getData
} // end Grib1Data