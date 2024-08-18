using DiccionarioDeVerbos.Infrastructure;
using DiccionarioDeVerbos.Services;
using DiccionarioDeVerbos.ViewModels;
using DiccionarioDeVerbos.Views;

namespace DiccionarioDeVerbos
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddHttpClient<IVerbs, Verbs>(client =>
            {
                client.BaseAddress = new Uri("https://api-verbs-dictionary.onrender.com/");
            });
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainViewModel>();
            return builder.Build();
        }
    }
}
