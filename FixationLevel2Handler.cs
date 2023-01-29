using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metec.MVBDClient
{
    class FixationLevel2Handler : BaseFixationHandler
    {
        public string baseObj;

        public FixationLevel2Handler(string baseObj, FormDrawing form):base(form)
        {
            this.baseObj = baseObj;
        }

        public override void Init(bool isChangeView=false)
        {
            // TODO 语音打断
            // 1. welcome voice
            form.sendVoiceHandler(2, string.Format("欢迎探索小场景{0}", baseObj));
            // 2. send 3D voice
            form.sceneVoiceHandler(form._scene._data);
            // 3. overview
            form.sendVoiceHandler(2, form._scene.overview == null ? "" : form._scene.overview);
            // 4. self position
            var selfPosition = FormDrawing.GetRelativePosition(9999, form._scene);
            form.sendVoiceHandler(2, string.Format("我自己在{0}", selfPosition));
            form.lastSpokenTime = DateTimeOffset.Now;
        }

        public override string GetSceneName()
        {
            return string.Format("小场景{0}", baseObj);
        }

        public override void DoubleClickShape(ExtraInfo info)
        {
            if (info == null)
            {
                // double click empty, back to level 1
                form.sendVoiceHandler(2, string.Format("为您返回大场景{0}", form.currentFrame));
                string fileName = string.Format("scene_{0}_1.json", form.currentFrame);
                form.UpdateJsonFile(fileName);
                form._scene.current_suffix = 1;
                form._sceneHandler = new FixationLevel1Handler(form);
                form._sceneHandler.Init();
            }
        }

        public override void SendEmptyVoice()
        {
            var label = string.Format("您正在探索{0}", baseObj);
            form.sendVoiceHandler(2, label);
            form.lastSpokenTime = DateTimeOffset.Now;
        }
    }
}
