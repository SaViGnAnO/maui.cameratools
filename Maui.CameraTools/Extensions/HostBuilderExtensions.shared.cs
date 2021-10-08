using Savi.Maui.CameraTools.CameraView;
using Savi.Maui.CameraTools.CardReader;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Savi.Maui.CameraTools.Extensions
{
    public static class CameraViewExtensions
    {
        public static MauiAppBuilder UseMauiCameraTools(this MauiAppBuilder builder)
        {
            builder.ConfigureMauiHandlers(handlers =>
                {
                    handlers.AddHandler(typeof(ICameraView), typeof(CameraViewHandler));
                });

            return builder;
        }

        //public static MauiAppBuilder UseCardReader(this MauiAppBuilder builder)
        //{
        //    builder.ConfigureMauiHandlers(handlers =>
        //    {
        //        handlers.AddHandler(typeof(ICameraView), typeof(CameraViewHandler));
        //        handlers.AddHandler(typeof(ICardReaderView), typeof(CardReaderViewHandler));
        //    });

        //    builder.Services.AddTransient<ICardReader, CardReader.CardReader>();

        //    return builder;
        //}

        //public static MauiAppBuilder UseCardReader<TCardReader>(this MauiAppBuilder builder) where TCardReader : class, ICardReader
        //{
        //    builder.ConfigureMauiHandlers(handlers =>
        //    {
        //        handlers.AddHandler(typeof(ICameraView), typeof(CameraViewHandler));
        //        handlers.AddHandler(typeof(ICardReaderView), typeof(CardReaderViewHandler));
        //    });

        //    builder.Services.AddTransient<ICardReader, TCardReader>();

        //    return builder;
        //}

    }
}