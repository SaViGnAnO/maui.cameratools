namespace Maui.CameraTools.CardReader.Models
{
    public record CardDetectionResult
    {
        public byte[] Raw { get; set; }
        //public MtgSearchParams DetectedItems { get; set; }
    }
}
