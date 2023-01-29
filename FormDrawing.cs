﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Linq;
using log4net.Config;
using log4net;
using log4net.Appender;

namespace Metec.MVBDClient
{
    // python method
    // text speaker
    public delegate void SendVoice(int type, string label);
    // background speaker
    public delegate void SceneVoice(List<SceneInst> data);
    // recorder
    public delegate void Record(int type, string name);    // 1 - record start, 2 - record stop

    public delegate void UpdateJsonFile(string fileName);

    public partial class FormDrawing : Form
    {
        protected MVBDConnection _con;
        bool isListening;
        int px, py; // finger position
        NotificationsMask mask;
        string ip;

        public SceneData _scene;
        public BaseSceneHandler _sceneHandler;
        bool flashingShow;
        public SendVoice sendVoiceHandler;
        public SceneVoice sceneVoiceHandler;
        public Record recordHandler;

        public int currentFrame = 1;
        public bool hasUpdatedFrame = false;
        public string filePrefix = "{0}/scene_{1}/";
        public string expFolder = "";

        string[] scene_paths;

        public ILog logger;

        public FormDrawing()
        {
            InitLog();
            InitializeComponent();
        }

        public FormDrawing(string ip)
        {
            this.ip = ip;
            this.flashingShow = true;
            this.sendVoiceHandler = SendVoice;
            this.sceneVoiceHandler = SceneVoice ;
            this._sceneHandler = new BaseSceneHandler(this);
            this.recordHandler = Record;
            InitLog();
            InitializeComponent();
        }

        public FormDrawing(string ip, SendVoice sendVoiceHandler, SceneVoice sceneVoiceHandler = null, Record recordHandler = null)
        {
            this.ip = ip;
            this.flashingShow = true;
            this.sendVoiceHandler = sendVoiceHandler;
            this.sceneVoiceHandler = sceneVoiceHandler;
            this.recordHandler = recordHandler;
            this._sceneHandler = new BaseSceneHandler(this);
            InitLog();
            InitializeComponent();
        }

        private void InitLog()
        {
            var configPath = new System.IO.FileInfo(System.IO.Directory.GetCurrentDirectory() + "/log4net.config");
            XmlConfigurator.Configure(configPath);
            this.logger = LogManager.GetLogger(typeof(FormDrawing));
            string path1 = (LogManager.GetCurrentLoggers()[0].Logger.Repository.GetAppenders()[0] as FileAppender).File;
            Console.WriteLine(path1);
        }

        private void FormDrawings_Load(object sender, EventArgs e)
        {
            if (ip != null)
            {
                _con = new MVBDConnection(this, ip, 2018);
            }
            else {
                _con = new MVBDConnection(this);
            }

            _con.FingerChanged += _con_FingerChanged;
            _con.KeyDown += _con_KeyDown;
            _con.KeyUp += _con_KeyUp;
            _con.KeyboardKeyDown += _con_KeyboardKeyDown;

            mask = NotificationsMask.Fingers | NotificationsMask.KeyDown | NotificationsMask.KeyUp | NotificationsMask.KeyboardKeyUp | NotificationsMask.KeyboardKeyDown;

            px = -1;
            py = -1;

            isListening = false;

            // DEBUG
            txtPath.Text = "scene_1.json";
            scene_paths = new string[10];
            scene_paths[0] = "scene_1.json";
            scene_paths[1] = "scene_2.json";
            scene_paths[2] = "scene_3.json";
            scene_paths[3] = "scene_4.json";
            scene_paths[4] = "scene_5.json";
            scene_paths[5] = "scene_6.json";
            scene_paths[6] = "scene_7.json";
            scene_paths[7] = "scene_8.json";
            scene_paths[8] = "scene_9.json";

            // _scene = new SceneData();
        }

