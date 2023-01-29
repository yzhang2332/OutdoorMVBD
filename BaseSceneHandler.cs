using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metec.MVBDClient
{
    public class BaseSceneHandler
    {
        public FormDrawing form;
        public BaseSceneHandler(FormDrawing form)
        {
            this.form = form;
        }

        public virtual void Init(bool isChangeView=false)
        { }

        public virtual string GetSceneName()
        {
            return "";
        }

        public virtual void DoubleClickShape(ExtraInfo info)
        { }

        public virtual void ClickShape(ExtraInfo info)
        { }

        public virtual void ClickLine(ExtraInfo info)
        { }

        public virtual void ClickLineWithSelf(ExtraInfo info)
        { }

        public virtual void SendEmptyVoice()
        { }

        public virtual void Record(ExtraInfo info)
        { }

        public virtual void Refresh()
        { }

        public virtual void Stop()
        { }
    }
}
