namespace NGrib.Common;

public interface IGribMessage
{
    DateTime Time { get; }

    string Name { get; }

    IEnumerable<KeyValuePair<Coordinate, double?>> GetData();
    
    int Version { get; }
    //int ParameterNumber { get; set; }
    
    int ParameterHash { get; }
}