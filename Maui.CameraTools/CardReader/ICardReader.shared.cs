using Maui.CameraTools.CardReader.Models;
using Maui.CameraTools.Models;

namespace Maui.CameraTools.CardReader
{
    public interface ICardReader
    {
        CardReaderOptions Options { get; set; }
        CardDetectionResult Detect(PixelBufferHolder image);
    }
}