        private void FormDrawings_Shown(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        public void render_and_flush()
        {
            if (_scene == null)
            {
                Console.WriteLine("Exception: " + "scene is empty, load before drawing.");
                return;
            }
            if (_con.IsConnected() == false)
            {
                Console.WriteLine("Exception: " + "MVBD not connected.");
                return;
            }
            _scene.render(_con.VirtualDevice.Pins.Array_extra, _con.PinCountX, _con.PinCountY);
            SceneData.flush(_con.VirtualDevice.Pins.Array_extra, _con.VirtualDevice.Pins.Array, _con.PinCountX, _con.PinCountY, flashingShow);
            _con.SendPins();
        }

        public DateTimeOffset lastSpokenTime;

        private void tmrStatus_Tick(object sender, EventArgs e)
        {
            // Status;
            string status;

            if (_con.IsConnected() == true)
            {
                status = String.Format("Connected at {0}, Width={1}, Height={2}, Position={3}", _con.LocalEndPoint, _con.PinCountX, _con.PinCountY, _con.WorkingPosition);
                if (isListening == false)
                {
                    isListening = true;
                    _con.SendSetNotificationsMask(mask, isListening);
                }

                if (_scene == null)
                {
                    _scene = SceneData.load(txtPath.Text);
                    render_and_flush();
                }

            }
            else
            {
                status = "Not connected";
            }

            if (status != lblStatus.Text) lblStatus.Text = status;

            if (chkEnableIMU.Checked && spSerialPort.IsOpen == false)
            {
                PortOpen();
            }
        }


        /// <summary>Buttons Draw...</summary>
        private void btnDraw_Click(object sender, EventArgs e)
        {
            // 1. Clear all pins
            if (chkPinsAutoClear.Checked == true)
            {
                _con.SendPinsClear();
            }


            // 2. Draw something
            Random rnd = new Random();

            if (sender == btnPinsDrawRectangle)
            {
                _con.SendPinsDrawRectangle(rnd.Next(0, 20), rnd.Next(0, 20), 20, 10);
            }

            else if (sender == btnPinsDrawLine)
            {
                _con.SendPinsDrawLine(0, rnd.Next(0, 20), _con.PinCountX - 1, rnd.Next(20, 40));
            }

            else if (sender == btnPinsDrawPolygon)
            {
                Point[] points = new Point[4];

                points[0] = new Point(rnd.Next(0, 7), 20);
                points[1] = new Point(rnd.Next(10, 50), 40);
                points[2] = new Point(rnd.Next(60, 65), 20);
                points[3] = new Point(rnd.Next(0, 70), 2);

                _con.SendPinsDrawPolygon(points);
            }

            else if (sender == btnPinsDrawCircle)
            {
                _con.SendPinsDrawCircle(rnd.Next(20, 40), rnd.Next(20, 30), rnd.Next(10, 20));
            }



            // 3. Flush it to show it in the MVBD
            if (chkPinsAutoFlush.Checked == true)
            {
                _con.SendPinsFlush();
            }

        }

        /// <summary>Send Pins Clear manual</summary>
        private void btnPinsClear_Click(object sender, EventArgs e)
        {
            _con.SendPinsClear();
        }

        /// <summary>Send Pins Flush manual</summary>
        private void btnPinsFlush_Click(object sender, EventArgs e)
        {
            _con.SendPinsFlush();
        }


        /// <summary>Send with Enter</summary>
        private void txtSpeakText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSpeakText_Click(null, null);
            }
        }

        /// <summary>Speak a short text</summary>
        private void btnSpeakText_Click(object sender, EventArgs e)
        {
            _con.SendSpeakText(txtSpeakText.Text);
        }

        private void chkIsListening_CheckedChanged(object sender, EventArgs e)
        {
            isListening = chkIsListening.Checked;
            _con.SendSetNotificationsMask(mask, isListening);
        }

        /// <summary>Make an entry in the event listbox</summary>
        private void AddToList(string name, object value)
        {
            this.Invoke(new EventHandler(delegate {
                if (chkPrintEvents.Checked)
                {
                    int index = lstEvents.Items.Add(String.Format("{0} {1}", name, value));
                    lstEvents.SelectedIndex = index;
                }
            }));
        }

