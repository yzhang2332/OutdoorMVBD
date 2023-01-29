using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metec.MVBDClient
{
    class FixationLevel1Handler : BaseFixationHandler
    {

        public FixationLevel1Handler(FormDrawing form):base(form)
        {
        }

        public override void Init(bool isChangeView=false)
        {
            if (isChangeView)
            {
                // TODO 语音打断
                // 1. send 3D voice
                form.sceneVoiceHandler(form._scene._data);
                // 2. welcome voice
                form.sendVoiceHandler(2, string.Format("欢迎探索大场景{0}", form.currentFrame));
                // 3. overview
                form.sendVoiceHandler(2, form._scene.overview == null ? "" : form._scene.overview);
                form.lastSpokenTime = DateTimeOffset.Now;
            }
        }

        public override string GetSceneName()
        {
            string label = "";
            for (int i = 0; i < form._scene._data.Count; i++)
            {
                if (form._scene._data[i].type == 3)
                {
                    label = form._scene._data[i].name;
                    break;
                }
            }
            return string.Format("大场景{0}", label);
        }

        public override void DoubleClickShape(ExtraInfo info)
        {
            if (info != null)
            {
                string fileName = string.Format("scene_{0}_{1}.json", form.currentFrame, info.SemanticLabel);
                form.UpdateJsonFile(fileName);
                form._scene.current_suffix = info.SemanticLabel;
                form._sceneHandler = new FixationLevel2Handler(info.Name, form);
                form._sceneHandler.Init();
            }
        }
    }
}
