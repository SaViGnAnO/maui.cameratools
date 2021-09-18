﻿using System;
using Microsoft.Maui;
using Microsoft.Maui.Graphics;

namespace Maui.CameraTools.CameraView
{
    public interface ICameraFrameAnalyzer
    {
        event EventHandler<CameraFrameBufferEventArgs> FrameReady;
    }

    public interface ICameraView : IView, ICameraFrameAnalyzer
    {
        CameraLocation CameraLocation { get; set; }

        void AutoFocus();

        void Focus(Point point);

        bool IsTorchOn { get; set; }
    }
}
