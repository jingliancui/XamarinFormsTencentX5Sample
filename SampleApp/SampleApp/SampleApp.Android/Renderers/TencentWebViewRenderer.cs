using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Tencent.Smtt.Sdk;
using SampleApp.Controls;
using SampleApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TencentWebView), typeof(TencentWebViewRenderer))]
namespace SampleApp.Droid.Renderers
{
    public class TencentWebViewRenderer:ViewRenderer<TencentWebView, Android.Widget.RelativeLayout>
    {
        public TencentWebViewRenderer(Context context) : base(context)
        {

        }

        private Android.Widget.RelativeLayout mRelativeLayout;
        private Com.Tencent.Smtt.Sdk.WebView tencentWebView;
        protected override void OnElementChanged(ElementChangedEventArgs<TencentWebView> e)
        {
            mRelativeLayout = Inflate(Context,Resource.Layout.WebViewLayout,null) as Android.Widget.RelativeLayout;

            tencentWebView = mRelativeLayout.FindViewById<Com.Tencent.Smtt.Sdk.WebView>(Resource.Id.forum_context);
            tencentWebView.Settings.JavaScriptCanOpenWindowsAutomatically = true;
            //x变量非null表示启用x5内核成功
            var x = tencentWebView.X5WebViewExtension;
            tencentWebView.SetMinimumWidth(100);
            tencentWebView.SetMinimumHeight(800);
            SetNativeControl(mRelativeLayout);
            //tencentWebView.LoadUrl("http://soft.imtt.qq.com/browser/tes/feedback.html");
            tencentWebView.LoadUrl("https://www.qq.com");
            //tencentWebView.LoadUrl("https://debugtbs.qq.com");

        }

    }    
}