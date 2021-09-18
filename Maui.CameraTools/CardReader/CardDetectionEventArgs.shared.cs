using System;
using Maui.CameraTools.CardReader.Models;

namespace Maui.CameraTools.CardReader
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
