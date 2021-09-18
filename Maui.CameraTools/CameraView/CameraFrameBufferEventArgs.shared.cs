using System;
using Maui.CameraTools.Models;

namespace Maui.CameraTools.CameraView
{
    public class CameraFrameBufferEventArgs : EventArgs
    {
        public CameraFrameBufferEventArgs(PixelBufferHolder pixelBufferHolder) : base()
            => Data = pixelBufferHolder;

        public readonly PixelBufferHolder Data;
    }
}
