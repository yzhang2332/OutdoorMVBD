using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metec.MVBDClient
{
    class BaseFixationHandler : BaseSceneHandler
    {
        public BaseFixationHandler(FormDrawing form) : base(form)
        {
        }

        public override void ClickShape(ExtraInfo info)
        {
            for (int i = 0; i < form._scene._data.Count(); i++)
            {
                // 1. flashing
                form._scene._data[i].isFlashing = form._scene._data[i].id == info.Id && form._scene._data[i].semantic_label > 0 ? true : false;
                // 2. show edge
                if (form._scene._data[i].type == 4)
                {
                    if (form._scene._data[i].source.Contains(info.Id))
                    {
                        form._scene._data[i].isValid = true;
                    }
                    else
                    {
                        form._scene._data[i].isValid = false;
                    }
                }
            }

            // scene note, flashing
            for (int i = 0; i < form._scene._scene_note.Count(); i++)
            {
                form._scene._scene_note[i].isFlashing = form._scene._scene_note[i].id == info.Id ? true : false;
            }

            // 3. caption voice
            // TODO: capture & name, shape & edge
            var label = info.Note == null || info.Id > 9999 ? info.Name : string.Format("{0}已录音", info.Name);
            form.sendVoiceHandler(2, label);
            form.lastSpokenTime = DateTimeOffset.Now;
        }

        public override void ClickLine(ExtraInfo info)
        {
            // 1. caption voice
            var obj1 = form._scene.obj_dict[info.Source[0]];
            var obj2 = form._scene.obj_dict[info.Source[1]];
            var label = string.Format("{0}与{1}{2}", obj1, obj2, info.Name);
            form.sendVoiceHandler(2, label);
            form.lastSpokenTime = DateTimeOffset.Now;
        }

        public override void ClickLineWithSelf(ExtraInfo info)
        {
            // 1. caption voice
            var position = FormDrawing.GetRelativePosition(info.Source[1], form._scene);
            var label = string.Format("{0}可以到达，在{1}", form._scene.obj_dict[info.Source[1]], position);
            form.sendVoiceHandler(2, label);
            form.lastSpokenTime = DateTimeOffset.Now;
        }

        public override void Record(ExtraInfo info)
        {
            SceneNote note = new SceneNote();
            if (info == null)
            {
                // scene note
                form.sendVoiceHandler(2, string.Format("录音将定位到大场景{0}", form.currentFrame));
                var noteCount = form._scene._scene_note.Count;
                if (noteCount == 0)
                {
                    note.id = 10000;
                }
                else
                {
                    note.id = form._scene._scene_note[noteCount - 1].id + 1;
                }
                note.name = string.Format("{0}第{1}条", GetSceneName(), note.id - 9999);
                note.t = DateTime.Now;
                note.recordName = form.recordName;
                note.imgName = "";
                note.jsonFileName = form.GetSceneFileName();
                form._scene._scene_note.Add(note);
            }
            else
            {
                // shape note
                form.sendVoiceHandler(2, string.Format("录音将定位到{0}", info.Name));
                note.id = info.Id;
                note.name = info.Name;
                note.t = DateTime.Now;
                note.recordName = form.recordName;
                note.imgName = "";
                note.jsonFileName = form.GetSceneFileName();
                for (int j = 0; j < form._scene._data.Count; j++)
                {
                    if (form._scene._data[j].id == info.Id)
                    {
                        form._scene._data[j].note = note;
                        break;
                    }
                }
            }
            SceneNote.save(form.GetNoteFileName(), form._scene);
            form.render_and_flush();
            if (info == null)
            {
                form.sendVoiceHandler(2, string.Format("大场景{0}第{1}条已录音", form.currentFrame, note.id - 9999));
            }
            else
            {
                form.sendVoiceHandler(2, string.Format("{0}已录音", info.Name));
            }
            form.recordingStatus = 0;
        }

        public override void Refresh()
        {
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
