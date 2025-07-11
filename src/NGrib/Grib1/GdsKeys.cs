namespace NGrib.Grib1;

public sealed class GdsKeys
{
    /*
       * stores GDS of Grib1 file, there is possibility of more than 1
       */
    //UPGRADE_NOTE: Final was removed from the declaration of 'gdsHM '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
    //UPGRADE_TODO: Class 'java.util.HashMap' was converted to 'System.Collections.Hashtable' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMap'"
    /// <summary> Get GDS's of the GRIB file.
    /// 
    /// </summary>
    /// <returns> gdsHM 
    /// </returns>
    //UPGRADE_TODO: Class 'java.util.HashMap' was converted to 'System.Collections.Hashtable' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMap'"
    public System.Collections.Hashtable GdSs { get; } = new();

    /*
       * stores products of Grib file, products have enough info to get the
       * metadata about a parameter and the data. products are lightweight
       * records. 
       */
    //UPGRADE_NOTE: Final was removed from the declaration of 'products '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
    //private Grib1Input _grib1Input;
    /// <summary> Get products of the GRIB file.
    /// 
    /// </summary>
    /// <returns> products 
    /// </returns>
    public System.Collections.ArrayList Products { get; } = new();

    public void CheckGdSkeys(Grib1GridDefinitionSection gds, System.Collections.Hashtable gdsCounter)
    {
        // lat/lon grids can have > 1 GDSs
        if (gds.GridType == 0 || gds.GridType == 4)
        {
            return;
        }

        String bestKey = "";
        int count = 0;
        // find bestKey with the most counts
        //UPGRADE_TODO: Method 'java.util.HashMap.keySet' was converted to 'SupportClass.HashSetSupport' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMapkeySet'"
        //UPGRADE_TODO: Method 'java.util.Iterator.hasNext' was converted to 'System.Collections.IEnumerator.MoveNext' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilIteratorhasNext'"
        for (System.Collections.IEnumerator it = new SupportClass.HashSetSupport(gdsCounter.Keys).GetEnumerator();
             it.MoveNext();)
        {
            //UPGRADE_TODO: Method 'java.util.Iterator.next' was converted to 'System.Collections.IEnumerator.Current' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilIteratornext'"
            String key = (String) it.Current;
            //UPGRADE_TODO: Method 'java.util.HashMap.get' was converted to 'System.Collections.Hashtable.Item' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMapget_javalangObject'"
            int gdsCount = Int32.Parse((String) gdsCounter[key]);
            if (gdsCount > count)
            {
                count = gdsCount;
                bestKey = key;
            }
        }

        // remove best key from gdsCounter, others will be removed from gdsHM
        gdsCounter.Remove(bestKey);
        // remove all GDSs using the gdsCounter   
        //UPGRADE_TODO: Method 'java.util.HashMap.keySet' was converted to 'SupportClass.HashSetSupport' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilHashMapkeySet'"
        //UPGRADE_TODO: Method 'java.util.Iterator.hasNext' was converted to 'System.Collections.IEnumerator.MoveNext' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilIteratorhasNext'"
        for (System.Collections.IEnumerator it = new SupportClass.HashSetSupport(gdsCounter.Keys).GetEnumerator();
             it.MoveNext();)
        {
            //UPGRADE_TODO: Method 'java.util.Iterator.next' was converted to 'System.Collections.IEnumerator.Current' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilIteratornext'"
            String key = (String) it.Current;
            GdSs.Remove(key);
        }

        // reset GDS keys in products too
        for (int i = 0; i < Products.Count; i++)
        {
            Grib1Product g1P = (Grib1Product) Products[i];
            g1P.GDSkey = bestKey;
        }

        return;
    }
}