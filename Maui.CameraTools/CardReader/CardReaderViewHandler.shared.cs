using System;
using Savi.Maui.CameraTools.CameraView;
using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;

namespace Savi.Maui.CameraTools.CardReader
{
    public partial class CardReaderViewHandler : ViewHandler<ICardReaderView, NativePlatformCameraPreviewView>
    {
        public static readonly PropertyMapper<ICardReaderView, CardReaderViewHandler> CardReaderViewMapper = new()
        {
            [nameof(ICardReaderView.Options)] = MapOptions,
            [nameof(ICardReaderView.IsDetecting)] = MapIsDetecting,
            [nameof(ICardReaderView.IsTorchOn)] = (handler, virtualView) => handler._cameraManager.UpdateTorch(virtualView.IsTorchOn),
            [nameof(ICardReaderView.CameraLocation)] = (handler, virtualView) => handler._cameraManager.UpdateCameraLocation(virtualView.CameraLocation)
        };

        public static CommandMapper<ICardReaderView, CardReaderViewHandler> CardReaderCommandMapper = new()
        {
            [nameof(ICardReaderView.Focus)] = MapFocus,
            [nameof(ICardReaderView.AutoFocus)] = MapAutoFocus,
        };

        public CardReaderViewHandler() : base(CardReaderViewMapper)
        {
        }

        public CardReaderViewHandler(PropertyMapper mapper = null) : base(mapper ?? CardReaderViewMapper)
        {
        }

        public event EventHandler<CardDetectionEventArgs> CardDetected;
        public event EventHandler<CameraFrameBufferEventArgs> FrameReady;

        private CameraManager _cameraManager;

        protected ICardReader CardReader
            => Services.GetService(typeof(ICardReader)) as ICardReader;

        protected override NativePlatformCameraPreviewView CreateNativeView()
        {
            if (_cameraManager == null)
                _cameraManager = new(MauiContext, VirtualView?.CameraLocation ?? CameraLocation.Rear);
            var v = _cameraManager.CreateNativeView();
            return v;
        }

        protected override async void ConnectHandler(NativePlatformCameraPreviewView nativeView)
        {
            base.ConnectHandler(nativeView);

            if (await CameraManager.CheckPermissions())
                _cameraManager.Connect();

            _cameraManager.FrameReady += CameraManager_FrameReady;
        }

        protected override void DisconnectHandler(NativePlatformCameraPreviewView nativeView)
        {
            _cameraManager.FrameReady -= CameraManager_FrameReady;

            _cameraManager.Disconnect();

            base.DisconnectHandler(nativeView);
        }

        private void CameraManager_FrameReady(object sender, CameraFrameBufferEventArgs e)
        {
            FrameReady?.Invoke(this, e);

            if (VirtualView.IsDetecting)
            {
                var card = CardReader.Detect(e.Data);

                CardDetected?.Invoke(this, new CardDetectionEventArgs(card));
            }
        }

        public static void MapOptions(CardReaderViewHandler handler, ICardReaderView cameraBarcodeReaderView)
            => handler.CardReader.Options = cameraBarcodeReaderView.Options;

        public static void MapIsDetecting(CardReaderViewHandler handler, ICardReaderView cameraBarcodeReaderView)
        { }

        public void Focus(Point point)
            => _cameraManager?.Focus(point);

        public void AutoFocus()
            => _cameraManager?.AutoFocus();

        public static void MapFocus(CardReaderViewHandler handler, ICardReaderView cameraBarcodeReaderView, object? parameter)
        {
            if (parameter is not Point point)
                throw new ArgumentOutOfRangeException(nameof(point), "Focus value is out of range");

            handler.Focus(point);
        }

        public static void MapAutoFocus(CardReaderViewHandler handler, ICardReaderView cameraBarcodeReaderView, object? parameters)
            => handler.AutoFocus();
    }
}
