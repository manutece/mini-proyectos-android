using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MiniProyectos.ProsperDaily.MVVM.Models;
using MiniProyectos.ProsperDaily.Repositories;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Syncfusion.Maui.Core.Hosting;

namespace MiniProyectos
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
            .UseMauiApp<App>().UseSkiaSharp().ConfigureSyncfusionCore().UseMauiCommunityToolkit().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Sublima-ExtraBold.otf", "SublimaBold");
                fonts.AddFont("Sublima-Light.otf", "SublimaLight");
                fonts.AddFont("Roboto-Regular.ttf", "Roboto");
                fonts.AddFont("Rubik-Light.ttf", "RubikLight");
                fonts.AddFont("Rubik-Regular.ttf", "Rubik");
                fonts.AddFont("Roboto-Black.ttf", "Strong");
                fonts.AddFont("LibreFranklin-Regular.ttf", "Regular");
            });

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fontello.ttf", "Icons");
                });

            builder.Services.AddSingleton<BaseRepository<Transaction>>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
