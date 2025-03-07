﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Metec.MVBDClient
{
    public partial class FormDrawing : Form
    {
        protected MVBDConnection    _con;
        bool isListening;
        int px, py; // finger position
        NotificationsMask mask;

        protected SceneData _scene;

        string[] scene_paths;

        public FormDrawing()
        {
            InitializeComponent();
        }

        private void FormDrawings_Load(object sender, EventArgs e)
        {
            _con = new MVBDConnection(this);

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

        private void render_and_flush()
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
            _scene.render(_con.VirtualDevice.Pins.Array_ext, _con.PinCountX, _con.PinCountY);
            SceneData.flush(_con.VirtualDevice.Pins.Array_ext, _con.VirtualDevice.Pins.Array, _con.PinCountX, _con.PinCountY);
            _con.SendPins();
        }

        private string last_spoken;
        private void send_voice()
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
            string semantic_label = _scene.get_label_text(_con.VirtualDevice.Pins.Array_ext, _con.PinCountX, _con.PinCountY, px, py, chkChineseSpeech.Checked);
            if (semantic_label != last_spoken)
            {
                _con.SendSpeakText(semantic_label);
                Console.WriteLine("Speak: " + semantic_label);
                last_spoken = semantic_label;
            }
        }

        private void tmrStatus_Tick(object sender, EventArgs e)
        {
            // Status;
            string status;

            if ( _con.IsConnected() == true )
            {
                status = String.Format("Connected at {0}, Width={1}, Height={2}, Position={3}",  _con.LocalEndPoint, _con.PinCountX, _con.PinCountY, _con.WorkingPosition);
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

            if ( status != lblStatus.Text ) lblStatus.Text = status;

            if (chkEnableIMU.Checked && spSerialPort.IsOpen == false)
            {
                PortOpen();
            }
        }
        

        /// <summary>Buttons Draw...</summary>
        private void btnDraw_Click(object sender, EventArgs e)
        {
            // 1. Clear all pins
            if ( chkPinsAutoClear.Checked == true )
            {
                _con.SendPinsClear();
            }


            // 2. Draw something
            Random rnd = new Random();

            if       ( sender == btnPinsDrawRectangle )
            { 
                _con.SendPinsDrawRectangle( rnd.Next(0,20), rnd.Next(0,20),   20,10);
            }

            else  if ( sender == btnPinsDrawLine   )
            {
                _con.SendPinsDrawLine(0, rnd.Next(0,20) , _con.PinCountX-1, rnd.Next(20,40) );
            }

            else  if ( sender == btnPinsDrawPolygon   )
            {
                Point[] points = new Point[4];

                points[0] = new Point( rnd.Next(0,7),   20);
                points[1] = new Point( rnd.Next(10,50), 40);
                points[2] = new Point( rnd.Next(60,65), 20);
                points[3] = new Point( rnd.Next(0,70),   2);

                _con.SendPinsDrawPolygon( points );
            }
            
            else if ( sender == btnPinsDrawCircle )
            {
                _con.SendPinsDrawCircle( rnd.Next(20,40), rnd.Next(20,30), rnd.Next(10,20) );
            }



            // 3. Flush it to show it in the MVBD
            if ( chkPinsAutoFlush.Checked == true )
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
            if ( e.KeyChar == 13 )
            {
                btnSpeakText_Click(null,null);
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
            if (chkPrintEvents.Checked)
            {
                int index = lstEvents.Items.Add(String.Format("{0} {1}", name, value));
                lstEvents.SelectedIndex = index;
            }
        }

        void _con_FingerChanged(object sender, MVBDFingerEventArgs e)
        {
            AddToList("Finger:      ", e.Finger);
            if (e.Finger.IsPressed)
            {
                px = e.Finger.PX;
                py = e.Finger.PY;
            }

            if (chkImmediateVoice.Checked)
            {
                send_voice();
            }
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
                _scene.rot_left();
                render_and_flush();
            }
            else if (e.Key == 222) // RT: rotate right
            {
                _scene.rot_right();
                render_and_flush();
            }
            else if (e.Key == 241) // F1: mode0
            {
                _scene.set_mode(0);
                render_and_flush();
            }
            else if (e.Key == 242) // F2: mode1
            {
                _scene.set_mode(1);
                render_and_flush();
            }
            else if (e.Key == 220)
            {
                send_voice();
            }
        }

        /// <summary>Event key up</summary>
        void _con_KeyUp(object sender, MVBDKeyEventArgs e)
        {
            AddToList("KeyUp:       ", e.Key);
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
            SceneData.clear(_con.VirtualDevice.Pins.Array_ext, width, height);
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
                spSerialPort.PortName = avail_ports[avail_ports.Length-1];
                spSerialPort.BaudRate = 9600;
                //Console.WriteLine("Opening port : " + avail_ports[avail_ports.Length]);
                lblPort.Text = avail_ports[avail_ports.Length-1];
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
    }
}
