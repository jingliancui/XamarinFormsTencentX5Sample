#if ANDROID
using Com.Tencent.Smtt.Export.External;
using Com.Tencent.Smtt.Sdk;
#endif
namespace SampleApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

#if ANDROID
        // 在调用TBS初始化、创建WebView之前进行如下配置
        var dic = new System.Collections.Generic.Dictionary<string, Java.Lang.Object>
        {
            { TbsCoreSettings.TbsSettingsUseSpeedyClassloader, true },
            { TbsCoreSettings.TbsSettingsUseDexloaderService, true },
        };
        QbSdk.InitTbsSettings(dic);
#endif

        MainPage = new AppShell();
	}
}
