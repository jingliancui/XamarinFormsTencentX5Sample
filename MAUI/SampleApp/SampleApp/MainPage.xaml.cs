#if ANDROID
using Android.App;
using Com.Tencent.Smtt.Sdk;
#endif
using SampleApp.X5Stuff;

namespace SampleApp;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        WebViewBtn.IsEnabled = false;
        VideoBtn.IsEnabled = false;
        FileBtn.IsEnabled = false;

    }

    private void InitX5Env_Clicked(object sender, EventArgs e)
    {
        InitX5Env.IsEnabled = false;
#if ANDROID        

        //QbSdk.DownloadWithoutWifi = true;

        var tbsListener = new TencentTbsListener();
        tbsListener.DownloadProgress += (s, e) =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                CoreDownloadProgressLabel.Text = e.ToString();
            });            
        };
        tbsListener.DownloadFinished+= (s, e) =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                CoreDownloadFinishLabel.Text = e.ToString();
            });            
        };
        tbsListener.InstallFinished+= (s, e) => 
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                CoreInstallFinishLabel.Text = e.ToString();
            });            
        };

        var preInitCallback = new PreInitCallback();
        preInitCallback.CoreInitFinished += (s, e) => 
        {
        };
        preInitCallback.ViewInitFinished += (s, e) => 
        {
            if (e)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    WebViewBtn.IsEnabled = true;
                    VideoBtn.IsEnabled = true;
                    FileBtn.IsEnabled = true;
                    InitX5Env.IsEnabled = false;
                });
            }
        };
        QbSdk.SetTbsListener(tbsListener);

        var mainActivity = (Platform.CurrentActivity as MainActivity);

        QbSdk.InitX5Environment(mainActivity, preInitCallback);
#endif
    }


    private async void WebViewBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WebPage());        
    }

    private async void FileBtn_Clicked(object sender, EventArgs e)
    {
#if ANDROID

        var file = "excel.xlsx";
        
        var backingFile = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), file);
        //从Assets目录将文件复制到app目录
        if (System.IO.File.Exists(backingFile) == false)
        {            
            using var stream = await FileSystem.OpenAppPackageFileAsync(file);            
            using var newStream = System.IO.File.Create(backingFile);
            await stream.CopyToAsync(newStream);
        }
        var dic = new System.Collections.Generic.Dictionary<string, string>
        {
            {"local","true" }
        };

        var mainActivity = (Platform.CurrentActivity as MainActivity);

        var openResult = QbSdk.OpenFileReader(mainActivity, backingFile, dic, new ValueCallback());
#endif        
    }

    private void VideoBtn_Clicked(object sender, EventArgs e)
    {
#if ANDROID
        var mainActivity = (Platform.CurrentActivity as MainActivity);
        TbsVideo.OpenVideo(mainActivity, "http://vfx.mtime.cn/Video/2019/02/04/mp4/190204084208765161.mp4");
#endif
    }
}