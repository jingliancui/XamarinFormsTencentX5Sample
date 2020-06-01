using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Tencent.Smtt.Sdk;
using Xamarin.Forms;
using Com.Tencent.Smtt.Export.External.Extension.Interfaces;
using System.Collections;
using Java.Util;
using Com.Tencent.Smtt.Export.External;
using Android.Content;
using Java.IO;
using System.IO;

namespace SampleApp.Droid
{
    [Activity(Label = "SampleApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private PreInitCallback preInitCallback;
        private TbsListener tbsListener;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            preInitCallback = new PreInitCallback();
            tbsListener = new TbsListener();
            MessagingCenter.Subscribe<object>(this, WebPage.InitX5, o =>
            {
                //QbSdk.DownloadWithoutWifi = true;            
                QbSdk.SetTbsListener(tbsListener);
                QbSdk.InitX5Environment(this, preInitCallback);
            });
            MessagingCenter.Subscribe<object>(this, WebPage.PlayVideo, o =>
            {
                TbsVideo.OpenVideo(this, "http://vfx.mtime.cn/Video/2019/02/04/mp4/190204084208765161.mp4");
            });
            MessagingCenter.Subscribe<object>(this, WebPage.OpenFile,async o =>
            {                 
                var backingFile = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "excel.xlsx");
                if (System.IO.File.Exists(backingFile)==false)
                {
                    using (var stream = Assets.Open("excel.xlsx"))
                    {                        
                        using (var newStream = System.IO.File.Create(backingFile))
                        {
                            await stream.CopyToAsync(newStream);
                        }                        
                    }
                }
                var openResult = QbSdk.OpenFileReader(this, backingFile, null, new ValueCallback());                            
            });
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class ValueCallback : Java.Lang.Object, IValueCallback
    {
        public void OnReceiveValue(Java.Lang.Object p0)
        {
            
        }
    }

    public class TbsListener : Java.Lang.Object, ITbsListener
    {        
        public void OnDownloadFinish(int p0)
        {
            MessagingCenter.Send(new object(), WebPage.OnDownloadFinish,p0);            
        }

        public void OnDownloadProgress(int p0)
        {
            MessagingCenter.Send(new object(), WebPage.OnDownloadProgress,p0);
        }

        public void OnInstallFinish(int p0)
        {
            MessagingCenter.Send(new object(), WebPage.OnInstallFinish,p0);
        }
    }
    public class PreInitCallback : Java.Lang.Object, QbSdk.IPreInitCallback
    {
        public void OnCoreInitFinished()
        {
        }

        public void OnViewInitFinished(bool p0)
        {
            if (p0)
            {
                MessagingCenter.Send(new object(), WebPage.OnViewInitFinished);
            }
        }
    }
}