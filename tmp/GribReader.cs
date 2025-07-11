using NGrib.Common;

namespace NGrib;

public class GribReader:IDisposable
{
    private readonly Stream _stream;
    private readonly bool _leaveOpen;
    private readonly CommonGribFile _common = new();
    public GribReader(Stream stream, bool leaveOpen = false)
    {
        _stream = stream;
        _leaveOpen = leaveOpen;
    }

    public IEnumerable<IGribMessage> GetMessages()
    {
        var position = _stream.Position;
        
        while(true)
        {
            var message = _common.GetMessage(_stream);
            if (message ==null)
                break;
            var positionInner = _stream.Position;
            yield return message;
            _stream.Seek(positionInner, SeekOrigin.Begin);
        };
        
        _stream.Position = position;
    }

    public void Dispose()
    {
        if (!_leaveOpen)
            _stream?.Dispose();
    }
}