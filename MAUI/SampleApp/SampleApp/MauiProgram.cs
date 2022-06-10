using SampleApp.Controls;
using SampleApp.Handlers;

namespace SampleApp;

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
			})						
            .ConfigureMauiHandlers(handlers => 
			{
#if ANDROID
                handlers.AddHandler(typeof(TencentWebView), typeof(TencentWebViewHandler));
#endif
			});

		return builder.Build();
	}
}
