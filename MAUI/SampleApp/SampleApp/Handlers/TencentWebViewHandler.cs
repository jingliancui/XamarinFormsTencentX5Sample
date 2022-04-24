using Android.Views;
using Android.Widget;
using Microsoft.Maui.Handlers;
using SampleApp.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Handlers
{
    public class TencentWebViewHandler : ViewHandler<TencentWebView, Com.Tencent.Smtt.Sdk.WebView>
    {
        public static PropertyMapper Mapper = new PropertyMapper<TencentWebView>();

        public TencentWebViewHandler() : base(Mapper)
        {
        }

        protected override Com.Tencent.Smtt.Sdk.WebView CreatePlatformView()
        {            
            var view=new Com.Tencent.Smtt.Sdk.WebView(Context);
            view.Settings.JavaScriptCanOpenWindowsAutomatically = false;
            //x5object变量非null表示启用x5内核成功
            var x5object = view.X5WebViewExtension;
#if ANDROID
            if (x5object!=null)
            {
                Toast.MakeText(Context, "X5WebViewExtension对象不为null，此为x5webview", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(Context, "X5WebViewExtension对象为null，此为系统自带webview", ToastLength.Long).Show();
            }
#endif
            view.SetMinimumWidth(200);
            view.SetMinimumHeight(100);
            view.LoadUrl("https://www.qq.com");            
            return view;
        }
    }
}
