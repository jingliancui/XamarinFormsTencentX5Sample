using Com.Tencent.Smtt.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.X5Stuff
{
    public class PreInitCallback : Java.Lang.Object, QbSdk.IPreInitCallback
    {
        public event EventHandler CoreInitFinished;
        public event EventHandler<bool> ViewInitFinished;

        public void OnCoreInitFinished()
        {
            CoreInitFinished?.Invoke(this, null);
        }

        public void OnViewInitFinished(bool p0)
        {
            ViewInitFinished?.Invoke(this, p0);
        }
    }
}
