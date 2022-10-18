using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Metec.MVBDClient
{
    public partial class FormMain : Form
    {
        protected MVBDConnection    _con;


        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (DesignMode == true) return;

            // Init PWM-Value (0-7)
            cboPWMValue.Items.Clear();

            for(int i = 0; i < 8; i++)
            {
                cboPWMValue.Items.Add(i);
            }


            // Init Identifier
            cboIdentifier.Items.Clear();
            cboIdentifier.Items.Add ("Unknown");            // 0
            cboIdentifier.Items.Add ("MVBD");               // 1
            cboIdentifier.Items.Add ("NVDA");               // 2
            cboIdentifier.Items.Add ("GRANT");              // 3
            cboIdentifier.Items.Add ("HyperBrailleGeo");    // 4
            cboIdentifier.Items.Add ("Monitor");            // 5
            cboIdentifier.Items.Add ("MATLAB");             // 6
            cboIdentifier.Items.Add ("Presentation");       // 7
            cboIdentifier.Items.Add ("E-Prime");            // 8
            cboIdentifier.Items.Add ("9");                  // 9
            cboIdentifier.Items.Add ("10");                 // 10
            cboIdentifier.Items.Add ("11");                 // 11
            cboIdentifier.Items.Add ("12");                 // 12
            cboIdentifier.Items.Add ("13");                 // 13
            cboIdentifier.Items.Add ("14");                 // 14
            cboIdentifier.Items.Add ("15");                 // 15
            cboIdentifier.SelectedIndex = 0;                // Who I am???




            _con = new MVBDConnection(this);                        // local
            //_con = new MVBDConnection(this, "92.79.151.95", 2018);  // metec AG
            _con.PinsChanged       += _con_PinsChanged;
            _con.KeyDown           += _con_KeyDown;
            _con.KeyUp             += _con_KeyUp;
            _con.KeyShortcut       += _con_KeyShortcut;
            _con.FingerChanged     += _con_FingerChanged;
            _con.BrailleBytes      += _con_BrailleBytes;
            _con.DeviceInfoChanged += _con_DeviceInfoChanged;
            _con.NVDAGesture       += _con_NVDAGesture;
            _con.KeyboardKeyDown   += _con_KeyboardKeyDown;
            _con.KeyboardKeyUp     += _con_KeyboardKeyUp;
            _con.MouseMove         += _con_MouseMove;
            _con.CommandReceived   += _con_CommandReceived;

            tmrRefresh.Enabled = true;


            Text = String.Format("MVBD Test Clients v. {0}", Assembly.GetEntryAssembly().GetName().Version.Revision );

            chkCanGetFocus_CheckedChanged(null,null);
        }








        /// <summary>Refresh the view</summary>
        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            bool connected = _con.IsConnected();

            gbClient.Enabled    = ( connected == true  );
            btnConnect.Enabled  = ( connected == false );
            btnClose.Enabled    = ( connected == true  );

            chkAutoconnect.Checked = _con.Autoconnect;

            // Status;
            string status;

            if ( connected == true )
            {
                status = String.Format("Connected at {0}, Width={1}, Height={2}, Position={3}",  _con.LocalEndPoint, _con.PinCountX, _con.PinCountY, _con.WorkingPosition);
            }
            else
            {
                status = "Not connected";
            }

            if ( status != lblStatus.Text ) lblStatus.Text = status;


            // Draw the PictureBox
            picView.Invalidate();
        }


        /// <summary>Auto-Connect</summary>
        private void chkAutoconnect_CheckedChanged  (object sender, EventArgs e)
        {
            _con.Autoconnect = chkAutoconnect.Checked;
        }

        /// <summary>Connect</summary>
        private void btnConnect_Click               (object sender, EventArgs e)
        {
            _con.Connect();

            cboIdentifier_SelectedIndexChanged(null,null);  // -- SendSetIdentifier
        }

        /// <summary>Close</summary>
        private void btnClose_Click                 (object sender, EventArgs e)
        {
            _con.Close();
        }


        /// <summary>Event pins</summary>
        void _con_PinsChanged                       (object sender, MVBDPinsEventArgs e)
        {
            //AddToList ( "Pins:       ", "" );
        }

        /// <summary>Event key down</summary>
        void _con_KeyDown                           (object sender, MVBDKeyEventArgs e)
        {
            AddToList ( "KeyDown:     ", e.Key );
        }

        /// <summary>Event key up</summary>
        void _con_KeyUp                             (object sender, MVBDKeyEventArgs e)
        {
            AddToList ( "KeyUp:       ", e.Key );
        }

        /// <summary>Event of a shortcut with a list of keys</summary>
        void _con_KeyShortcut                       (object sender, MVBDKeyListEventArgs e)
        {
            byte[] ba    = e.Keys;


            StringBuilder sb = new StringBuilder();

            foreach(byte b in ba)
            {
                sb.AppendFormat("{0},", b);
            }

            if ( sb.Length != 0 )   sb.Length -= 1;

            AddToList ( "KeyShortcut: ", sb.ToString() );
        }

        /// <summary>Event finger changed</summary>
        void _con_FingerChanged                     (object sender, MVBDFingerEventArgs e)
        {
            AddToList ( "Finger:      ", e.Finger );
        }

        /// <summary>NVDA Braille Bytes received</summary>
        void _con_BrailleBytes                      (object sender, MVBDBrailleBytesEventArgs e)
        {
            AddToList ( "NVDA:        ", e );
        }

        /// <summary>The virtual device has changed</summary>
        void _con_DeviceInfoChanged                 (object sender, MVBDDeviceInfoEventArgs e)
        {
            AddToList ( "DeviceInfo:  ", e );

            SetCurrentDeviceType();

            //_con.SendGetDeviceGraphic();
            //_con.SendGetNotificationsMask();
        }

        /// <summary>NVDA Gesture received</summary>
        void _con_NVDAGesture                       (object sender, MVBDNVDAGestureEventArgs e)
        {
            AddToList ( "NVDAGesture: ", e );
        }

        /// <summary>Event Keyboard key down (Cmd=66)</summary>
        void _con_KeyboardKeyDown                   (object sender, MVBDKeyEventArgs e)
        {
            int    i     = e.Key;
            string value = String.Format("0x{0:X2} {1,-3} {2}", i,i, (Keys)i  );

            AddToList ( "Keyboard KeyDown:     ", value );
        }

        /// <summary>Event Keyboard key up (Cmd=67)</summary>
        void _con_KeyboardKeyUp                     (object sender, MVBDKeyEventArgs e)
        {
            int    i     = e.Key;
            string value = String.Format("0x{0:X2} {1,-3} {2}", i,i, (Keys)i  );

            AddToList ( "Keyboard KeyUp:       ", value );
        }

        /// <summary>Event MouseMove (Cmd=68)</summary>
        void _con_MouseMove                         (object sender, MVBDMouseMoveEventArgs e)
        {
            AddToList ( "MouseMove:       ", e.ToString() );
        }

        /// <summary>Event MouseMove (Cmd=...)</summary>
        private void _con_CommandReceived           (object sender, MVBDCommandEventArgs e)
        {
            int     cmd = e.Cmd;

            if      ( cmd == 76 )   AddToList ( "NumCells:       ", e.Args[0] );
            else if ( cmd == 77 )   AddToList ( "Debug Message:  ", e.Args[0] );
            else                    AddToList ( "Unknown command ", e.Args[0] );
        }



        /// <summary>Make an entry in the event listbox</summary>
        private void AddToList              (string name, object value)
        {
            int index = lstEvents.Items.Add ( String.Format("{0} {1}", name,value ) );
            lstEvents.SelectedIndex = index;
        }

        /// <summary>Clear the events listbox</summary>
        private void btnEventsClear_Click   (object sender, EventArgs e)
        {
            lstEvents.Items.Clear();
        }







        /// <summary>All Pins on / off (21)</summary>
        private void btnAllOnOff_Click                      (object sender, EventArgs e)
        {
            bool value;

            if      ( sender == btnAllOn  ) value = true;
            else if ( sender == btnAllOff ) value = false;
            else return;    // -->

            _con.SetAllPins(value);
            _con.SendPins();
        }











        private void btnGetDeviceInfo_Click                 (object sender, EventArgs e)
        {
            _con.SendGetDeviceInfo();
        }






        protected void SetCurrentDeviceType()
        {
            if ( _con.DeviceInfo == null ) return;     // -->

            int id = _con.DeviceInfo.ID;


            _isLocked = true;
           

            for (int r = 0; r < dgv.RowCount; r++)
            {
                DataGridViewCell cell = dgv[0,r];

                if ( cell.Value.Equals(id) )
                {
                    dgv.CurrentCell = cell;
                    break;
                }
            }



            //foreach(DataGridViewRow row in rows)
            //{
            //    if ( row.Cells[0].Value.Equals(id) )   row.Selected = true; else row.Selected = false;
            //}

            _isLocked = false;
        }










        private void cboPWMValue_SelectedIndexChanged       (object sender, EventArgs e)
        {
            _con.SendSetPWMValue( cboPWMValue.SelectedIndex );
        }


        private void chkPinPlayer_CheckedChanged            (object sender, EventArgs e)
        {
            _con.SendSetPinPlayerEnabled( chkPinPlayer.Checked );  // cmd 5
        }

        private void btnTrigger_Click                       (object sender, EventArgs e)
        {
            _con.SendPinPlayerTrigger();   // cmd 6
        }



        private void cboIdentifier_SelectedIndexChanged     (object sender, EventArgs e)
        {
            if ( _con == null ) return;

            int identifier = cboIdentifier.SelectedIndex;

            _con.SendSetIdentifier(identifier);
        }


        protected byte[]    _values = new byte[] {1,2,4,8,16,32,64,128};
        protected int       _pos;


        private void btnSendPinsAsNVDA_Click                (object sender, EventArgs e)
        {
            byte[] data = new byte[3];
            for(int i = 0; i < data.Length; i++)
            {
                int  index =  _pos & 7;
                byte value = _values[ index ];
                System.Diagnostics.Debug.Print ("{0} {1} {2}", _pos, index, value);

                data[i] = value;
                _pos++;
            }

            _con.SendPinsAsNVDA( data );

        }


        private void btnSendKey_MouseDown                   (object sender, MouseEventArgs e)
        {
            if      ( sender == btnSendKeyLeft  ) _con.SendKeyDown(209);    // LLeft
            else if ( sender == btnSendKeyRight ) _con.SendKeyDown(211);    // LRight
        }

        private void btnSendKey_MouseUp                     (object sender, MouseEventArgs e)
        {
            if      ( sender == btnSendKeyLeft  ) _con.SendKeyUp(209);    // LLeft
            else if ( sender == btnSendKeyRight ) _con.SendKeyUp(211);    // LRight
        }





        private void btnSendFinger_MouseDown                   (object sender, MouseEventArgs e)
        {
            if ( e.Button == MouseButtons.Left )
            {
                _con.SendFinger(0, true,  e.X, e.Y,  e.X, e.Y);
            }
        }

        private void btnSendFinger_MouseUp                     (object sender, MouseEventArgs e)
        {
            _con.SendFinger(0, false, 0,0, 0,0 );
        }

        private void btnSendFinger_MouseMove(object sender, MouseEventArgs e)
        {
            if ( e.Button == MouseButtons.Left )
            {
                _con.SendFinger(0, true,  e.X, e.Y,  e.X, e.Y);
            }
        }

        private void btnSendFinger_MouseLeave(object sender, EventArgs e)
        {
            _con.SendFinger(0, false, 0,0, 0,0 );
        }




        /// <summary>Show dialog of TcpRoots</summary>
        private void btnTcpRoots_Click                      (object sender, EventArgs e)
        {
            TcpRootsDialog.Show( _con );        // Show the dialog modal
        }

        private void btnGetVersion_Click                    (object sender, EventArgs e)
        {
            if ( _con.SendGetVersion() == true )
            {
                AddToList("Version", _con.Version.ToString() );
            }
        }


        /// <summary>Receive Graphic data</summary>
        private void btnGetGraphic_Click              (object sender, EventArgs e)
        {
            if      ( sender == btnGetDeviceGraphic   )    _con.SendGetDeviceGraphic();
            else if ( sender == btnGetKeyboardGraphic )    _con.SendGetKeyboardGraphic();
            else if ( sender == btnGetScreensGraphic  )    _con.SendGetScreensGraphic();
            else System.Diagnostics.Debugger.Break();
        }




        /// <summary>Set the visibitily of the MVBD GUI</summary>
        private void btnSetVisibility_Click                 (object sender, EventArgs e)
        {
            if      ( sender == btnSetVisibilityHidden      )   _con.SendSetVisibility( Visibility.Hidden     );    // 0
            else if ( sender == btnSetVisibilityWindow      )   _con.SendSetVisibility( Visibility.Window     );    // 1
            else if ( sender == btnSetVisibilityNotifyIcon  )   _con.SendSetVisibility( Visibility.NotifyIcon );    // 2
        }

        /// <summary>Get Pins</summary>
        private void btnGetPins_Click                       (object sender, EventArgs e)
        {
            _con.SendGetPins();
        }

        private void btnExit_Click                          (object sender, EventArgs e)
        {
            _con.SendExit();
        }

















        private void btnGetSelect_Click                     (object sender, EventArgs e)
        {

            DataTable dt = _con.SendGetSelect(1);

            if ( dt == null )   return;

            DataGridViewColumnCollection columns = dgv.Columns;
            columns.Clear();

            foreach(DataColumn c in dt.Columns)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn(); 
                column.HeaderText = c.ColumnName;
                columns.Add(column);   // 00
            }



            DataGridViewRowCollection    rows    = dgv.Rows;
            rows.Clear();

            int countX = dt.Columns.Count;
            object[] values = new object[countX];

            foreach(DataRow r in dt.Rows)
            {
                values = r.ItemArray;
                int index = rows.Add(values);
            }



            //int countX = oa.GetLength(0);
            //int countY = oa.GetLength(1);

            //DataGridViewColumnCollection columns = dgv.Columns;
            //columns.Clear();


            //for(int x = 0; x < countX; x++)
            //{
            //    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn(); 
            //    col.HeaderText = String.Format("Column {0}", x);
            //    columns.Add(col);   // 00
            //}


            //DataGridViewRowCollection    rows    = dgv.Rows;
            //rows.Clear();

            //for(int y = 0; y < countY; y++)
            //{
            //    object[] values = new object[countX];

            //    for(int x = 0; x < countX; x++)
            //    {
            //        values[x] = oa[x,y];
            //    }

            //    int index = rows.Add(values);
            //}



        }


        //private void btnGetScreenshot_Click(object sender, EventArgs e)
        //{
        //    ScreenshowDialog.Show( _con );  // Show the dialog modal
        //}

        private void btnMouseMove_Click(object sender, EventArgs e)
        {
            _con.SendMouseMove();
        }







        /// <summary>Draw the view</summary>
        private void picView_Paint (object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear( Color.Black );

            if (_con.VirtualDevice   != null)
            {

                if (_con.Bitmap != null)
                {
                    g.DrawImage(_con.Bitmap, 0,0);
                }
                else
                {
                    DrawVirtualDevice(g, _con.VirtualDevice);
                }

            }


            // Sieht nicht schön aus
            //float sx = 0.2F;
            //if (_con.ScreensGraphic  != null)   { g.ResetTransform();   g.TranslateTransform(10, 10);      sx = 0.1F; g.ScaleTransform(sx,sx);      DrawScreens  ( g, _con.ScreensGraphic  ); }
            //if (_con.DeviceGraphic   != null)   { g.ResetTransform();   g.TranslateTransform(10, 200);     sx = 0.8F; g.ScaleTransform(sx,sx);      DrawDevice   ( g, _con.DeviceGraphic   ); }
            //if (_con.KeyboardGraphic != null)   { g.ResetTransform();   g.TranslateTransform(500, 10);     sx = 1.0F; g.ScaleTransform(sx,sx);      DrawKeyboard ( g, _con.KeyboardGraphic ); }
        }



        /// <summary>Draw computer screens from command 70</summary>
        private void DrawScreens        (Graphics g, byte[] ba)
        {
            if ( ba == null )   return; // -->

            int x;
            int y;
            int width;
            int height;


            int pos   = 0;

            int count = ba[pos++];                                                  // 0 Count of screens

            for(int i = 0; i < count; i++)
            {
                //bool primary = false;
                //if (ba[pos++] != 0)  primary = true;    // 0
                pos++;

                x        = (ba[pos++] | ba[pos++] << 8);  // 1
                y        = (ba[pos++] | ba[pos++] << 8);  // 2
                width    = (ba[pos++] | ba[pos++] << 8);  // 3
                height   = (ba[pos++] | ba[pos++] << 8);  // 4

                g.FillRectangle(Brushes.DodgerBlue,  x,y,width,height);
                g.DrawRectangle(Pens.GhostWhite,     x,y,width,height);
            }

            // Draw the cursor
            //Cursor cursor = Cursors.Default;
            //Rectangle targetRect = new Rectangle( _con.MousePosition, cursor.Size );
            //cursor.Draw(g, targetRect);

            x = _con.MousePosition.X;
            y = _con.MousePosition.Y;


            g.FillEllipse( Brushes.Red, x,y, 20,20 );

        }

        /// <summary>Draw device from command 52</summary>
        private void DrawVirtualDevice  (Graphics g, MVBDVirtualDevice vd)
        {
            if ( vd == null )   return; // -->

            // 1. Device
            Brush brushDevice = new SolidBrush(vd.Color);
            g.FillRectangle (brushDevice, 0,0, vd.Width, vd.Height);  // Color of housing
            g.DrawRectangle (Pens.White,  0,0, vd.Width, vd.Height );

            // 2. Pins
            MVBDPins pins = vd.Pins;
            Brush brush0 = new SolidBrush(pins.Color);
            Brush brush1 = Brushes.Red;
            Brush brush;

            int pinWidth   = pins.Step - 2;

            for ( int y = 0; y < pins.CountY; y++)
            {
                for( int x = 0; x < pins.CountX; x++)
                {
                    if ( pins[x,y] == true )  brush = brush1;  else brush = brush0;

                    g.FillRectangle(brush, pins.X + x * pins.Step,  pins.Y + y * pins.Step,    pinWidth,pinWidth);
                }
            }

            // 3. Keys
            MVBDDeviceKey[] keys = vd.Keys;
            Font font = SystemFonts.DefaultFont;


            Brush brushKey = new SolidBrush( vd.KeysColor );

            for(int i = 0; i < keys.Length; i++)
            {
                MVBDDeviceKey key = keys[i];

                //if ( _con.DeviceKeys[keyIndex] == true )

                if ( key.Visible == true )
                {
                    if ( key.IsPressed == true )
                    {
                        g.FillRectangle ( Brushes.Red,   key.X, key.Y,   key.Width, key.Height    );     // Red
                        g.DrawString    ( key.Index.ToString(), font, Brushes.Black, key.X, key.Y );     // Black
                    }
                    else
                    {
                        g.FillRectangle ( brushKey,      key.X,key.Y,    key.Width, key.Height    );     // KeyColor
                        g.DrawString    ( key.Index.ToString(), font, Brushes.Red,   key.X, key.Y );     // Red
                    }
                }
            }


            // 4. Fingers
            foreach (MVBDFinger f in vd.Fingers)
            {
                if (f.IsPressed == true)
                {
                    int x = pins.X + f.PX * pins.Step;
                    int y = pins.Y + f.PY * pins.Step;

                    g.FillEllipse(Brushes.Blue, x,y, 8,8 );
                }
            }

        }

        /// <summary>Draw computer keyboard from command 69</summary>
        private void DrawKeyboard       (Graphics g, MVBDComputerKeyboard keyboard)
        {
            if ( keyboard == null )   return; // -->

            Font fontL = new Font(FontFamily.GenericMonospace, 16, GraphicsUnit.Pixel);
            Font fontM = new Font(FontFamily.GenericMonospace, 10, GraphicsUnit.Pixel);
            Font fontS = new Font(FontFamily.GenericMonospace,  8, GraphicsUnit.Pixel);

            Brush brush;
            Brush brush0 = Brushes.Gray;
            Brush brush1 = Brushes.Red;

            // 1. Keyboard
            g.DrawRectangle(Pens.GhostWhite, 0,0, keyboard.Width, keyboard.Height);

            foreach(MVBDComputerKey k in keyboard.Keys)
            {
                RectangleF rect = new RectangleF( k.X,  k.Y,  k.Width,  k.Height );

                if ( _con.KeyboardKeys[k.KeyCode] == true ) brush = brush1; else brush = brush0;

                // if ( k.IsPressed == true )  
                g.FillRectangle (brush, rect);




                string text = k.Text;

                Font font;
                int length = text.Length;

                if      ( length <= 1 ) font = fontL;
                else if ( length <= 3 ) font = fontM;
                else                    font = fontS;



                SizeF size = g.MeasureString( text, font );

                float x = ( rect.Width  - size.Width  ) / 2F;
                float y = ( rect.Height - size.Height ) / 2F;
                PointF point = new PointF( rect.X + x, rect.Y + y );

                g.DrawString (text, font, Brushes.GhostWhite, point);


            }
        }












        protected bool _isLocked;

        /// <summary>Get Notifications Mask</summary>
        private void btnGetNotificationsMask_Click          (object sender, EventArgs e)
        {
            if ( _con.SendGetNotificationsMask() == true )
            {
                _isLocked = true;

                chkSetNotification0001.Checked  =  ( ( _con.NotificationsMask & NotificationsMask.NVDAPins          ) != 0 );
                chkSetNotification0002.Checked  =  ( ( _con.NotificationsMask & NotificationsMask.DeviceInfo        ) != 0 );
                chkSetNotification0004.Checked  =  ( ( _con.NotificationsMask & NotificationsMask.Pins              ) != 0 );
                chkSetNotification0008.Checked  =  ( ( _con.NotificationsMask & NotificationsMask.KeyDown           ) != 0 );
                chkSetNotification0010.Checked  =  ( ( _con.NotificationsMask & NotificationsMask.KeyUp             ) != 0 );
                chkSetNotification0020.Checked  =  ( ( _con.NotificationsMask & NotificationsMask.Fingers           ) != 0 );
                chkSetNotification0040.Checked  =  ( ( _con.NotificationsMask & NotificationsMask.NVDAGestures      ) != 0 );
                chkSetNotification0080.Checked  =  ( ( _con.NotificationsMask & NotificationsMask.KeyboardKeyDown   ) != 0 );
                chkSetNotification0100.Checked  =  ( ( _con.NotificationsMask & NotificationsMask.KeyboardKeyUp     ) != 0 );
                chkSetNotification0200.Checked  =  ( ( _con.NotificationsMask & NotificationsMask.MouseMove         ) != 0 );
                chkSetNotification0400.Checked  =  ( ( _con.NotificationsMask & NotificationsMask.KeyShortcut       ) != 0 );
                chkSetNotification0800.Checked  =  ( ( _con.NotificationsMask & NotificationsMask.Bitmap            ) != 0 );
                chkSetNotification1000.Checked  =  ( ( _con.NotificationsMask & NotificationsMask.DebugMessages     ) != 0 );

                _isLocked = false;
            }
        }










        /// <summary>Set Notifications</summary>
        private void chkSetNotificationsMask_CheckedChanged (object sender, EventArgs e)
        {
            if ( _isLocked == true )    return;

            CheckBox chk = (CheckBox)sender;

            NotificationsMask mask = 0;

            if      ( chk == chkSetNotification0001  )  mask = NotificationsMask.NVDAPins;
            else if ( chk == chkSetNotification0002  )  mask = NotificationsMask.DeviceInfo;
            else if ( chk == chkSetNotification0004  )  mask = NotificationsMask.Pins;
            else if ( chk == chkSetNotification0008  )  mask = NotificationsMask.KeyDown;
            else if ( chk == chkSetNotification0010  )  mask = NotificationsMask.KeyUp;
            else if ( chk == chkSetNotification0020  )  mask = NotificationsMask.Fingers;
            else if ( chk == chkSetNotification0040  )  mask = NotificationsMask.NVDAGestures;
            else if ( chk == chkSetNotification0080  )  mask = NotificationsMask.KeyboardKeyDown;
            else if ( chk == chkSetNotification0100  )  mask = NotificationsMask.KeyboardKeyUp;
            else if ( chk == chkSetNotification0200  )  mask = NotificationsMask.MouseMove;
            else if ( chk == chkSetNotification0400  )  mask = NotificationsMask.KeyShortcut;
            else if ( chk == chkSetNotification0800  )  mask = NotificationsMask.Bitmap;
            else if ( chk == chkSetNotification1000  )  mask = NotificationsMask.DebugMessages;
            else System.Diagnostics.Debugger.Break();

            bool enabled = chk.Checked;

            _con.SendSetNotificationsMask (mask, enabled);
        }





        /// <summary>Get Configurations</summary>
        private void btnGetConfigurations_Click          (object sender, EventArgs e)
        {
            if ( _con.SendGetConfigurations() == true )
            {
                _isLocked = true;

                chkSetConfiguration00.Checked  =  ( ( _con.Configurations & ConfigurationsMask.DeviceKeyShortcutsActive                 ) != 0 );    // 0x0001;
                chkSetConfiguration01.Checked  =  ( ( _con.Configurations & ConfigurationsMask.ScreenCaptureActive                      ) != 0 );    // 0x0002;
                chkSetConfiguration02.Checked  =  ( ( _con.Configurations & ConfigurationsMask.ScreenCaptureFollowMousepointer          ) != 0 );    // 0x0004;
                chkSetConfiguration03.Checked  =  ( ( _con.Configurations & ConfigurationsMask.ScreenCaptureFollowFocus                 ) != 0 );    // 0x0008;

                chkSetConfiguration04.Checked  =  ( ( _con.Configurations & ConfigurationsMask.ScreenCaptureSpeakingFinger              ) != 0 );    // 0x0010;
                chkSetConfiguration05.Checked  =  ( ( _con.Configurations & ConfigurationsMask.ScreenCaptureInvert                      ) != 0 );    // 0x0020;
                chkSetConfiguration06.Checked  =  ( ( _con.Configurations & ConfigurationsMask.ScreenCaptureShowMousepointer            ) != 0 );    // 0x0040;
                chkSetConfiguration07.Checked  =  ( ( _con.Configurations & ConfigurationsMask.ScreenCaptureControlWithKeys             ) != 0 );    // 0x0080;

                chkSetConfiguration08.Checked  =  ( ( _con.Configurations & ConfigurationsMask.ScreenCaptureFingersZoom                 ) != 0 );    // 0x0100;
                chkSetConfiguration09.Checked  =  ( ( _con.Configurations & ConfigurationsMask.SpeakKeys                                ) != 0 );    // 0x0200;
                chkSetConfiguration10.Checked  =  ( ( _con.Configurations & ConfigurationsMask.SpeakElements                            ) != 0 );    // 0x0400;
                chkSetConfiguration11.Checked  =  ( ( _con.Configurations & ConfigurationsMask.ShowBrailleline                          ) != 0 );    // 0x0800;

                chkSetConfiguration12.Checked  =  ( ( _con.Configurations & ConfigurationsMask.ShowElementInBrailleline                 ) != 0 );    // 0x1000;
                chkSetConfiguration13.Checked  =  ( ( _con.Configurations & ConfigurationsMask.PinOscilatorsActive                      ) != 0 );    // 0x2000;
                chkSetConfiguration14.Checked  =  ( ( _con.Configurations & ConfigurationsMask.PinPlayerActive                          ) != 0 );    // 0x4000;  (New in version 130)
                chkSetConfiguration15.Checked  =  ( ( _con.Configurations & ConfigurationsMask.TcpRootingsActive                        ) != 0 );    // 0x8000;  (New in version 130)

                chkSetConfiguration16.Checked  =  ( ( _con.Configurations & ConfigurationsMask.ScreenCaptureFingersMove                 ) != 0 );    // 0x010000;  (New in version 134)
                chkSetConfiguration17.Checked  =  ( ( _con.Configurations & ConfigurationsMask.ScreenCaptureFingerMovesMousepointer     ) != 0 );    // 0x020000;  (New in version 134)
                chkSetConfiguration18.Checked  =  ( ( _con.Configurations & ConfigurationsMask.ScreenCaptureFingerOnEdgeScrollsTheView  ) != 0 );    // 0x040000;  (New in version 134)
                chkSetConfiguration19.Checked  =  ( ( _con.Configurations & ConfigurationsMask.ScreenCaptureFingerCanClick              ) != 0 );    // 0x080000;  (New in version 135)

                _isLocked = false;
            }
        }




        /// <summary>Set Configurations</summary>
        private void chkSetConfigurations_CheckedChanged(object sender, EventArgs e)
        {
            if ( _isLocked == true )    return;


            CheckBox chk = (CheckBox)sender;

            ConfigurationsMask mask = 0;

            if      ( chk == chkSetConfiguration00    )  mask = ConfigurationsMask.DeviceKeyShortcutsActive;         // 0x0001;
            else if ( chk == chkSetConfiguration01    )  mask = ConfigurationsMask.ScreenCaptureActive;              // 0x0002;
            else if ( chk == chkSetConfiguration02    )  mask = ConfigurationsMask.ScreenCaptureFollowMousepointer;  // 0x0004;
            else if ( chk == chkSetConfiguration03    )  mask = ConfigurationsMask.ScreenCaptureFollowFocus;         // 0x0008;

            else if ( chk == chkSetConfiguration04    )  mask = ConfigurationsMask.ScreenCaptureSpeakingFinger;      // 0x0010;
            else if ( chk == chkSetConfiguration05    )  mask = ConfigurationsMask.ScreenCaptureInvert;              // 0x0020;
            else if ( chk == chkSetConfiguration06    )  mask = ConfigurationsMask.ScreenCaptureShowMousepointer;    // 0x0040;
            else if ( chk == chkSetConfiguration07    )  mask = ConfigurationsMask.ScreenCaptureControlWithKeys;     // 0x0080;

            else if ( chk == chkSetConfiguration08    )  mask = ConfigurationsMask.ScreenCaptureFingersZoom;         // 0x0100;
            else if ( chk == chkSetConfiguration09    )  mask = ConfigurationsMask.SpeakKeys;                        // 0x0200;
            else if ( chk == chkSetConfiguration10    )  mask = ConfigurationsMask.SpeakElements;                    // 0x0400;
            else if ( chk == chkSetConfiguration11    )  mask = ConfigurationsMask.ShowBrailleline;                  // 0x0800;

            else if ( chk == chkSetConfiguration12    )  mask = ConfigurationsMask.ShowElementInBrailleline;         // 0x1000;
            else if ( chk == chkSetConfiguration13    )  mask = ConfigurationsMask.PinOscilatorsActive;              // 0x2000;
            else if ( chk == chkSetConfiguration14    )  mask = ConfigurationsMask.PinPlayerActive;                  // 0x4000; (New in version 130)
            else if ( chk == chkSetConfiguration15    )  mask = ConfigurationsMask.TcpRootingsActive;                // 0x8000; (New in version 130)

            else if ( chk == chkSetConfiguration16    )  mask = ConfigurationsMask.ScreenCaptureFingersMove;                  // 0x010000; (New in version 134)
            else if ( chk == chkSetConfiguration17    )  mask = ConfigurationsMask.ScreenCaptureFingerMovesMousepointer;      // 0x020000; (New in version 134)
            else if ( chk == chkSetConfiguration18    )  mask = ConfigurationsMask.ScreenCaptureFingerOnEdgeScrollsTheView;   // 0x040000; (New in version 134)
            else if ( chk == chkSetConfiguration19    )  mask = ConfigurationsMask.ScreenCaptureFingerCanClick;               // 0x080000; (New in version 135)

            else System.Diagnostics.Debugger.Break();


            bool enabled = chk.Checked;


            _con.SendSetConfigurations(mask, enabled);
        }

        private void gbClient_Paint(object sender, PaintEventArgs e)
        {

        }






        private const int GWL_EXSTYLE           = -20;
        private const long WS_EX_NOACTIVATE     = 0x08000000;

        [DllImport("user32")]   private static extern IntPtr GetWindowLongPtrW          (IntPtr hWnd, int nIndex);
        [DllImport("user32")]   private static extern IntPtr SetWindowLongPtrW          (IntPtr hWnd, int nIndex, IntPtr dwNewLong);



        private void chkCanGetFocus_CheckedChanged(object sender, EventArgs e)
        {
            long style1 = GetWindowLongPtrW(Handle, GWL_EXSTYLE).ToInt64();
            long style2;

            if (chkCanGetFocus.Checked == true)
            {
                style2 =  style1 & ~WS_EX_NOACTIVATE;
            }
            else
            {
                style2 = style1 | WS_EX_NOACTIVATE;
            }


            if ( style2 != style1 )
            {
                IntPtr  ret = SetWindowLongPtrW (Handle, GWL_EXSTYLE, new IntPtr(style2) );

                if ( ret == IntPtr.Zero )
                {
                    System.Diagnostics.Debugger.Break();
                }
            }
        }


























        /// <summary>Fill DataGridView. Get a list of the device types (26)</summary>
        private void btnGetDeviceTypes_Click                (object sender, EventArgs e)
        {
            dgv.Tag = sender;
            DataGridViewColumnCollection columns = dgv.Columns;
            columns.Clear();


            if ( _con.SendGetDeviceTypes() == true )
            {
                DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn(); col0.HeaderText = "ID";   columns.Add(col0);   // 00
                DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn(); col1.HeaderText = "Name"; columns.Add(col1);   // 01
                DataGridViewLinkColumn    col2 = new DataGridViewLinkColumn();    col2.HeaderText = "Set";  columns.Add(col2);   // 02

                DataGridViewRowCollection    rows    = dgv.Rows;
                rows.Clear();

                foreach( MVBDDeviceType t in _con.DeviceTypes )
                {
                    object[] values = new object[3];

                    values[0] = t.ID;
                    values[1] = t.Name;
                    values[2] = String.Format( "SendSetDeviceType ({0}) ", t.ID );

                    int index = rows.Add(values);
                }

                SetCurrentDeviceType();

            }

        }


        /// <summary>Fill DataGridView. Get a list of the braille devices (58)</summary>
        private void btnGetBrailleDevices_Click             (object sender, EventArgs e)
        {
            dgv.Tag = sender;
            DataGridViewColumnCollection columns = dgv.Columns;
            columns.Clear();

            if ( _con.SendGetBrailleDevices() == true )
            {
                DataGridViewTextBoxColumn  col0 = new DataGridViewTextBoxColumn();  col0.HeaderText = "ID";         columns.Add(col0);   // 00
                DataGridViewTextBoxColumn  col1 = new DataGridViewTextBoxColumn();  col1.HeaderText = "Name";       columns.Add(col1);   // 01
                DataGridViewCheckBoxColumn col2 = new DataGridViewCheckBoxColumn(); col2.HeaderText = "Connected";  columns.Add(col2);   // 02
                DataGridViewCheckBoxColumn col3 = new DataGridViewCheckBoxColumn(); col3.HeaderText = "Reconnect";  columns.Add(col3);   // 03

                DataGridViewRowCollection rows = dgv.Rows;
                rows.Clear();

                foreach( MVBDBrailleDevice bd in _con.BrailleDevices)
                {
                    object[] values = new object[4];

                    values[0] = bd.ID;
                    values[1] = bd.Name;
                    values[2] = bd.Connected;
                    values[3] = bd.Reconnect;

                    int index = rows.Add(values);
                }
            }

        }

        /// <summary>Fill DataGridView. Test NVDA Gesures</summary>
        private void btnTestSendKeys_Click(object sender, EventArgs e)
        {
            dgv.Tag = sender;
            DataGridViewColumnCollection columns = dgv.Columns;
            columns.Clear();
            DataGridViewLinkColumn    col0 = new DataGridViewLinkColumn();    col0.HeaderText = "NVDA Gesures (30)"; col0.Width = 200;    columns.Add(col0);   // 0
            DataGridViewLinkColumn    col1 = new DataGridViewLinkColumn();    col1.HeaderText = "SendKeys (22/23)";  col1.Width = 200;    columns.Add(col1);   // 1


            DataGridViewRowCollection   rows    = dgv.Rows;
            rows.Clear();

            rows.Add(20);

            dgv[0,00].Value = "braille_scrollBack";
            dgv[0,01].Value = "braille_scrollForward";
            dgv[0,02].Value = "braille_previousLine";
            dgv[0,03].Value = "braille_nextLine";
            dgv[0,04].Value = "braille_toggleTether";

            dgv[0,05].Value = "braille_routeTo 0";
            dgv[0,06].Value = "braille_routeTo 1";
            dgv[0,07].Value = "braille_routeTo 2";
            dgv[0,08].Value = "braille_routeTo 3";
            dgv[0,09].Value = "braille_routeTo 4";
            dgv[0,10].Value = "braille_routeTo 5";

            dgv[0,11].Value = "say_battery_status";
            dgv[0,12].Value = "showGui";
            dgv[0,13].Value = "title";
            dgv[0,14].Value = "dateTime";
            dgv[0,15].Value = "sayAll";
            dgv[0,16].Value = "reportCurrentLine";
            dgv[0,17].Value = "quit";
            dgv[0,18].Value = "toggleCurrentAppSleepMode";

            // Send Keys
            dgv[1,00].Value = "LLeft";
            dgv[1,01].Value = "LRight";



        }


        /// <summary>Common Click Event of the DataGridView</summary>
        private void dgv_CellContentClick        (object sender, DataGridViewCellEventArgs e)
        {
            int     rowIndex    = e.RowIndex;
            int     columnIndex = e.ColumnIndex;
            object  tag         = dgv.Tag;

            if ( rowIndex    == -1 ) return;   // -->   Header
            if ( columnIndex == -1 ) return;   // -->   Header



            if ( tag == btnGetDeviceTypes )
            {
                if ( columnIndex == 2 )
                {
                    int id = (int)dgv[0, rowIndex].Value;
                    _con.SendSetDeviceType(id);
                }
            }

            else if ( tag == btnTestSendKeys )
            {
                if ( columnIndex == 0 )
                {

                    if      ( rowIndex == 00 )    _con.SendNVDAGestureScrollBack();         // braille_scrollBack
                    else if ( rowIndex == 01 )    _con.SendNVDAGestureScrollForward();      // braille_scrollForward
                    else if ( rowIndex == 02 )    _con.SendNVDAGesture(3);                  // braille_previousLine
                    else if ( rowIndex == 03 )    _con.SendNVDAGesture(4);                  // braille_nextLine
                    else if ( rowIndex == 04 )    _con.SendNVDAGesture(5);                  // braille_toggleTether

                    else if ( rowIndex == 05 )    _con.SendNVDAGestureRouteTo(0);           // braille_routeTo 0
                    else if ( rowIndex == 06 )    _con.SendNVDAGestureRouteTo(1);           // braille_routeTo 1
                    else if ( rowIndex == 07 )    _con.SendNVDAGestureRouteTo(2);           // braille_routeTo 2
                    else if ( rowIndex == 08 )    _con.SendNVDAGestureRouteTo(3);           // braille_routeTo 3
                    else if ( rowIndex == 09 )    _con.SendNVDAGestureRouteTo(4);           // braille_routeTo 4
                    else if ( rowIndex == 10 )    _con.SendNVDAGestureRouteTo(5);           // braille_routeTo 5

                    else if ( rowIndex == 11 )    _con.SendNVDAGesture(61);                 // say_battery_status
                    else if ( rowIndex == 12 )    _con.SendNVDAGesture(62);                 // showGui
                    else if ( rowIndex == 13 )    _con.SendNVDAGesture(63);                 // title
                    else if ( rowIndex == 14 )    _con.SendNVDAGesture(64);                 // dateTime
                    else if ( rowIndex == 15 )    _con.SendNVDAGesture(65);                 // sayAll
                    else if ( rowIndex == 16 )    _con.SendNVDAGesture(66);                 // reportCurrentLine
                    else if ( rowIndex == 17 )    _con.SendNVDAGesture(67);                 // quit
                    else if ( rowIndex == 18 )    _con.SendNVDAGesture(68);                 // toggleCurrentAppSleepMode
                }

            }



        }




        private void dgv_CellMouseDown      (object sender, DataGridViewCellMouseEventArgs e)   {  dgv_CellMouseUpDown(sender,e,true );  }
        private void dgv_CellMouseUp        (object sender, DataGridViewCellMouseEventArgs e)   {  dgv_CellMouseUpDown(sender,e,false);  }

        private void dgv_CellMouseUpDown    (object sender, DataGridViewCellMouseEventArgs e, bool isDown)
        {
            int     rowIndex    = e.RowIndex;
            int     columnIndex = e.ColumnIndex;
            object  tag         = dgv.Tag;

            if ( rowIndex    == -1 ) return;   // -->   Header
            if ( columnIndex == -1 ) return;   // -->   Header



            if ( ( tag == btnTestSendKeys ) && (columnIndex == 1 ) )
            {
                if      ( rowIndex == 0 )   {   if ( isDown == true )   _con.SendKeyDown(209);  else _con.SendKeyUp(209);   }   // LLeft
                else if ( rowIndex == 1 )   {   if ( isDown == true )   _con.SendKeyDown(211);  else _con.SendKeyUp(211);   }   // LRight
            }

        }


    }
}