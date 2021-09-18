using System;
using Maui.CameraTools.CameraView;
using Maui.CameraTools.CardReader.Models;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Maui.CameraTools.CardReader
{
    public partial class CardReaderView : View, ICardReaderView
    {
        public event EventHandler<CardDetectionEventArgs> CardDetected;
        public event EventHandler<CameraFrameBufferEventArgs> FrameReady;

        protected override void OnHandlerChanging(HandlerChangingEventArgs args)
        {
            base.OnHandlerChanging(args);
            if (args.OldHandler is CardReaderViewHandler oldHandler)
            {
                oldHandler.CardDetected -= Handler_CardDetected;
                oldHandler.FrameReady -= Handler_FrameReady;
            }

            if (args.NewHandler is CardReaderViewHandler newHandler)
            {
                newHandler.CardDetected += Handler_CardDetected;
                newHandler.FrameReady += Handler_FrameReady;
            }
        }

        void Handler_CardDetected(object sender, CardDetectionEventArgs e)
            => CardDetected?.Invoke(this, e);

        public static readonly BindableProperty OptionsProperty =
            BindableProperty.Create(nameof(Options), typeof(CardReaderOptions), typeof(CardReaderView),
                defaultValueCreator: bindableObj => new CardReaderOptions());

        public CardReaderOptions Options
        {
            get => (CardReaderOptions)GetValue(OptionsProperty);
            set => SetValue(OptionsProperty, value);
        }

        public static readonly BindableProperty IsDetectingProperty =
            BindableProperty.Create(nameof(IsDetecting), typeof(bool), typeof(CardReaderView),
                defaultValue: true);

        public bool IsDetecting
        {
            get => (bool)GetValue(IsDetectingProperty);
            set => SetValue(IsDetectingProperty, value);
        }

        void Handler_FrameReady(object sender, CameraFrameBufferEventArgs e)
            => FrameReady?.Invoke(this, e);

        public static readonly BindableProperty IsTorchOnProperty =
            BindableProperty.Create(nameof(IsTorchOn), typeof(bool), typeof(CardReaderView), defaultValue: true);

        public bool IsTorchOn
        {
            get => (bool)GetValue(IsTorchOnProperty);
            set => SetValue(IsTorchOnProperty, value);
        }

        public static readonly BindableProperty CameraLocationProperty =
            BindableProperty.Create(nameof(CameraLocation), typeof(CameraLocation), typeof(CardReaderView),
                defaultValue: CameraLocation.Rear);

        public CameraLocation CameraLocation
        {
            get => (CameraLocation)GetValue(CameraLocationProperty);
            set => SetValue(CameraLocationProperty, value);
        }

        public void AutoFocus()
            => StrongHandler?.Invoke(nameof(AutoFocus), null);

        public void Focus(Point point)
            => StrongHandler?.Invoke(nameof(Focus), point);

        CardReaderViewHandler StrongHandler
            => Handler as CardReaderViewHandler;
    }
}