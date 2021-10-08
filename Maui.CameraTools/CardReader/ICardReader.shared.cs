using Savi.Maui.CameraTools.CardReader.Models;
using Savi.Maui.CameraTools.Models;

namespace Savi.Maui.CameraTools.CardReader
{
    public interface ICardReader
    {
        CardReaderOptions Options { get; set; }
        CardDetectionResult Detect(PixelBufferHolder image);
    }
}
