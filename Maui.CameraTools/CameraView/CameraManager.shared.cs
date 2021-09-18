#if IOS || MACCATALYST
global using NativePlatformCameraPreviewView = global::UIKit.UIView;
global using NativePlatformView = global::UIKit.UIView;
global using NativePlatformImageView = global::UIKit.UIImageView;
global using NativePlatformImage = global::UIKit.UIImage;
#elif ANDROID
global using NativePlatformCameraPreviewView = global::AndroidX.Camera.View.PreviewView;
global using NativePlatformView = global::Android.Views.View;
global using NativePlatformImageView = global::Android.Widget.ImageView;
global using NativePlatformImage = global::Android.Graphics.Bitmap;
#endif

using System;
using System.Threading.Tasks;
using Microsoft.Maui;

namespace Maui.CameraTools.CameraView
{
    public partial class CameraManager : IDisposable
    {
        public CameraManager(IMauiContext context, CameraLocation cameraLocation)
        {
            Context = context;
            CameraLocation = cameraLocation;
        }

        protected readonly IMauiContext Context;
#pragma warning disable 67
        public event EventHandler<CameraFrameBufferEventArgs> FrameReady;
#pragma warning restore 67

        public CameraLocation CameraLocation { get; private set; }

        public void UpdateCameraLocation(CameraLocation cameraLocation)
        {
            CameraLocation = cameraLocation;

            UpdateCamera();
        }

        public static async Task<bool> CheckPermissions()
            => (await Microsoft.Maui.Essentials.Permissions.RequestAsync<Microsoft.Maui.Essentials.Permissions.Camera>()) == Microsoft.Maui.Essentials.PermissionStatus.Granted;
    }
}
