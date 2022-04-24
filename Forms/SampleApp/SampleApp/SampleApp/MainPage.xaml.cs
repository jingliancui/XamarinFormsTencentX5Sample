using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SampleApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            WebViewBtn.IsEnabled = false;
            VideoBtn.IsEnabled = false;
            FileBtn.IsEnabled = false;

            MessagingCenter.Subscribe<object>(this, WebPage.OnViewInitFinished, (s) => 
            {
                Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() => 
                {
                    LoadCoreLabel.Text = "内核加载完成";
                    WebViewBtn.IsEnabled = true;
                    VideoBtn.IsEnabled = true;
                    FileBtn.IsEnabled = true;
                });
            });
            MessagingCenter.Subscribe<object,int>(this, WebPage.OnDownloadProgress, (s,args) =>
            {
                Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() =>
                {
                    CoreDownloadProgressLabel.Text = $"正在下载内核{args}";
                });
            });
            MessagingCenter.Subscribe<object,int>(this, WebPage.OnDownloadFinish, (s,args) =>
            {
                Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() =>
                {
                    CoreDownloadFinishLabel.Text = $"内核下载完成{args}";
                });
            });
            MessagingCenter.Subscribe<object,int>(this, WebPage.OnInstallFinish, (s,args) =>
            {
                Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() =>
                {
                    CoreInstallFinishLabel.Text = $"内核安装完成{args}";
                });
            });
        }

        private async void WebViewBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WebPage());
        }

        private void InitX5Env_Clicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;
            MessagingCenter.Send(new object(), WebPage.InitX5);
        }

        private void VideoBtn_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(new object(), WebPage.PlayVideo);
        }

        private void FileBtn_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(new object(), WebPage.OpenFile);
        }
    }
}
