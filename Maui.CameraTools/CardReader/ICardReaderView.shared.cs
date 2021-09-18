using System;
using Maui.CameraTools.CameraView;
using Maui.CameraTools.CardReader.Models;

namespace Maui.CameraTools.CardReader
{
    public interface ICardReaderView : ICameraView
    {
        CardReaderOptions Options { get; }

        event EventHandler<CardDetectionEventArgs> CardDetected;

        bool IsDetecting { get; set; }
    }
}