        //private int last_pressed_id;
        private int[] last_pressed_x = new int[10];
        private int[] last_pressed_y = new int[10];
        private int[] double_click_stage = new int[10];
        private DateTimeOffset last_double_click_time;
        private DateTimeOffset[] last_pressed_time = new DateTimeOffset[10];
        void _con_FingerChanged(object sender, MVBDFingerEventArgs e)
        {
            AddToList("Finger:      ", e.Finger);
            if (e.Finger.IsPressed)
            {
                px = e.Finger.PX;
                py = e.Finger.PY;
            }

            ExtraInfo info = _scene.get_extra_info(_con.VirtualDevice.Pins.Array_extra, _con.PinCountX, _con.PinCountY, px, py);

            if (e.Finger.IsPressed)
            {
                // handle click
                if (info == null)
                {
                    // do nothing
                }
                else if (info.Type == 3)
                {
                    // click shape
                    _sceneHandler.ClickShape(info);
                    render_and_flush();
                }
                else if (info.Type == 4 && info.Source != null)
                {
                    // click line
                    if (info.Source[0] == 9999)
                    {
                        // self - obj
                        _sceneHandler.ClickLineWithSelf(info);
                        render_and_flush();
                    }
                    else
                    {
                        // obj - obj
                        _sceneHandler.ClickLine(info);
                        render_and_flush();
                    }
                }

                // update double click status
                int i = e.Finger.Index;
                is_double_click(i, px, py, e.Finger.IsPressed);
                last_pressed_x[i] = px;
                last_pressed_y[i] = py;
                last_pressed_time[i] = DateTimeOffset.Now;
            }
            else
            {
                int i = e.Finger.Index;
                if (is_double_click(i, e.Finger.PX, e.Finger.PY, e.Finger.IsPressed))
                {
                    int shapeId = info == null ? PARAMS.BLANK_ID : info.Id;
                    AddToList("Double clicked:      ", shapeId);
                    DateTimeOffset now = DateTimeOffset.Now;
                    if (info == null || info.Type == 3)
                    {
                        if (recordingStatus == 2)
                        {
                            _sceneHandler.Record(info);
                        }
                        else 
                        {
                            var tmpScenePrefix = _scene.current_suffix;
                            _sceneHandler.DoubleClickShape(info);
                            if (tmpScenePrefix != _scene.current_suffix)
                            {
                                // scene changed, log
                                // TODO: img url
                                var imgUrl = "tmp";
                                LogCurrentStatus(Angle[2].ToString("f2"), imgUrl, txtPath.Text, "Fixation explore");
                            }
                            last_double_click_time = DateTimeOffset.Now;
                        }
                    }
                }
            }
        }

        private bool is_double_click(int i, int x, int y, bool is_pressed)
        {
            switch (double_click_stage[i])
            {
                case 0:
                    // first leave
                    if (!is_pressed && is_near(x, y, last_pressed_x[i], last_pressed_y[i]) && DateTimeOffset.Now.Subtract(last_pressed_time[i]).TotalMilliseconds < PARAMS.LONG_PRESS)
                    {
                        double_click_stage[i]++;
                    }
                    return false;
                case 1:
                    // second press
                    if (is_pressed && is_near(x, y, last_pressed_x[i], last_pressed_y[i]))
                    {
                        double delta = DateTimeOffset.Now.Subtract(last_pressed_time[i]).TotalMilliseconds;
                        if (delta < PARAMS.LONG_PRESS)
                        {
                            // multi click donnot trigger twice
                            if (DateTimeOffset.Now.Subtract(last_double_click_time).TotalMilliseconds > 1000)
                            {
                                double_click_stage[i]++;
                                return false;
                            }
                        }
                    }
                    double_click_stage[i] = 0;
                    return false;
                case 2:
                    // second leave
                    if (!is_pressed && is_near(x, y, last_pressed_x[i], last_pressed_y[i]) && DateTimeOffset.Now.Subtract(last_pressed_time[i]).TotalMilliseconds < PARAMS.LONG_PRESS)
                    {
                        double_click_stage[i] = 0;
                        return true;
                    }
                    double_click_stage[i] = 0;
                    return false;
            }
            return false;
        }

        private bool is_near(int x, int y, int target_x, int target_y)
        {
            if (Math.Abs(x - target_x) < PARAMS.DOUDBLE_CLICK_THRES && Math.Abs(y - target_y) < PARAMS.DOUDBLE_CLICK_THRES)
            {
                return true;
            }
            return false;
        }

