﻿using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Maui.CameraTools.CameraView
{
    public partial class CameraView : View, ICameraView
    {
        public event EventHandler<CameraFrameBufferEventArgs> FrameReady;

        protected override void OnHandlerChanging(HandlerChangingEventArgs args)
        {
            base.OnHandlerChanging(args);
            if (args.OldHandler is CameraViewHandler oldHandler)
                oldHandler.FrameReady -= Handler_FrameReady;

            if (args.NewHandler is CameraViewHandler newHandler)
                newHandler.FrameReady += Handler_FrameReady;
        }

        private void Handler_FrameReady(object sender, CameraFrameBufferEventArgs e)
            => FrameReady?.Invoke(this, e);

        public readonly BindableProperty IsTorchOnProperty =
            BindableProperty.Create(nameof(IsTorchOn), typeof(bool), typeof(CameraView), defaultValue: true);

        public bool IsTorchOn
        {
            get => (bool)GetValue(IsTorchOnProperty);
            set => SetValue(IsTorchOnProperty, value);
        }

        public readonly BindableProperty CameraLocationProperty =
            BindableProperty.Create(nameof(CameraLocation), typeof(CameraLocation), typeof(CameraView), defaultValue: CameraLocation.Rear);

        public CameraLocation CameraLocation
        {
            get => (CameraLocation)GetValue(CameraLocationProperty);
            set => SetValue(CameraLocationProperty, value);
        }

        public void AutoFocus()
            => StrongHandler?.Invoke(nameof(AutoFocus), null);

        public void Focus(Point point)
            => StrongHandler?.Invoke(nameof(Focus), point);

        private CameraViewHandler StrongHandler
            => Handler as CameraViewHandler;
    }
}
