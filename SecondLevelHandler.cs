using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metec.MVBDClient
{
    class SecondLevelHandler : BaseSceneHandler
    {
        public string baseObj;
        public SecondLevelHandler(SceneData scene, string baseObj):base(scene)
        {
            this.baseObj = baseObj;
        }

        public override string GetOverview()
        {
            string overview = string.Format(PARAMS.VOICE_WELCOME, this.baseObj);
            var selfPosition = FormDrawing.GetRelativePosition(9999, _scene);
            overview += string.Format(PARAMS.VOICE_SELF_POSITION, selfPosition);
            return overview;
        }

        public override string GetRemindText()
        {
            return string.Format(PARAMS.VOICE_CURRENT_SCENE, this.baseObj);
        }
    }
}
