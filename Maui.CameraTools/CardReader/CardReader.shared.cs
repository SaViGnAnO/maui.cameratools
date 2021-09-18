using Maui.CameraTools.CardReader.Models;
using Maui.CameraTools.Models;

namespace Maui.CameraTools.CardReader
{
    public class CardReader : ICardReader
    {
        //CardReaderGeneric zxingReader;

        public CardReader()
        {
            //zxingReader = new CardReaderGeneric();
        }

        CardReaderOptions options;
        public CardReaderOptions Options
        {

            get => options ??= new CardReaderOptions();
            set
            {
                options = value;
                //zxingReader.Options.PossibleFormats = Options.Formats.ToZXingList();
                //zxingReader.Options.TryHarder = Options.TryHarder;
                //zxingReader.AutoRotate = Options.AutoRotate;
            }
        }

        public CardDetectionResult Detect(PixelBufferHolder image)
        {
            var w = (int)image.Size.Width;
            var h = (int)image.Size.Height;

//            LuminanceSource ls = default;

//#if ANDROID
//            ls = new ByteBufferYUVLuminanceSource(image.Data, w, h, 0, 0, w, h);
//#elif MACCATALYST || IOS
//			ls = new CVPixelBufferBGRA32LuminanceSource(image.Data, w, h);
//#endif

//            if (Options.Multiple)
//                return zxingReader.DecodeMultiple(ls)?.ToCardResults();

//            var b = zxingReader.Decode(ls)?.ToCardResult();
//            if (b != null)
//                return new[] { b };

            return null;
        }
    }
}
