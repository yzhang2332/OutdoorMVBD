using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metec.MVBDClient
{
    public class BaseSceneHandler
    {
        public SceneData _scene;
        public BaseSceneHandler(SceneData scene)
        {
            this._scene = scene;
        }

        public virtual string GetOverview()
        {
            return this._scene.overview == null ? "" : this._scene.overview;
        }

        public virtual string GetRemindText()
        {
            return "";
        }
    }
}
