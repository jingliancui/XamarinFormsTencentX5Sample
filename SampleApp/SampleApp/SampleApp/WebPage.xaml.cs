using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebPage : ContentPage
    {
        public const string OnViewInitFinished = "OnViewInitFinished";
        public const string OnDownloadFinish = "OnDownloadFinish";
        public const string OnDownloadProgress = "OnDownloadProgress";
        public const string OnInstallFinish = "OnInstallFinish";
        public const string InitX5 = "InitX5";
        public const string PlayVideo = "PlayVideo";
        public const string OpenFile = "OpenFile";
        public WebPage()
        {
            InitializeComponent();
        }
    }


}