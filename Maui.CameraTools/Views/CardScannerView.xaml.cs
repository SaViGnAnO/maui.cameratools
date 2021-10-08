using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Savi.Maui.CameraTools.CameraView;
using Microsoft.Maui.Controls;

namespace Savi.Maui.CameraTools.Views
{
    public partial class CardScannerView : ContentView
    {
        public CardScannerView()
        {
            InitializeComponent();
        }

        void SwitchCameraButton_Clicked(object sender, EventArgs e)
        {
            cameraView.CameraLocation = cameraView.CameraLocation == CameraLocation.Rear ? CameraLocation.Front : CameraLocation.Rear;
        }

        void TorchButton_Clicked(object sender, EventArgs e)
        {
            cameraView.IsTorchOn = !cameraView.IsTorchOn;
        }
    }
}