        /// <summary>Event Keyboard key down (Cmd=66)</summary>
        void _con_KeyboardKeyDown(object sender, MVBDKeyEventArgs e)
        {
            int i = e.Key;
            string value = String.Format("0x{0:X2} {1,-3} {2}", i, i, (Keys)i);

            if ((Keys)i == Keys.E)
            {
                // RT
                if (_scene == null)
                {
                    Console.WriteLine("Exception: " + "scene is empty, load before drawing.");
                    return;
                }
                _scene.rot_right();
                render_and_flush();
            }
            else if ((Keys)i == Keys.Q)
            {
                // LT
                if (_scene == null)
                {
                    Console.WriteLine("Exception: " + "scene is empty, load before drawing.");
                    return;
                }
                _scene.rot_left();
                render_and_flush();
            }
            else if ((Keys)i >= Keys.D1 && (Keys)i <= Keys.D9)
            {
                // Reset
                _scene = SceneData.load(scene_paths[i - (int)Keys.D1]);
                _scene.print();
                render_and_flush();
            }
            else if ((Keys)i == Keys.Up)
            {
                // LT
                if (_scene == null)
                {
                    Console.WriteLine("Exception: " + "scene is empty, load before drawing.");
                    return;
                }
                _scene.move_up();
                render_and_flush();
            }
            else if ((Keys)i == Keys.Down)
            {
                // LT
                if (_scene == null)
                {
                    Console.WriteLine("Exception: " + "scene is empty, load before drawing.");
                    return;
                }
                _scene.move_down();
                render_and_flush();
            }
            else if ((Keys)i == Keys.Left)
            {
                // LT
                if (_scene == null)
                {
                    Console.WriteLine("Exception: " + "scene is empty, load before drawing.");
                    return;
                }
                _scene.move_left();
                render_and_flush();
            }
            else if ((Keys)i == Keys.Right)
            {
                // LT
                if (_scene == null)
                {
                    Console.WriteLine("Exception: " + "scene is empty, load before drawing.");
                    return;
                }
                _scene.move_right();
                render_and_flush();
            }
            AddToList("Keyboard KeyDown:     ", value);
        }

