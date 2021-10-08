using System;
using Savi.Maui.CameraTools.Models;

namespace Savi.Maui.CameraTools.CameraView
{
    public class CameraFrameBufferEventArgs : EventArgs
    {
        public CameraFrameBufferEventArgs(PixelBufferHolder pixelBufferHolder) : base()
            => Data = pixelBufferHolder;

        public readonly PixelBufferHolder Data;
    }
}
