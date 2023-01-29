using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Metec.MVBDClient
{
    class GlanceHandler : BaseSceneHandler
    {
        bool refresh = false;
        Thread glanceThread;
        public GlanceHandler(FormDrawing form) : base(form)
        {
        }

        public override void Init(bool isChangeView = false)
        {
            if (isChangeView)
            {
                // 1. send 3D voice
                form.sceneVoiceHandler(form._scene._data);
                // 2. overview
                form.sendVoiceHandler(2, form._scene.overview == null ? "" : form._scene.overview);
            }

            ThreadStart glanceThreadRef = new ThreadStart(GlanceThread);
            glanceThread = new Thread(glanceThreadRef);
            glanceThread.Start();
        }

        public override void Refresh()
        {
            refresh = true;
        }

        public override void Stop()
        {
            glanceThread.Abort();
            for (int i = 0; i < form._scene._data.Count; i++)
            {
                form._scene._data[i].isFlashing = false;
                if (form._scene._data[i].type == 4)
                {
                    form._scene._data[i].isValid = false;
                }
            }
        }

        private void GlanceThread()
        {
            while (true)
            {
                int lastFlashing = -1;
                int voiceLength = 0;
                for (int i = 0; i < form._scene._data.Count; i++)
                {
                    if (refresh)
                    {
                        refresh = false;
                        break;
                    }
                    var info = form._scene._data[i];
                    // ignore myself
                    if (info.type == 3 && info.id != 9999)
                    {
                        // 1. send captioning voice 
                        form.sendVoiceHandler(2, info.name);
                        voiceLength = info.name.Length;
                        // 2. flashing
                        if (lastFlashing > -1)
                        {
                            form._scene._data[lastFlashing].isFlashing = false;
                        }
                        form._scene._data[i].isFlashing = true;
                        lastFlashing = i;
                        // 3. show edge and send reachable voice
                        for (int j = 0; j < form._scene._data.Count; j++)
                        {
                            var edgeInfo = form._scene._data[j];
                            if (edgeInfo.type == 4)
                            {
                                if (edgeInfo.source.Contains(info.id))
                                {
                                    // 3.1 show edge
                                    form._scene._data[j].isValid = true;
                                    // 3.2 send reachable voice
                                    if (edgeInfo.source.Contains(9999))
                                    {
                                        var position = FormDrawing.GetRelativePosition(edgeInfo.source[1], form._scene);
                                        var label = string.Format("{0}可以到达，在{1}", form._scene.obj_dict[edgeInfo.source[1]], position);
                                        form.sendVoiceHandler(2, label);
                                        voiceLength += label.Length;
                                    }
                                }
                                else
                                {
                                    form._scene._data[j].isValid = false;
                                }
                            }
                        }
                        // 4. wait for voice finished
                        form.render_and_flush();
                        Thread.Sleep(voiceLength / 2 * 1000);
                    }
                }
                // refresh
                refresh = false;
                if (form.hasUpdatedFrame)
                {
                    form.sendVoiceHandler(2, "已刷新场景");
                    form.currentFrame++;
                    form.hasUpdatedFrame = false;
                }
                int file_suffix = 1;
                string fileName = string.Format("scene_{0}_{1}.json", form.currentFrame, file_suffix);
                form.UpdateJsonFile(fileName);
                form._scene.current_suffix = file_suffix;
            }
        }
    }
}