        public int recordingStatus = 0;
        public string recordName;
        public int removeRecordId = 0;
        /// <summary>Event key down</summary>
        void _con_KeyDown(object sender, MVBDKeyEventArgs e)
        {
            AddToList("KeyDown:     ", e.Key);
            if (_scene == null)
            {
                Console.WriteLine("Exception: " + "scene is empty, load before drawing.");
                return;
            }
            /**+: 226
               -: 227
               U: 216
               L: 217
               D: 218
               R: 219
               X: 220
               LT: 214
               RT: 222
               F1: 241
               F2: 242
               F3: 243
               F4: 244
               F5: 245
               F6: 246
               
               1-8: 200-207
            */
            if (e.Key == 226) // +: zoomin
            {
                _scene.zoom_in();
                render_and_flush();

            }
            else if (e.Key == 227) // -: zoom out
            {
                _scene.zoom_out();
                render_and_flush();
            }
            else if (e.Key == 216) // U: move view center
            {
                _scene.move_up();
                render_and_flush();
            }
            else if (e.Key == 217) // L: move view center
            {
                _scene.move_left();
                render_and_flush();
            }
            else if (e.Key == 218) // D: move view center
            {
                _scene.move_down();
                render_and_flush();
            }
            else if (e.Key == 219) // R: move view center
            {
                _scene.move_right();
                render_and_flush();
            }
            else if (e.Key == 214) // LT: rotate left
            {
                //_scene.rot_left();
                //render_and_flush();

                // TODO: mark
            }
            else if (e.Key == 222) // RT - start recording
            {
                if (_sceneHandler.GetType() == typeof(FixationLevel1Handler) || _sceneHandler.GetType() == typeof(FixationLevel2Handler))
                {
                    var imgUrl = "test";
                    LogCurrentStatus(Angle[2].ToString("f2"), imgUrl, txtPath.Text, "Fixation recording");
                    if (recordHandler != null)
                    {
                        recordingStatus = 1;
                        sendVoiceHandler(1, "请录音，嘀");
                        recordHandler(1, "");
                    }
                }
            }
            // TODO: test on machine to check actual behavior
            //else if (e.Key == 222 && recordingStatus == 1) // RT: rotate right
            //{
            //    // stop recording
            //    recordName = string.Format("{0}.wav", DateTime.Now);
            //    if (recordHandler != null)
            //    {
            //        recordHandler(2, recordName);
            //    }
            //    sendVoiceHandler(2, "请选择录音定位");
            //    recordingStatus = 2;
            //}
            else if (e.Key == 241) // F1: mode0
            {
                // refresh
                _sceneHandler.Refresh();
            }
            else if (e.Key == 242) // F2: mode1
            {
                //_scene.set_mode(1);
                //render_and_flush();

                // glance view
                var trans = new Tuple<Type, Type>(_sceneHandler.GetType(), typeof(GlanceHandler));
                if (PARAMS.ViewTransList.Contains(trans))
                {
                    _sceneHandler.Stop();
                    _sceneHandler = new GlanceHandler(this);
                    _sceneHandler.Init(true);
                }
            }
            else if (e.Key == 220)
            {
                render_and_flush();
            }
            else if (e.Key == 207)
            {
                // render_and_flush();

                // play record
                ExtraInfo info = _scene.get_extra_info(_con.VirtualDevice.Pins.Array_extra, _con.PinCountX, _con.PinCountY, px, py);
                if ( info != null && info.Note != null)
                {
                    recordHandler(3, info.Note.recordName);
                }
            }
            else if (e.Key == 206)
            {
                render_and_flush();
            }
            else if (e.Key == 243)
            {
                // change to fixation
                var trans = new Tuple<Type, Type>(_sceneHandler.GetType(), typeof(FixationLevel1Handler));
                if (PARAMS.ViewTransList.Contains(trans))
                {
                    this._sceneHandler.Stop();
                    this._sceneHandler = new FixationLevel1Handler(this);
                    // TODO: add img url
                    string imgUrl = "tmp";
                    LogCurrentStatus(Angle[2].ToString("f2"), imgUrl, txtPath.Text, "Fixation start");
                    this._sceneHandler.Init(true);
                }
            }
            else if (e.Key == 246)
            {
                // delete note
                ExtraInfo info = _scene.get_extra_info(_con.VirtualDevice.Pins.Array_extra, _con.PinCountX, _con.PinCountY, px, py);
                if (info != null && info.Note != null)
                {
                    if (removeRecordId == 0 || removeRecordId != info.Id)
                    {
                        sendVoiceHandler(2, string.Format("是否想要删除{0}录音", info.Note.name));
                        removeRecordId = info.Id;
                    }
                    else if (removeRecordId == info.Id)
                    {
                        if (removeRecordId > 9999)
                        {
                            for (int i = 0; i < _scene._scene_note.Count(); i++)
                            {
                                if (_scene._scene_note[i].id == removeRecordId)
                                {
                                    _scene._scene_note.RemoveAt(i);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < _scene._data.Count(); i++)
                            {
                                if (_scene._data[i].id == removeRecordId)
                                {
                                    _scene._data[i].note = null;
                                    break;
                                }
                            }
                        }
                        SceneNote.save(GetNoteFileName(), _scene);
                        sendVoiceHandler(2, string.Format("您已删除{0}录音", info.Note.name));
                        render_and_flush();
                    }
                }
            }
        }

        /// <summary>Event key up</summary>
        void _con_KeyUp(object sender, MVBDKeyEventArgs e)
        {
            AddToList("KeyUp:       ", e.Key);
            if (_scene == null)
            {
                Console.WriteLine("Exception: " + "scene is empty, load before drawing.");
                return;
            }
            /**+: 226
               -: 227
               U: 216
               L: 217
               D: 218
               R: 219
               X: 220
               LT: 214
               RT: 222
               F1: 241
               F2: 242
               F3: 243
               F4: 244
               F5: 245
               F6: 246
               
               1-8: 200-207
            */
            // TODO: recording
            //if (e.Key == 222) // RT - start recording
            //{
            //    var imgUrl = "test";
            //    LogCurrentStatus(Angle[2].ToString("f2"), imgUrl, txtPath.Text, "Fixation recording");
            //    if (recordHandler != null)
            //    {
            //        recordingStatus = 1;
            //        sendVoiceHandler(1, "请录音，嘀");
            //        recordHandler(1, "");
            //    }
            //}
            if (e.Key == 222 && recordingStatus == 1) // RT: rotate right
            {
                if (_sceneHandler.GetType() == typeof(FixationLevel1Handler) || _sceneHandler.GetType() == typeof(FixationLevel2Handler))
                {
                    // stop recording
                    recordName = string.Format("{0}.wav", DateTime.Now);
                    if (recordHandler != null)
                    {
                        recordHandler(2, recordName);
                    }
                    sendVoiceHandler(2, "请选择录音定位");
                    recordingStatus = 2;
                }
            }
        }

        private void btnDrawGrid_Click(object sender, EventArgs e)
        {
            // 
            int width = _con.PinCountX;
            int height = _con.PinCountY;
            int len_x = 5;
            int len_y = 10;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int grid_x = i / len_x;
                    int grid_y = j / len_y;
                    bool val = (grid_x % 2) == (grid_y % 2);
                    _con.VirtualDevice.Pins.Array[i, j] = val;
                }
            }

