using Microsoft.Maui.Graphics;

namespace Maui.CameraTools.Models
{
	public record PixelBufferHolder
	{
		public Size Size { get; init; }

		public

#if ANDROID
		Java.Nio.ByteBuffer
#elif IOS || MACCATALYST
		CoreVideo.CVPixelBuffer
#else
		byte[]
#endif

		Data
		{ get; init; }
	}
}
