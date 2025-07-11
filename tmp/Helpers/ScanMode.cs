namespace NGrib.Helpers;
/// <summary>
/// Adopted from JGribX
/// </summary>
public class ScanMode
{
    public bool IsXIncrement { get; set; }

    public bool IsYIncrement { get; set; }

    public bool IsNortherly { get; set; }

    public bool RowsZigzag { get; set; }

    public bool IsXDirectionEvenOffset { get; set; }
    
    public bool IsXDirectionOddRowsOffset { get; set; }

    public bool IsYDirectionOffset { get; set; }

    public bool RowsNxNyPoints { get; set; }
    public ScanMode(int formatCode)
    {
        IsXIncrement = formatCode.GetBit(3);
        IsYIncrement = formatCode.GetBit(4);
        IsNortherly = formatCode.GetBit(5);
    }
}