            _con.SendPins();
        }

        private void btnLoadScene_Click(object sender, EventArgs e)
        {
            //_scene._data.Add(new SceneInst());
            //_scene.save("A");
            // C:\Users\insan\Desktop\project\MVBDClient
            _scene = SceneData.load(txtPath.Text);
            _scene.print();
            render_and_flush();
        }

        private void btnDrawScene_Click(object sender, EventArgs e)
        {
            if (_scene == null)
            {
                Console.WriteLine("Exception: " + "scene is empty, load before drawing.");
                return;
            }
            render_and_flush();
        }

        private void btnClearBuffer_Click(object sender, EventArgs e)
        {
            int width = _con.PinCountX;
            int height = _con.PinCountY;
            SceneData.clear(_con.VirtualDevice.Pins.Array, width, height);
            SceneData.clear(_con.VirtualDevice.Pins.Array_extra, width, height);
            _con.SendPins();
        }


        // IMU

        // connection status
        private bool bListening = false;
        private bool bClosing = false;
        // data buffer
        delegate void UpdateData(byte[] byteData);
        byte[] RxBuffer = new byte[1000];
        UInt16 usRxLength = 0;
        // decoded data 
        private double[] LastTime = new double[10];
        short sRightPack = 0;
        short[] ChipTime = new short[7];
        private DateTime TimeStart = DateTime.Now;
        double[] a = new double[4], w = new double[4], h = new double[4], Angle = new double[4], Port = new double[4];
        double Temperature, Pressure, Altitude, GroundVelocity, GPSYaw, GPSHeight;

        private void chkEnableIMU_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableIMU.Checked == false)
            {
                PortClose(null, null);
            }
        }

        private void FormDrawing_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                PortClose(null, null);
            }
            catch { }
        }

        long Longitude, Latitude;

        public void PortClose(object sender, EventArgs e)
        {
            if (spSerialPort.IsOpen)
            {
                bClosing = true;
                while (bListening) { Application.DoEvents(); }
                spSerialPort.Dispose();
                spSerialPort.Close();
                tmr_refresh.Stop();
            }
        }

        public void PortOpen()
        {
            try
            {
                PortClose(null, null);
                var avail_ports = System.IO.Ports.SerialPort.GetPortNames();
                if (avail_ports.Length == 0)
                {
                    Console.WriteLine("Exception: " + "No available ports.");
                    return;
                }
                spSerialPort.PortName = avail_ports[avail_ports.Length - 1];
                spSerialPort.BaudRate = 9600;
                //Console.WriteLine("Opening port : " + avail_ports[avail_ports.Length]);
                lblPort.Text = avail_ports[avail_ports.Length - 1];
                spSerialPort.Open();
                bClosing = false;
                tmr_refresh.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + "Port open failed.");
            }
        }

        public void DecodeData(byte[] byteTemp)
        {
            double[] Data = new double[4];
            double TimeElapse = (DateTime.Now - TimeStart).TotalMilliseconds / 1000;

            Data[0] = BitConverter.ToInt16(byteTemp, 2);
            Data[1] = BitConverter.ToInt16(byteTemp, 4);
            Data[2] = BitConverter.ToInt16(byteTemp, 6);
            Data[3] = BitConverter.ToInt16(byteTemp, 8);
            sRightPack++;
            switch (byteTemp[1])
            {
                case 0x50:
                    //Data[3] = Data[3] / 32768 * double.Parse(textBox9.Text) + double.Parse(textBox8.Text);
                    ChipTime[0] = (short)(2000 + byteTemp[2]);
                    ChipTime[1] = byteTemp[3];
                    ChipTime[2] = byteTemp[4];
                    ChipTime[3] = byteTemp[5];
                    ChipTime[4] = byteTemp[6];
                    ChipTime[5] = byteTemp[7];
                    ChipTime[6] = BitConverter.ToInt16(byteTemp, 8);


                    break;
                case 0x51:
                    //Data[3] = Data[3] / 32768 * double.Parse(textBox9.Text) + double.Parse(textBox8.Text);
                    Temperature = Data[3] / 100.0;
                    Data[0] = Data[0] / 32768.0 * 16;
                    Data[1] = Data[1] / 32768.0 * 16;
                    Data[2] = Data[2] / 32768.0 * 16;

                    a[0] = Data[0];
                    a[1] = Data[1];
                    a[2] = Data[2];
                    a[3] = Data[3];
                    if ((TimeElapse - LastTime[1]) < 0.1) return;
                    LastTime[1] = TimeElapse;

                    break;
                case 0x52:
                    //Data[3] = Data[3] / 32768 * double.Parse(textBox9.Text) + double.Parse(textBox8.Text);
                    Temperature = Data[3] / 100.0;
                    Data[0] = Data[0] / 32768.0 * 2000;
                    Data[1] = Data[1] / 32768.0 * 2000;
                    Data[2] = Data[2] / 32768.0 * 2000;
                    w[0] = Data[0];
                    w[1] = Data[1];
                    w[2] = Data[2];
                    w[3] = Data[3];

                    if ((TimeElapse - LastTime[2]) < 0.1) return;
                    LastTime[2] = TimeElapse;
                    break;
                case 0x53:
                    //Data[3] = Data[3] / 32768 * double.Parse(textBox9.Text) + double.Parse(textBox8.Text);
                    Temperature = Data[3] / 100.0;
                    Data[0] = Data[0] / 32768.0 * 180;
                    Data[1] = Data[1] / 32768.0 * 180;
                    Data[2] = Data[2] / 32768.0 * 180;
                    Angle[0] = Data[0];
                    Angle[1] = Data[1];
                    Angle[2] = Data[2];
                    Angle[3] = Data[3];
                    if ((TimeElapse - LastTime[3]) < 0.1) return;
                    LastTime[3] = TimeElapse;
                    break;
                case 0x54:
                    //Data[3] = Data[3] / 32768 * double.Parse(textBox9.Text) + double.Parse(textBox8.Text);
                    Temperature = Data[3] / 100.0;
                    h[0] = Data[0];
                    h[1] = Data[1];
                    h[2] = Data[2];
                    h[3] = Data[3];
                    if ((TimeElapse - LastTime[4]) < 0.1) return;
                    LastTime[4] = TimeElapse;
                    break;
                case 0x55:
                    Port[0] = Data[0];
                    Port[1] = Data[1];
                    Port[2] = Data[2];
                    Port[3] = Data[3];

                    break;

                case 0x56:
                    Pressure = BitConverter.ToInt32(byteTemp, 2);
                    Altitude = (double)BitConverter.ToInt32(byteTemp, 6) / 100.0;

                    break;

                case 0x57:
                    Longitude = BitConverter.ToInt32(byteTemp, 2);
                    Latitude = BitConverter.ToInt32(byteTemp, 6);

                    break;

                case 0x58:
                    GPSHeight = (double)BitConverter.ToInt16(byteTemp, 2) / 10.0;
                    GPSYaw = (double)BitConverter.ToInt16(byteTemp, 4) / 10.0;
                    GroundVelocity = BitConverter.ToInt16(byteTemp, 6) / 1e3;

                    break;
                default:
                    break;
            }
        }

        public void SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] byteTemp = new byte[1000];

            if (bClosing) return;
            try
            {
                bListening = true;
                UInt16 usLength = 0;
                try
                {
                    usLength = (UInt16)spSerialPort.Read(RxBuffer, usRxLength, 700);
                }
                catch (Exception err)
                {
                    //MessageBox.Show(err.Message);
                    //return;
                }
                usRxLength += usLength;
                while (usRxLength >= 11)
                {
                    UpdateData Update = new UpdateData(DecodeData);
                    RxBuffer.CopyTo(byteTemp, 0);
                    if (!((byteTemp[0] == 0x55) & ((byteTemp[1] & 0x50) == 0x50)))
                    {
                        for (int i = 1; i < usRxLength; i++) RxBuffer[i - 1] = RxBuffer[i];
                        usRxLength--;
                        continue;
                    }
                    if (((byteTemp[0] + byteTemp[1] + byteTemp[2] + byteTemp[3] + byteTemp[4] + byteTemp[5] + byteTemp[6] + byteTemp[7] + byteTemp[8] + byteTemp[9]) & 0xff) == byteTemp[10])
                        this.Invoke(Update, byteTemp);
                    for (int i = 11; i < usRxLength; i++) RxBuffer[i - 11] = RxBuffer[i];
                    usRxLength -= 11;
                }

                Thread.Sleep(10);
            }
            finally
            {
                bListening = false;//我用完了，ui可以关闭串口了。   
            }
        }

        private void DisplayRefresh(object sender, EventArgs e)
        {
            // double TimeElapse = (DateTime.Now - TimeStart).TotalMilliseconds / 1000;

            lblIMUData.Text = Angle[0].ToString("f2") + " °\r\n"
                            + Angle[1].ToString("f2") + " °\r\n"
                            + Angle[2].ToString("f2") + " °\r\n\r\n";

            if (_scene != null)
            {
                _scene.set_agent_orientation(Angle[2]);
                render_and_flush();
            }

        }

        private void FlashRefresh(object sender, EventArgs e)
        {
            if (_scene != null)
            {
                flashingShow = !flashingShow;
                render_and_flush();
            }
        }

        private void EmptyVoiceChecker(object sender, EventArgs e)
        {
            if (_scene != null && _sceneHandler != null && DateTimeOffset.Now.Subtract(lastSpokenTime).TotalSeconds >= 30)
            {
                _sceneHandler.SendEmptyVoice();
            }
        }

        // check whether is connected
        public bool IsConnected()
        {
            if (_con == null)
            {
                return false;
            }
            return _con.IsConnected();
        }

        // update json file and load
        public void UpdateJsonFile(string fileName)
        {
            this.Invoke(new EventHandler(delegate {
                logger.Info(string.Format("change to file: {0}", fileName));
                txtPath.Text = string.Format(filePrefix, expFolder, currentFrame) + fileName;
                // for windows debug
                if (expFolder == "")
                {
                    txtPath.Text = fileName;
                }
                btnLoadScene_Click(null, null);
            }));
        }

        public string GetSceneFileName()
        {
            return string.Format("scene_{0}_{1}.json", currentFrame, _scene.current_suffix);
        }

        public string GetNoteFileName()
        {
            return string.Format("scene_{0}_{1}_note.json", currentFrame, _scene.current_suffix);
        }

        public static string GetRelativePosition(int obj_id, SceneData _scene)
        {
            for (int i = 0; i < _scene._data.Count; i++)
            {
                if (_scene._data[i].id != obj_id)
                {
                    continue;
                }

                var obj = _scene._data[i];
                if (obj.cx < 0)
                {
                    var tan = obj.cy / obj.cx;
                    if (tan > 2.41)
                    {
                        return "右侧";
                    }
                    else if (tan > 0.41)
                    {
                        return "右下角";
                    }
                    else if (tan > -0.41)
                    {
                        return "下方";
                    }
                    else if (tan > -2.41)
                    {
                        return "左下角";
                    }
                    else
                    {
                        return "左侧";
                    }
                }
                else if (obj.cx > 0)
                {
                    var tan = obj.cy / obj.cx;
                    if (tan > 2.41)
                    {
                        return "左侧";
                    }
                    else if (tan > 0.41)
                    {
                        return "左上角";
                    }
                    else if (tan > -0.41)
                    {
                        return "上方";
                    }
                    else if (tan > -2.41)
                    {
                        return "右上角";
                    }
                    else
                    {
                        return "右侧";
                    }
                }
                else
                {
                    if (obj.cy > 0)
                    {
                        return "左侧";
                    }
                    else if (obj.cy < 0)
                    {
                        return "右侧";
                    }
                    else
                    {
                        return "中心";
                    }
                }
            }
            return "未知";
        }

        public void LogCurrentStatus(string imu, string imgUrl, string jsonUrl, string action)
        {
            // time, gps, imu, image, scenegraph, scene json
            logger.Info(string.Format("imu: {0}, imgUrl: {1}, jsonUrl: {2}, action: {3}",
                imu, imgUrl, jsonUrl, action));
        }

        // helper functions 
        public void SendVoice(int type, string label)
        {
            AddToList("send voice: ", label);
        }

        public void SceneVoice(List<SceneInst> data)
        {
            AddToList("3D background: ", "start");
        }

        public void Record(int type, string name)
        {
            if (type == 1)
            {
                AddToList("record start: ", name);
            }
            else if (type == 2)
            {
                AddToList("record stop: ", name);
            }
            else if (type == 3)
            {
                AddToList("record play: ", name);
            }
        }
    }
}
