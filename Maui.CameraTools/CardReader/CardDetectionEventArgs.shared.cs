using System;
using Savi.Maui.CameraTools.CardReader.Models;

namespace Savi.Maui.CameraTools.CardReader
{
    public class CardDetectionEventArgs : EventArgs
    {
        public CardDetectionEventArgs(CardDetectionResult results)
            : base()
        {
            Results = results;
        }

        public CardDetectionResult Results { get; private set; }
    }
}
