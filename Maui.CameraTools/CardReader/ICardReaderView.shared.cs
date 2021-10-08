using System;
using Savi.Maui.CameraTools.CameraView;
using Savi.Maui.CameraTools.CardReader.Models;

namespace Savi.Maui.CameraTools.CardReader
{
    public interface ICardReaderView : ICameraView
    {
        CardReaderOptions Options { get; }

        event EventHandler<CardDetectionEventArgs> CardDetected;

        bool IsDetecting { get; set; }
    }
}
