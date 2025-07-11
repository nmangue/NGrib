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

using NGrib.Common;

namespace NGrib.Grib1;

/// <summary> A class that scans a GRIB file to extract product information. </summary>
public sealed class Grib1Input
{
    #region Fields
    /*
    * stores records of Grib file, records consist of objects for each section.
    * there are 5 sections to a Grib1 record.
    */
    //UPGRADE_NOTE: Final was removed from the declaration of 'records '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
    private List<Grib1Record> _records = new();
        
    private readonly Grib1File _grib1File;
        

    #endregion


    #region Properties

    #region Internal

    /*
    * raf for grib file
    */
    internal Stream InputStream { get; private set; }

    #endregion


    #region Public

    /// <summary> Get records of the GRIB file.
    /// 
    /// </summary>
    /// <returns> records 
    /// </returns>
    public IReadOnlyList<Grib1Record> Records => _records;

    #endregion

    #endregion


    #region Constructors

    // *** constructors *******************************************************


    /// <summary> Constructs a <tt>Grib1Input</tt> object from a raf.
    /// 
    /// </summary>
    /// <param name="raf">with GRIB content
    /// 
    /// </param>
    //UPGRADE_TODO: Class 'java.io.RandomAccessFile' was converted to 'System.IO.FileStream' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaioRandomAccessFile'"
    public Grib1Input(System.IO.Stream raf, Grib1File grib1File)
    {
        this.InputStream = raf;
        _grib1File = grib1File;
    }

    #endregion


    #region Methods


    /// <summary> scans a Grib file to gather information that could be used to
    /// create an index or dump the metadata contents.
    /// 
    /// </summary>
    /// <param name="getProducts">products have enough information for data extractions
    /// </param>
    /// <param name="oneRecord">returns after processing one record in the Grib file
    /// </param>
    /// <throws>  NotSupportedException </throws>
    public IEnumerable<Grib1Record> ScanRecords()
    {
            
        InputStream.Seek(0, SeekOrigin.Begin);

        // stores the number of times a particular GDS is used
        //UPGRADE_TODO: Class 'java.util.HashMap' was converted to 'System.Collections.Hashtable' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMap'"
        System.Collections.Hashtable gdsCounter = new System.Collections.Hashtable();
        //Grib1ProductDefinitionSection pds;
        Grib1GridDefinitionSection gds = null;
        long startOffset;


        while (InputStream.Position < InputStream.Length)
        {
            if (!CommonGribFile.SeekHeader(InputStream, InputStream.Length, out startOffset)) continue;
            var gr = _grib1File.ReadGrib1Record(InputStream, startOffset, gdsCounter, ref gds);
            if (gr == null)
                continue;
            yield return gr;
        } // end while raf.Position < raf.Length

        _grib1File.CheckGdSkeys(gds, gdsCounter);
    }

    // end scan

    public Grib1Record GetRecord(int idx)
    {
        if (idx < 0 || idx >= _records.Count)
        {
            throw new IndexOutOfRangeException();
        }

        return _records[idx] as Grib1Record;
    }

    public void SetFilename(string filename)
    {
        InputStream = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);
    }

    public void CloseFile()
    {
        InputStream.Close();
    }

    public double MissingValue
    {
        get { return Grib1BinaryDataSection.MissingValue; }
    }

    #endregion
} // end Grib1Input