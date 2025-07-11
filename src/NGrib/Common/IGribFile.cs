namespace NGrib.Common;

public interface IGribFile
{
    IGribMessage GetMessage(Stream stream);
}