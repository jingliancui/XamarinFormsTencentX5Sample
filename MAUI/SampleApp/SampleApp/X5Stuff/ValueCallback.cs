#if ANDROID
using Com.Tencent.Smtt.Sdk;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.X5Stuff
{
#if ANDROID
    public class ValueCallback : Java.Lang.Object, IValueCallback
    {
        public void OnReceiveValue(Java.Lang.Object p0)
        {

        }
    }
#endif
}
