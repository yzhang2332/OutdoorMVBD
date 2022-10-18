namespace Metec.MVBDClient
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnGetBrailleDevices = new System.Windows.Forms.Button();
            this.btnGetNotificationsMask = new System.Windows.Forms.Button();
            this.chkSetNotification0020 = new System.Windows.Forms.CheckBox();
            this.chkSetNotification0010 = new System.Windows.Forms.CheckBox();
            this.chkSetNotification0008 = new System.Windows.Forms.CheckBox();
            this.chkSetNotification0004 = new System.Windows.Forms.CheckBox();
            this.chkSetNotification0002 = new System.Windows.Forms.CheckBox();
            this.chkSetNotification0001 = new System.Windows.Forms.CheckBox();
            this.btnEventsClear = new System.Windows.Forms.Button();
            this.btnGetVersion = new System.Windows.Forms.Button();
            this.cboIdentifier = new System.Windows.Forms.ComboBox();
            this.lblPins = new System.Windows.Forms.Label();
            this.chkAutoconnect = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.btnTcpRoots = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblEvents = new System.Windows.Forms.Label();
            this.gbClient = new System.Windows.Forms.Panel();
            this.btnTestSendKeys = new System.Windows.Forms.Button();
            this.chkSetConfiguration19 = new System.Windows.Forms.CheckBox();
            this.chkSetConfiguration18 = new System.Windows.Forms.CheckBox();
            this.chkSetConfiguration17 = new System.Windows.Forms.CheckBox();
            this.chkSetConfiguration16 = new System.Windows.Forms.CheckBox();
            this.chkSetConfiguration15 = new System.Windows.Forms.CheckBox();
            this.chkSetConfiguration14 = new System.Windows.Forms.CheckBox();
            this.chkSetConfiguration13 = new System.Windows.Forms.CheckBox();
            this.chkSetConfiguration12 = new System.Windows.Forms.CheckBox();
            this.chkSetConfiguration11 = new System.Windows.Forms.CheckBox();
            this.chkSetConfiguration10 = new System.Windows.Forms.CheckBox();
            this.chkSetConfiguration09 = new System.Windows.Forms.CheckBox();
            this.chkSetConfiguration08 = new System.Windows.Forms.CheckBox();
            this.chkSetConfiguration07 = new System.Windows.Forms.CheckBox();
            this.chkSetConfiguration06 = new System.Windows.Forms.CheckBox();
            this.chkSetConfiguration05 = new System.Windows.Forms.CheckBox();
            this.chkSetConfiguration04 = new System.Windows.Forms.CheckBox();
            this.chkSetConfiguration03 = new System.Windows.Forms.CheckBox();
            this.chkSetConfiguration02 = new System.Windows.Forms.CheckBox();
            this.chkSetConfiguration01 = new System.Windows.Forms.CheckBox();
            this.chkSetConfiguration00 = new System.Windows.Forms.CheckBox();
            this.picView = new System.Windows.Forms.PictureBox();
            this.btnMouseMove = new System.Windows.Forms.Button();
            this.btnGetConfigurations = new System.Windows.Forms.Button();
            this.chkSetNotification0040 = new System.Windows.Forms.CheckBox();
            this.chkSetNotification0800 = new System.Windows.Forms.CheckBox();
            this.chkSetNotification0400 = new System.Windows.Forms.CheckBox();
            this.chkSetNotification0200 = new System.Windows.Forms.CheckBox();
            this.chkSetNotification0100 = new System.Windows.Forms.CheckBox();
            this.chkSetNotification0080 = new System.Windows.Forms.CheckBox();
            this.chkPinPlayer = new System.Windows.Forms.CheckBox();
            this.btnSendKeyLeft = new System.Windows.Forms.Button();
            this.btnSendFinger = new System.Windows.Forms.Button();
            this.btnSendKeyRight = new System.Windows.Forms.Button();
            this.btnSendPinsAsMVDA = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnGetPins = new System.Windows.Forms.Button();
            this.btnAllOn = new System.Windows.Forms.Button();
            this.lblIdentifier = new System.Windows.Forms.Label();
            this.lblPWMValue = new System.Windows.Forms.Label();
            this.btnAllOff = new System.Windows.Forms.Button();
            this.cboPWMValue = new System.Windows.Forms.ComboBox();
            this.btnGetDeviceTypes = new System.Windows.Forms.Button();
            this.lstEvents = new System.Windows.Forms.ListBox();
            this.btnSetVisibilityNotifyIcon = new System.Windows.Forms.Button();
            this.btnSetVisibilityWindow = new System.Windows.Forms.Button();
            this.btnSetVisibilityHidden = new System.Windows.Forms.Button();
            this.btnGetScreensGraphic = new System.Windows.Forms.Button();
            this.btnGetKeyboardGraphic = new System.Windows.Forms.Button();
            this.btnGetDeviceGraphic = new System.Windows.Forms.Button();
            this.btnGetDeviceInfo = new System.Windows.Forms.Button();
            this.btnTrigger = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.chkCanGetFocus = new System.Windows.Forms.CheckBox();
            this.chkSetNotification1000 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.gbClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(162, 61);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(366, 656);
            this.dgv.TabIndex = 21;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgv.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseDown);
            this.dgv.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseUp);
            // 
            // btnGetBrailleDevices
            // 
            this.btnGetBrailleDevices.Location = new System.Drawing.Point(351, 3);
            this.btnGetBrailleDevices.Name = "btnGetBrailleDevices";
            this.btnGetBrailleDevices.Size = new System.Drawing.Size(177, 23);
            this.btnGetBrailleDevices.TabIndex = 18;
            this.btnGetBrailleDevices.Text = "Get BrailleDevices (58)";
            this.btnGetBrailleDevices.UseVisualStyleBackColor = true;
            this.btnGetBrailleDevices.Click += new System.EventHandler(this.btnGetBrailleDevices_Click);
            // 
            // btnGetNotificationsMask
            // 
            this.btnGetNotificationsMask.Location = new System.Drawing.Point(714, 3);
            this.btnGetNotificationsMask.Name = "btnGetNotificationsMask";
            this.btnGetNotificationsMask.Size = new System.Drawing.Size(290, 23);
            this.btnGetNotificationsMask.TabIndex = 17;
            this.btnGetNotificationsMask.Text = "Get Notifications/Events (57)";
            this.btnGetNotificationsMask.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetNotificationsMask.UseVisualStyleBackColor = true;
            this.btnGetNotificationsMask.Click += new System.EventHandler(this.btnGetNotificationsMask_Click);
            // 
            // chkSetNotification0020
            // 
            this.chkSetNotification0020.Location = new System.Drawing.Point(714, 123);
            this.chkSetNotification0020.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetNotification0020.Name = "chkSetNotification0020";
            this.chkSetNotification0020.Size = new System.Drawing.Size(290, 17);
            this.chkSetNotification0020.TabIndex = 16;
            this.chkSetNotification0020.Text = "0x0020 Fingers";
            this.chkSetNotification0020.UseVisualStyleBackColor = true;
            this.chkSetNotification0020.CheckedChanged += new System.EventHandler(this.chkSetNotificationsMask_CheckedChanged);
            // 
            // chkSetNotification0010
            // 
            this.chkSetNotification0010.Location = new System.Drawing.Point(714, 106);
            this.chkSetNotification0010.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetNotification0010.Name = "chkSetNotification0010";
            this.chkSetNotification0010.Size = new System.Drawing.Size(290, 17);
            this.chkSetNotification0010.TabIndex = 16;
            this.chkSetNotification0010.Text = "0x0010 Device KeyUp";
            this.chkSetNotification0010.UseVisualStyleBackColor = true;
            this.chkSetNotification0010.CheckedChanged += new System.EventHandler(this.chkSetNotificationsMask_CheckedChanged);
            // 
            // chkSetNotification0008
            // 
            this.chkSetNotification0008.Location = new System.Drawing.Point(714, 89);
            this.chkSetNotification0008.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetNotification0008.Name = "chkSetNotification0008";
            this.chkSetNotification0008.Size = new System.Drawing.Size(290, 17);
            this.chkSetNotification0008.TabIndex = 16;
            this.chkSetNotification0008.Text = "0x0008 Device KeyDown";
            this.chkSetNotification0008.UseVisualStyleBackColor = true;
            this.chkSetNotification0008.CheckedChanged += new System.EventHandler(this.chkSetNotificationsMask_CheckedChanged);
            // 
            // chkSetNotification0004
            // 
            this.chkSetNotification0004.Location = new System.Drawing.Point(714, 66);
            this.chkSetNotification0004.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetNotification0004.Name = "chkSetNotification0004";
            this.chkSetNotification0004.Size = new System.Drawing.Size(290, 17);
            this.chkSetNotification0004.TabIndex = 16;
            this.chkSetNotification0004.Text = "0x0004 Pins";
            this.chkSetNotification0004.UseVisualStyleBackColor = true;
            this.chkSetNotification0004.CheckedChanged += new System.EventHandler(this.chkSetNotificationsMask_CheckedChanged);
            // 
            // chkSetNotification0002
            // 
            this.chkSetNotification0002.Location = new System.Drawing.Point(714, 49);
            this.chkSetNotification0002.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetNotification0002.Name = "chkSetNotification0002";
            this.chkSetNotification0002.Size = new System.Drawing.Size(290, 17);
            this.chkSetNotification0002.TabIndex = 16;
            this.chkSetNotification0002.Text = "0x0002 DeviceInfo";
            this.chkSetNotification0002.UseVisualStyleBackColor = true;
            this.chkSetNotification0002.CheckedChanged += new System.EventHandler(this.chkSetNotificationsMask_CheckedChanged);
            // 
            // chkSetNotification0001
            // 
            this.chkSetNotification0001.Location = new System.Drawing.Point(714, 32);
            this.chkSetNotification0001.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.chkSetNotification0001.Name = "chkSetNotification0001";
            this.chkSetNotification0001.Size = new System.Drawing.Size(290, 17);
            this.chkSetNotification0001.TabIndex = 16;
            this.chkSetNotification0001.Text = "0x0001 NVDA-Pins";
            this.chkSetNotification0001.UseVisualStyleBackColor = true;
            this.chkSetNotification0001.CheckedChanged += new System.EventHandler(this.chkSetNotificationsMask_CheckedChanged);
            // 
            // btnEventsClear
            // 
            this.btnEventsClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEventsClear.Location = new System.Drawing.Point(1469, 8);
            this.btnEventsClear.Name = "btnEventsClear";
            this.btnEventsClear.Size = new System.Drawing.Size(75, 23);
            this.btnEventsClear.TabIndex = 14;
            this.btnEventsClear.Text = "Clear";
            this.btnEventsClear.UseVisualStyleBackColor = true;
            this.btnEventsClear.Click += new System.EventHandler(this.btnEventsClear_Click);
            // 
            // btnGetVersion
            // 
            this.btnGetVersion.Location = new System.Drawing.Point(534, 63);
            this.btnGetVersion.Name = "btnGetVersion";
            this.btnGetVersion.Size = new System.Drawing.Size(150, 23);
            this.btnGetVersion.TabIndex = 13;
            this.btnGetVersion.Text = "Get MVBD Version (34)";
            this.btnGetVersion.UseVisualStyleBackColor = true;
            this.btnGetVersion.Click += new System.EventHandler(this.btnGetVersion_Click);
            // 
            // cboIdentifier
            // 
            this.cboIdentifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdentifier.FormattingEnabled = true;
            this.cboIdentifier.Location = new System.Drawing.Point(3, 211);
            this.cboIdentifier.Name = "cboIdentifier";
            this.cboIdentifier.Size = new System.Drawing.Size(128, 21);
            this.cboIdentifier.TabIndex = 11;
            this.cboIdentifier.SelectedIndexChanged += new System.EventHandler(this.cboIdentifier_SelectedIndexChanged);
            // 
            // lblPins
            // 
            this.lblPins.Location = new System.Drawing.Point(4, 14);
            this.lblPins.Name = "lblPins";
            this.lblPins.Size = new System.Drawing.Size(96, 15);
            this.lblPins.TabIndex = 10;
            this.lblPins.Text = "Pins:";
            // 
            // chkAutoconnect
            // 
            this.chkAutoconnect.Location = new System.Drawing.Point(174, 9);
            this.chkAutoconnect.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.chkAutoconnect.Name = "chkAutoconnect";
            this.chkAutoconnect.Size = new System.Drawing.Size(94, 23);
            this.chkAutoconnect.TabIndex = 19;
            this.chkAutoconnect.Text = "Auto-Connect";
            this.chkAutoconnect.UseVisualStyleBackColor = true;
            this.chkAutoconnect.CheckedChanged += new System.EventHandler(this.chkAutoconnect_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(93, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Interval = 300;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // btnTcpRoots
            // 
            this.btnTcpRoots.Location = new System.Drawing.Point(3, 338);
            this.btnTcpRoots.Name = "btnTcpRoots";
            this.btnTcpRoots.Size = new System.Drawing.Size(128, 52);
            this.btnTcpRoots.TabIndex = 12;
            this.btnTcpRoots.Text = "TcpRoots Dialog...\r\n(31,32,33)";
            this.btnTcpRoots.UseVisualStyleBackColor = true;
            this.btnTcpRoots.Click += new System.EventHandler(this.btnTcpRoots_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(274, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(579, 21);
            this.lblStatus.TabIndex = 20;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEvents
            // 
            this.lblEvents.Location = new System.Drawing.Point(1028, 16);
            this.lblEvents.Name = "lblEvents";
            this.lblEvents.Size = new System.Drawing.Size(173, 15);
            this.lblEvents.TabIndex = 10;
            this.lblEvents.Text = "Events:";
            // 
            // gbClient
            // 
            this.gbClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbClient.Controls.Add(this.chkSetNotification1000);
            this.gbClient.Controls.Add(this.btnTestSendKeys);
            this.gbClient.Controls.Add(this.chkSetConfiguration19);
            this.gbClient.Controls.Add(this.chkSetConfiguration18);
            this.gbClient.Controls.Add(this.chkSetConfiguration17);
            this.gbClient.Controls.Add(this.chkSetConfiguration16);
            this.gbClient.Controls.Add(this.chkSetConfiguration15);
            this.gbClient.Controls.Add(this.chkSetConfiguration14);
            this.gbClient.Controls.Add(this.chkSetConfiguration13);
            this.gbClient.Controls.Add(this.chkSetConfiguration12);
            this.gbClient.Controls.Add(this.chkSetConfiguration11);
            this.gbClient.Controls.Add(this.chkSetConfiguration10);
            this.gbClient.Controls.Add(this.chkSetConfiguration09);
            this.gbClient.Controls.Add(this.chkSetConfiguration08);
            this.gbClient.Controls.Add(this.chkSetConfiguration07);
            this.gbClient.Controls.Add(this.chkSetConfiguration06);
            this.gbClient.Controls.Add(this.chkSetConfiguration05);
            this.gbClient.Controls.Add(this.chkSetConfiguration04);
            this.gbClient.Controls.Add(this.chkSetConfiguration03);
            this.gbClient.Controls.Add(this.chkSetConfiguration02);
            this.gbClient.Controls.Add(this.chkSetConfiguration01);
            this.gbClient.Controls.Add(this.chkSetConfiguration00);
            this.gbClient.Controls.Add(this.picView);
            this.gbClient.Controls.Add(this.btnMouseMove);
            this.gbClient.Controls.Add(this.dgv);
            this.gbClient.Controls.Add(this.btnGetBrailleDevices);
            this.gbClient.Controls.Add(this.btnGetConfigurations);
            this.gbClient.Controls.Add(this.btnGetNotificationsMask);
            this.gbClient.Controls.Add(this.chkSetNotification0040);
            this.gbClient.Controls.Add(this.chkSetNotification0020);
            this.gbClient.Controls.Add(this.chkSetNotification0800);
            this.gbClient.Controls.Add(this.chkSetNotification0400);
            this.gbClient.Controls.Add(this.chkSetNotification0200);
            this.gbClient.Controls.Add(this.chkSetNotification0100);
            this.gbClient.Controls.Add(this.chkSetNotification0010);
            this.gbClient.Controls.Add(this.chkSetNotification0080);
            this.gbClient.Controls.Add(this.chkSetNotification0008);
            this.gbClient.Controls.Add(this.chkSetNotification0004);
            this.gbClient.Controls.Add(this.chkSetNotification0002);
            this.gbClient.Controls.Add(this.chkSetNotification0001);
            this.gbClient.Controls.Add(this.btnEventsClear);
            this.gbClient.Controls.Add(this.btnGetVersion);
            this.gbClient.Controls.Add(this.btnTcpRoots);
            this.gbClient.Controls.Add(this.cboIdentifier);
            this.gbClient.Controls.Add(this.lblPins);
            this.gbClient.Controls.Add(this.lblEvents);
            this.gbClient.Controls.Add(this.chkPinPlayer);
            this.gbClient.Controls.Add(this.btnSendKeyLeft);
            this.gbClient.Controls.Add(this.btnSendFinger);
            this.gbClient.Controls.Add(this.btnSendKeyRight);
            this.gbClient.Controls.Add(this.btnSendPinsAsMVDA);
            this.gbClient.Controls.Add(this.btnExit);
            this.gbClient.Controls.Add(this.btnGetPins);
            this.gbClient.Controls.Add(this.btnAllOn);
            this.gbClient.Controls.Add(this.lblIdentifier);
            this.gbClient.Controls.Add(this.lblPWMValue);
            this.gbClient.Controls.Add(this.btnAllOff);
            this.gbClient.Controls.Add(this.cboPWMValue);
            this.gbClient.Controls.Add(this.btnGetDeviceTypes);
            this.gbClient.Controls.Add(this.lstEvents);
            this.gbClient.Controls.Add(this.btnSetVisibilityNotifyIcon);
            this.gbClient.Controls.Add(this.btnSetVisibilityWindow);
            this.gbClient.Controls.Add(this.btnSetVisibilityHidden);
            this.gbClient.Controls.Add(this.btnGetScreensGraphic);
            this.gbClient.Controls.Add(this.btnGetKeyboardGraphic);
            this.gbClient.Controls.Add(this.btnGetDeviceGraphic);
            this.gbClient.Controls.Add(this.btnGetDeviceInfo);
            this.gbClient.Controls.Add(this.btnTrigger);
            this.gbClient.Location = new System.Drawing.Point(12, 35);
            this.gbClient.Margin = new System.Windows.Forms.Padding(0);
            this.gbClient.Name = "gbClient";
            this.gbClient.Size = new System.Drawing.Size(1550, 717);
            this.gbClient.TabIndex = 18;
            this.gbClient.Paint += new System.Windows.Forms.PaintEventHandler(this.gbClient_Paint);
            // 
            // btnTestSendKeys
            // 
            this.btnTestSendKeys.Location = new System.Drawing.Point(162, 32);
            this.btnTestSendKeys.Name = "btnTestSendKeys";
            this.btnTestSendKeys.Size = new System.Drawing.Size(183, 23);
            this.btnTestSendKeys.TabIndex = 117;
            this.btnTestSendKeys.Text = "Test SendKeys";
            this.btnTestSendKeys.UseVisualStyleBackColor = true;
            this.btnTestSendKeys.Click += new System.EventHandler(this.btnTestSendKeys_Click);
            // 
            // chkSetConfiguration19
            // 
            this.chkSetConfiguration19.Location = new System.Drawing.Point(714, 672);
            this.chkSetConfiguration19.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetConfiguration19.Name = "chkSetConfiguration19";
            this.chkSetConfiguration19.Size = new System.Drawing.Size(290, 17);
            this.chkSetConfiguration19.TabIndex = 116;
            this.chkSetConfiguration19.Text = "Bit19 Screen Capture - Finger can click";
            this.chkSetConfiguration19.UseVisualStyleBackColor = true;
            this.chkSetConfiguration19.CheckedChanged += new System.EventHandler(this.chkSetConfigurations_CheckedChanged);
            // 
            // chkSetConfiguration18
            // 
            this.chkSetConfiguration18.Location = new System.Drawing.Point(714, 655);
            this.chkSetConfiguration18.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetConfiguration18.Name = "chkSetConfiguration18";
            this.chkSetConfiguration18.Size = new System.Drawing.Size(290, 17);
            this.chkSetConfiguration18.TabIndex = 116;
            this.chkSetConfiguration18.Text = "Bit18 Screen Capture - Finger on edge srolls";
            this.chkSetConfiguration18.UseVisualStyleBackColor = true;
            this.chkSetConfiguration18.CheckedChanged += new System.EventHandler(this.chkSetConfigurations_CheckedChanged);
            // 
            // chkSetConfiguration17
            // 
            this.chkSetConfiguration17.Location = new System.Drawing.Point(714, 638);
            this.chkSetConfiguration17.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetConfiguration17.Name = "chkSetConfiguration17";
            this.chkSetConfiguration17.Size = new System.Drawing.Size(290, 17);
            this.chkSetConfiguration17.TabIndex = 116;
            this.chkSetConfiguration17.Text = "Bit17 Screen Capture - 1 finger moves the mouse ";
            this.chkSetConfiguration17.UseVisualStyleBackColor = true;
            this.chkSetConfiguration17.CheckedChanged += new System.EventHandler(this.chkSetConfigurations_CheckedChanged);
            // 
            // chkSetConfiguration16
            // 
            this.chkSetConfiguration16.Location = new System.Drawing.Point(714, 621);
            this.chkSetConfiguration16.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetConfiguration16.Name = "chkSetConfiguration16";
            this.chkSetConfiguration16.Size = new System.Drawing.Size(290, 17);
            this.chkSetConfiguration16.TabIndex = 116;
            this.chkSetConfiguration16.Text = "Bit16 Screen Capture - Move with 2 fingers";
            this.chkSetConfiguration16.UseVisualStyleBackColor = true;
            this.chkSetConfiguration16.CheckedChanged += new System.EventHandler(this.chkSetConfigurations_CheckedChanged);
            // 
            // chkSetConfiguration15
            // 
            this.chkSetConfiguration15.Location = new System.Drawing.Point(714, 592);
            this.chkSetConfiguration15.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetConfiguration15.Name = "chkSetConfiguration15";
            this.chkSetConfiguration15.Size = new System.Drawing.Size(290, 17);
            this.chkSetConfiguration15.TabIndex = 116;
            this.chkSetConfiguration15.Text = "Bit15 Tcp Rootings - Active";
            this.chkSetConfiguration15.UseVisualStyleBackColor = true;
            this.chkSetConfiguration15.CheckedChanged += new System.EventHandler(this.chkSetConfigurations_CheckedChanged);
            // 
            // chkSetConfiguration14
            // 
            this.chkSetConfiguration14.Location = new System.Drawing.Point(714, 575);
            this.chkSetConfiguration14.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetConfiguration14.Name = "chkSetConfiguration14";
            this.chkSetConfiguration14.Size = new System.Drawing.Size(290, 17);
            this.chkSetConfiguration14.TabIndex = 115;
            this.chkSetConfiguration14.Text = "Bit14 PinPlayer - Active";
            this.chkSetConfiguration14.UseVisualStyleBackColor = true;
            this.chkSetConfiguration14.CheckedChanged += new System.EventHandler(this.chkSetConfigurations_CheckedChanged);
            // 
            // chkSetConfiguration13
            // 
            this.chkSetConfiguration13.Location = new System.Drawing.Point(714, 558);
            this.chkSetConfiguration13.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetConfiguration13.Name = "chkSetConfiguration13";
            this.chkSetConfiguration13.Size = new System.Drawing.Size(290, 17);
            this.chkSetConfiguration13.TabIndex = 114;
            this.chkSetConfiguration13.Text = "Bit13 PinOscilators - Active";
            this.chkSetConfiguration13.UseVisualStyleBackColor = true;
            this.chkSetConfiguration13.CheckedChanged += new System.EventHandler(this.chkSetConfigurations_CheckedChanged);
            // 
            // chkSetConfiguration12
            // 
            this.chkSetConfiguration12.Location = new System.Drawing.Point(714, 538);
            this.chkSetConfiguration12.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetConfiguration12.Name = "chkSetConfiguration12";
            this.chkSetConfiguration12.Size = new System.Drawing.Size(290, 17);
            this.chkSetConfiguration12.TabIndex = 113;
            this.chkSetConfiguration12.Text = "Bit12 Show Element in Brailleline";
            this.chkSetConfiguration12.UseVisualStyleBackColor = true;
            this.chkSetConfiguration12.CheckedChanged += new System.EventHandler(this.chkSetConfigurations_CheckedChanged);
            // 
            // chkSetConfiguration11
            // 
            this.chkSetConfiguration11.Location = new System.Drawing.Point(714, 521);
            this.chkSetConfiguration11.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetConfiguration11.Name = "chkSetConfiguration11";
            this.chkSetConfiguration11.Size = new System.Drawing.Size(290, 17);
            this.chkSetConfiguration11.TabIndex = 112;
            this.chkSetConfiguration11.Text = "Bit11 Show Brailleline";
            this.chkSetConfiguration11.UseVisualStyleBackColor = true;
            this.chkSetConfiguration11.CheckedChanged += new System.EventHandler(this.chkSetConfigurations_CheckedChanged);
            // 
            // chkSetConfiguration10
            // 
            this.chkSetConfiguration10.Location = new System.Drawing.Point(714, 504);
            this.chkSetConfiguration10.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetConfiguration10.Name = "chkSetConfiguration10";
            this.chkSetConfiguration10.Size = new System.Drawing.Size(290, 17);
            this.chkSetConfiguration10.TabIndex = 111;
            this.chkSetConfiguration10.Text = "Bit10 Speak Element";
            this.chkSetConfiguration10.UseVisualStyleBackColor = true;
            this.chkSetConfiguration10.CheckedChanged += new System.EventHandler(this.chkSetConfigurations_CheckedChanged);
            // 
            // chkSetConfiguration09
            // 
            this.chkSetConfiguration09.Location = new System.Drawing.Point(714, 487);
            this.chkSetConfiguration09.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetConfiguration09.Name = "chkSetConfiguration09";
            this.chkSetConfiguration09.Size = new System.Drawing.Size(290, 17);
            this.chkSetConfiguration09.TabIndex = 110;
            this.chkSetConfiguration09.Text = "Bit9 Speak Keys";
            this.chkSetConfiguration09.UseVisualStyleBackColor = true;
            this.chkSetConfiguration09.CheckedChanged += new System.EventHandler(this.chkSetConfigurations_CheckedChanged);
            // 
            // chkSetConfiguration08
            // 
            this.chkSetConfiguration08.Location = new System.Drawing.Point(714, 465);
            this.chkSetConfiguration08.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetConfiguration08.Name = "chkSetConfiguration08";
            this.chkSetConfiguration08.Size = new System.Drawing.Size(290, 17);
            this.chkSetConfiguration08.TabIndex = 109;
            this.chkSetConfiguration08.Text = "Bit8 Zoom with 2 fingers";
            this.chkSetConfiguration08.UseVisualStyleBackColor = true;
            this.chkSetConfiguration08.CheckedChanged += new System.EventHandler(this.chkSetConfigurations_CheckedChanged);
            // 
            // chkSetConfiguration07
            // 
            this.chkSetConfiguration07.Location = new System.Drawing.Point(714, 448);
            this.chkSetConfiguration07.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetConfiguration07.Name = "chkSetConfiguration07";
            this.chkSetConfiguration07.Size = new System.Drawing.Size(290, 17);
            this.chkSetConfiguration07.TabIndex = 108;
            this.chkSetConfiguration07.Text = "Bit7 Screen Capture - Control With Keys";
            this.chkSetConfiguration07.UseVisualStyleBackColor = true;
            this.chkSetConfiguration07.CheckedChanged += new System.EventHandler(this.chkSetConfigurations_CheckedChanged);
            // 
            // chkSetConfiguration06
            // 
            this.chkSetConfiguration06.Location = new System.Drawing.Point(714, 431);
            this.chkSetConfiguration06.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetConfiguration06.Name = "chkSetConfiguration06";
            this.chkSetConfiguration06.Size = new System.Drawing.Size(290, 17);
            this.chkSetConfiguration06.TabIndex = 107;
            this.chkSetConfiguration06.Text = "Bit6 Screen Capture - Show Mousepointer";
            this.chkSetConfiguration06.UseVisualStyleBackColor = true;
            this.chkSetConfiguration06.CheckedChanged += new System.EventHandler(this.chkSetConfigurations_CheckedChanged);
            // 
            // chkSetConfiguration05
            // 
            this.chkSetConfiguration05.Location = new System.Drawing.Point(714, 414);
            this.chkSetConfiguration05.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetConfiguration05.Name = "chkSetConfiguration05";
            this.chkSetConfiguration05.Size = new System.Drawing.Size(290, 17);
            this.chkSetConfiguration05.TabIndex = 106;
            this.chkSetConfiguration05.Text = "Bit5 Screen Capture - Invert";
            this.chkSetConfiguration05.UseVisualStyleBackColor = true;
            this.chkSetConfiguration05.CheckedChanged += new System.EventHandler(this.chkSetConfigurations_CheckedChanged);
            // 
            // chkSetConfiguration04
            // 
            this.chkSetConfiguration04.Location = new System.Drawing.Point(714, 397);
            this.chkSetConfiguration04.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetConfiguration04.Name = "chkSetConfiguration04";
            this.chkSetConfiguration04.Size = new System.Drawing.Size(290, 17);
            this.chkSetConfiguration04.TabIndex = 105;
            this.chkSetConfiguration04.Text = "Bit4 Screen Capture - Speaking Finger";
            this.chkSetConfiguration04.UseVisualStyleBackColor = true;
            this.chkSetConfiguration04.CheckedChanged += new System.EventHandler(this.chkSetConfigurations_CheckedChanged);
            // 
            // chkSetConfiguration03
            // 
            this.chkSetConfiguration03.Location = new System.Drawing.Point(714, 380);
            this.chkSetConfiguration03.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetConfiguration03.Name = "chkSetConfiguration03";
            this.chkSetConfiguration03.Size = new System.Drawing.Size(290, 17);
            this.chkSetConfiguration03.TabIndex = 104;
            this.chkSetConfiguration03.Text = "Bit3 Screen Capture - Follow Focus";
            this.chkSetConfiguration03.UseVisualStyleBackColor = true;
            this.chkSetConfiguration03.CheckedChanged += new System.EventHandler(this.chkSetConfigurations_CheckedChanged);
            // 
            // chkSetConfiguration02
            // 
            this.chkSetConfiguration02.Location = new System.Drawing.Point(714, 363);
            this.chkSetConfiguration02.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetConfiguration02.Name = "chkSetConfiguration02";
            this.chkSetConfiguration02.Size = new System.Drawing.Size(290, 17);
            this.chkSetConfiguration02.TabIndex = 103;
            this.chkSetConfiguration02.Text = "Bit2 Screen Capture - Follow Mousepointer";
            this.chkSetConfiguration02.UseVisualStyleBackColor = true;
            this.chkSetConfiguration02.CheckedChanged += new System.EventHandler(this.chkSetConfigurations_CheckedChanged);
            // 
            // chkSetConfiguration01
            // 
            this.chkSetConfiguration01.Location = new System.Drawing.Point(714, 346);
            this.chkSetConfiguration01.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetConfiguration01.Name = "chkSetConfiguration01";
            this.chkSetConfiguration01.Size = new System.Drawing.Size(290, 17);
            this.chkSetConfiguration01.TabIndex = 102;
            this.chkSetConfiguration01.Text = "Bit1 Screen Capture - Active";
            this.chkSetConfiguration01.UseVisualStyleBackColor = true;
            this.chkSetConfiguration01.CheckedChanged += new System.EventHandler(this.chkSetConfigurations_CheckedChanged);
            // 
            // chkSetConfiguration00
            // 
            this.chkSetConfiguration00.Location = new System.Drawing.Point(714, 321);
            this.chkSetConfiguration00.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.chkSetConfiguration00.Name = "chkSetConfiguration00";
            this.chkSetConfiguration00.Size = new System.Drawing.Size(290, 17);
            this.chkSetConfiguration00.TabIndex = 101;
            this.chkSetConfiguration00.Text = "Bit0 DeviceKey Shortcuts - Active";
            this.chkSetConfiguration00.UseVisualStyleBackColor = true;
            this.chkSetConfiguration00.CheckedChanged += new System.EventHandler(this.chkSetConfigurations_CheckedChanged);
            // 
            // picView
            // 
            this.picView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picView.Location = new System.Drawing.Point(1031, 245);
            this.picView.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.picView.Name = "picView";
            this.picView.Size = new System.Drawing.Size(519, 472);
            this.picView.TabIndex = 25;
            this.picView.TabStop = false;
            this.picView.Paint += new System.Windows.Forms.PaintEventHandler(this.picView_Paint);
            // 
            // btnMouseMove
            // 
            this.btnMouseMove.Location = new System.Drawing.Point(534, 209);
            this.btnMouseMove.Name = "btnMouseMove";
            this.btnMouseMove.Size = new System.Drawing.Size(174, 23);
            this.btnMouseMove.TabIndex = 24;
            this.btnMouseMove.Text = "MouseMove (65)";
            this.btnMouseMove.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMouseMove.UseVisualStyleBackColor = true;
            this.btnMouseMove.Click += new System.EventHandler(this.btnMouseMove_Click);
            // 
            // btnGetConfigurations
            // 
            this.btnGetConfigurations.Location = new System.Drawing.Point(714, 292);
            this.btnGetConfigurations.Name = "btnGetConfigurations";
            this.btnGetConfigurations.Size = new System.Drawing.Size(290, 23);
            this.btnGetConfigurations.TabIndex = 100;
            this.btnGetConfigurations.Text = "Get Configurations (72)";
            this.btnGetConfigurations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetConfigurations.UseVisualStyleBackColor = true;
            this.btnGetConfigurations.Click += new System.EventHandler(this.btnGetConfigurations_Click);
            // 
            // chkSetNotification0040
            // 
            this.chkSetNotification0040.Location = new System.Drawing.Point(714, 140);
            this.chkSetNotification0040.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetNotification0040.Name = "chkSetNotification0040";
            this.chkSetNotification0040.Size = new System.Drawing.Size(290, 17);
            this.chkSetNotification0040.TabIndex = 16;
            this.chkSetNotification0040.Text = "0x0040 NVDA Gestures";
            this.chkSetNotification0040.UseVisualStyleBackColor = true;
            this.chkSetNotification0040.CheckedChanged += new System.EventHandler(this.chkSetNotificationsMask_CheckedChanged);
            // 
            // chkSetNotification0800
            // 
            this.chkSetNotification0800.Location = new System.Drawing.Point(714, 246);
            this.chkSetNotification0800.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetNotification0800.Name = "chkSetNotification0800";
            this.chkSetNotification0800.Size = new System.Drawing.Size(290, 17);
            this.chkSetNotification0800.TabIndex = 16;
            this.chkSetNotification0800.Text = "0x0800 Bitmap";
            this.chkSetNotification0800.UseVisualStyleBackColor = true;
            this.chkSetNotification0800.CheckedChanged += new System.EventHandler(this.chkSetNotificationsMask_CheckedChanged);
            // 
            // chkSetNotification0400
            // 
            this.chkSetNotification0400.Location = new System.Drawing.Point(714, 229);
            this.chkSetNotification0400.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetNotification0400.Name = "chkSetNotification0400";
            this.chkSetNotification0400.Size = new System.Drawing.Size(290, 17);
            this.chkSetNotification0400.TabIndex = 16;
            this.chkSetNotification0400.Text = "0x0400 Device KeyShortcut";
            this.chkSetNotification0400.UseVisualStyleBackColor = true;
            this.chkSetNotification0400.CheckedChanged += new System.EventHandler(this.chkSetNotificationsMask_CheckedChanged);
            // 
            // chkSetNotification0200
            // 
            this.chkSetNotification0200.Location = new System.Drawing.Point(714, 203);
            this.chkSetNotification0200.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetNotification0200.Name = "chkSetNotification0200";
            this.chkSetNotification0200.Size = new System.Drawing.Size(290, 17);
            this.chkSetNotification0200.TabIndex = 16;
            this.chkSetNotification0200.Text = "0x0200 MouseMove";
            this.chkSetNotification0200.UseVisualStyleBackColor = true;
            this.chkSetNotification0200.CheckedChanged += new System.EventHandler(this.chkSetNotificationsMask_CheckedChanged);
            // 
            // chkSetNotification0100
            // 
            this.chkSetNotification0100.Location = new System.Drawing.Point(714, 181);
            this.chkSetNotification0100.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetNotification0100.Name = "chkSetNotification0100";
            this.chkSetNotification0100.Size = new System.Drawing.Size(290, 17);
            this.chkSetNotification0100.TabIndex = 16;
            this.chkSetNotification0100.Text = "0x0100 Computer-Keyboard KeyUp";
            this.chkSetNotification0100.UseVisualStyleBackColor = true;
            this.chkSetNotification0100.CheckedChanged += new System.EventHandler(this.chkSetNotificationsMask_CheckedChanged);
            // 
            // chkSetNotification0080
            // 
            this.chkSetNotification0080.Location = new System.Drawing.Point(714, 164);
            this.chkSetNotification0080.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetNotification0080.Name = "chkSetNotification0080";
            this.chkSetNotification0080.Size = new System.Drawing.Size(290, 17);
            this.chkSetNotification0080.TabIndex = 16;
            this.chkSetNotification0080.Text = "0x0080 Computer-Keyboard KeyDown";
            this.chkSetNotification0080.UseVisualStyleBackColor = true;
            this.chkSetNotification0080.CheckedChanged += new System.EventHandler(this.chkSetNotificationsMask_CheckedChanged);
            // 
            // chkPinPlayer
            // 
            this.chkPinPlayer.Location = new System.Drawing.Point(7, 145);
            this.chkPinPlayer.Name = "chkPinPlayer";
            this.chkPinPlayer.Size = new System.Drawing.Size(97, 17);
            this.chkPinPlayer.TabIndex = 9;
            this.chkPinPlayer.Text = "PinPlayer (5)";
            this.chkPinPlayer.UseVisualStyleBackColor = true;
            this.chkPinPlayer.CheckedChanged += new System.EventHandler(this.chkPinPlayer_CheckedChanged);
            // 
            // btnSendKeyLeft
            // 
            this.btnSendKeyLeft.Location = new System.Drawing.Point(3, 303);
            this.btnSendKeyLeft.Name = "btnSendKeyLeft";
            this.btnSendKeyLeft.Size = new System.Drawing.Size(128, 23);
            this.btnSendKeyLeft.TabIndex = 0;
            this.btnSendKeyLeft.Text = "Left Key (22/23)";
            this.btnSendKeyLeft.UseVisualStyleBackColor = true;
            this.btnSendKeyLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSendKey_MouseDown);
            this.btnSendKeyLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSendKey_MouseUp);
            // 
            // btnSendFinger
            // 
            this.btnSendFinger.Location = new System.Drawing.Point(3, 409);
            this.btnSendFinger.Name = "btnSendFinger";
            this.btnSendFinger.Size = new System.Drawing.Size(128, 55);
            this.btnSendFinger.TabIndex = 0;
            this.btnSendFinger.Text = "Finger Down/Up";
            this.btnSendFinger.UseVisualStyleBackColor = true;
            this.btnSendFinger.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSendFinger_MouseDown);
            this.btnSendFinger.MouseLeave += new System.EventHandler(this.btnSendFinger_MouseLeave);
            this.btnSendFinger.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSendFinger_MouseMove);
            this.btnSendFinger.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSendFinger_MouseUp);
            // 
            // btnSendKeyRight
            // 
            this.btnSendKeyRight.Location = new System.Drawing.Point(3, 274);
            this.btnSendKeyRight.Name = "btnSendKeyRight";
            this.btnSendKeyRight.Size = new System.Drawing.Size(128, 23);
            this.btnSendKeyRight.TabIndex = 0;
            this.btnSendKeyRight.Text = "Right Key (22/23)";
            this.btnSendKeyRight.UseVisualStyleBackColor = true;
            this.btnSendKeyRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSendKey_MouseDown);
            this.btnSendKeyRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSendKey_MouseUp);
            // 
            // btnSendPinsAsMVDA
            // 
            this.btnSendPinsAsMVDA.Location = new System.Drawing.Point(3, 238);
            this.btnSendPinsAsMVDA.Name = "btnSendPinsAsMVDA";
            this.btnSendPinsAsMVDA.Size = new System.Drawing.Size(128, 23);
            this.btnSendPinsAsMVDA.TabIndex = 0;
            this.btnSendPinsAsMVDA.Text = "Send Pins As NVDA (1)";
            this.btnSendPinsAsMVDA.UseVisualStyleBackColor = true;
            this.btnSendPinsAsMVDA.Click += new System.EventHandler(this.btnSendPinsAsNVDA_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(534, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Close/Exit (55)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnGetPins
            // 
            this.btnGetPins.Location = new System.Drawing.Point(534, 238);
            this.btnGetPins.Name = "btnGetPins";
            this.btnGetPins.Size = new System.Drawing.Size(100, 23);
            this.btnGetPins.TabIndex = 0;
            this.btnGetPins.Text = "Get Pins (54)";
            this.btnGetPins.UseVisualStyleBackColor = true;
            this.btnGetPins.Click += new System.EventHandler(this.btnGetPins_Click);
            // 
            // btnAllOn
            // 
            this.btnAllOn.Location = new System.Drawing.Point(3, 32);
            this.btnAllOn.Name = "btnAllOn";
            this.btnAllOn.Size = new System.Drawing.Size(100, 23);
            this.btnAllOn.TabIndex = 0;
            this.btnAllOn.Text = "All On (21)";
            this.btnAllOn.UseVisualStyleBackColor = true;
            this.btnAllOn.Click += new System.EventHandler(this.btnAllOnOff_Click);
            // 
            // lblIdentifier
            // 
            this.lblIdentifier.Location = new System.Drawing.Point(3, 187);
            this.lblIdentifier.Name = "lblIdentifier";
            this.lblIdentifier.Size = new System.Drawing.Size(128, 21);
            this.lblIdentifier.TabIndex = 8;
            this.lblIdentifier.Text = "Send Who I am (29):";
            this.lblIdentifier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPWMValue
            // 
            this.lblPWMValue.Location = new System.Drawing.Point(6, 94);
            this.lblPWMValue.Name = "lblPWMValue";
            this.lblPWMValue.Size = new System.Drawing.Size(97, 21);
            this.lblPWMValue.TabIndex = 8;
            this.lblPWMValue.Text = "PWM Value (28):";
            this.lblPWMValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAllOff
            // 
            this.btnAllOff.Location = new System.Drawing.Point(3, 61);
            this.btnAllOff.Name = "btnAllOff";
            this.btnAllOff.Size = new System.Drawing.Size(100, 23);
            this.btnAllOff.TabIndex = 1;
            this.btnAllOff.Text = "All Off (21)";
            this.btnAllOff.UseVisualStyleBackColor = true;
            this.btnAllOff.Click += new System.EventHandler(this.btnAllOnOff_Click);
            // 
            // cboPWMValue
            // 
            this.cboPWMValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPWMValue.FormattingEnabled = true;
            this.cboPWMValue.Location = new System.Drawing.Point(7, 118);
            this.cboPWMValue.Name = "cboPWMValue";
            this.cboPWMValue.Size = new System.Drawing.Size(71, 21);
            this.cboPWMValue.TabIndex = 7;
            this.cboPWMValue.SelectedIndexChanged += new System.EventHandler(this.cboPWMValue_SelectedIndexChanged);
            // 
            // btnGetDeviceTypes
            // 
            this.btnGetDeviceTypes.Location = new System.Drawing.Point(162, 3);
            this.btnGetDeviceTypes.Name = "btnGetDeviceTypes";
            this.btnGetDeviceTypes.Size = new System.Drawing.Size(183, 23);
            this.btnGetDeviceTypes.TabIndex = 2;
            this.btnGetDeviceTypes.Text = "Get DeviceTypes (26)";
            this.btnGetDeviceTypes.UseVisualStyleBackColor = true;
            this.btnGetDeviceTypes.Click += new System.EventHandler(this.btnGetDeviceTypes_Click);
            // 
            // lstEvents
            // 
            this.lstEvents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstEvents.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstEvents.FormattingEnabled = true;
            this.lstEvents.ItemHeight = 14;
            this.lstEvents.Location = new System.Drawing.Point(1031, 34);
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(513, 186);
            this.lstEvents.TabIndex = 6;
            // 
            // btnSetVisibilityNotifyIcon
            // 
            this.btnSetVisibilityNotifyIcon.Location = new System.Drawing.Point(534, 164);
            this.btnSetVisibilityNotifyIcon.Name = "btnSetVisibilityNotifyIcon";
            this.btnSetVisibilityNotifyIcon.Size = new System.Drawing.Size(174, 23);
            this.btnSetVisibilityNotifyIcon.TabIndex = 2;
            this.btnSetVisibilityNotifyIcon.Text = "SetVisibitity (53) = NotifyIcon (2)";
            this.btnSetVisibilityNotifyIcon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetVisibilityNotifyIcon.UseVisualStyleBackColor = true;
            this.btnSetVisibilityNotifyIcon.Click += new System.EventHandler(this.btnSetVisibility_Click);
            // 
            // btnSetVisibilityWindow
            // 
            this.btnSetVisibilityWindow.Location = new System.Drawing.Point(534, 135);
            this.btnSetVisibilityWindow.Name = "btnSetVisibilityWindow";
            this.btnSetVisibilityWindow.Size = new System.Drawing.Size(174, 23);
            this.btnSetVisibilityWindow.TabIndex = 2;
            this.btnSetVisibilityWindow.Text = "SetVisibitity (53) = Window (1)";
            this.btnSetVisibilityWindow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetVisibilityWindow.UseVisualStyleBackColor = true;
            this.btnSetVisibilityWindow.Click += new System.EventHandler(this.btnSetVisibility_Click);
            // 
            // btnSetVisibilityHidden
            // 
            this.btnSetVisibilityHidden.Location = new System.Drawing.Point(534, 106);
            this.btnSetVisibilityHidden.Name = "btnSetVisibilityHidden";
            this.btnSetVisibilityHidden.Size = new System.Drawing.Size(174, 23);
            this.btnSetVisibilityHidden.TabIndex = 2;
            this.btnSetVisibilityHidden.Text = "SetVisibitity (53) = Hidden (0)";
            this.btnSetVisibilityHidden.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetVisibilityHidden.UseVisualStyleBackColor = true;
            this.btnSetVisibilityHidden.Click += new System.EventHandler(this.btnSetVisibility_Click);
            // 
            // btnGetScreensGraphic
            // 
            this.btnGetScreensGraphic.Location = new System.Drawing.Point(534, 292);
            this.btnGetScreensGraphic.Name = "btnGetScreensGraphic";
            this.btnGetScreensGraphic.Size = new System.Drawing.Size(171, 23);
            this.btnGetScreensGraphic.TabIndex = 2;
            this.btnGetScreensGraphic.Text = "Get Screens Graphic (70)";
            this.btnGetScreensGraphic.UseVisualStyleBackColor = true;
            this.btnGetScreensGraphic.Visible = false;
            this.btnGetScreensGraphic.Click += new System.EventHandler(this.btnGetGraphic_Click);
            // 
            // btnGetKeyboardGraphic
            // 
            this.btnGetKeyboardGraphic.Location = new System.Drawing.Point(534, 350);
            this.btnGetKeyboardGraphic.Name = "btnGetKeyboardGraphic";
            this.btnGetKeyboardGraphic.Size = new System.Drawing.Size(171, 23);
            this.btnGetKeyboardGraphic.TabIndex = 2;
            this.btnGetKeyboardGraphic.Text = "Get Keyboard Graphic (69)";
            this.btnGetKeyboardGraphic.UseVisualStyleBackColor = true;
            this.btnGetKeyboardGraphic.Visible = false;
            this.btnGetKeyboardGraphic.Click += new System.EventHandler(this.btnGetGraphic_Click);
            // 
            // btnGetDeviceGraphic
            // 
            this.btnGetDeviceGraphic.Location = new System.Drawing.Point(534, 321);
            this.btnGetDeviceGraphic.Name = "btnGetDeviceGraphic";
            this.btnGetDeviceGraphic.Size = new System.Drawing.Size(171, 23);
            this.btnGetDeviceGraphic.TabIndex = 2;
            this.btnGetDeviceGraphic.Text = "Get Device Graphic (52)";
            this.btnGetDeviceGraphic.UseVisualStyleBackColor = true;
            this.btnGetDeviceGraphic.Click += new System.EventHandler(this.btnGetGraphic_Click);
            // 
            // btnGetDeviceInfo
            // 
            this.btnGetDeviceInfo.Location = new System.Drawing.Point(534, 34);
            this.btnGetDeviceInfo.Name = "btnGetDeviceInfo";
            this.btnGetDeviceInfo.Size = new System.Drawing.Size(150, 23);
            this.btnGetDeviceInfo.TabIndex = 2;
            this.btnGetDeviceInfo.Text = "Get Device Info (20)";
            this.btnGetDeviceInfo.UseVisualStyleBackColor = true;
            this.btnGetDeviceInfo.Click += new System.EventHandler(this.btnGetDeviceInfo_Click);
            // 
            // btnTrigger
            // 
            this.btnTrigger.Location = new System.Drawing.Point(84, 118);
            this.btnTrigger.Name = "btnTrigger";
            this.btnTrigger.Size = new System.Drawing.Size(71, 23);
            this.btnTrigger.TabIndex = 2;
            this.btnTrigger.Text = "Trigger (6)";
            this.btnTrigger.UseVisualStyleBackColor = true;
            this.btnTrigger.Click += new System.EventHandler(this.btnTrigger_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 9);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 17;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // chkCanGetFocus
            // 
            this.chkCanGetFocus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCanGetFocus.ForeColor = System.Drawing.Color.DarkRed;
            this.chkCanGetFocus.Location = new System.Drawing.Point(1465, 7);
            this.chkCanGetFocus.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.chkCanGetFocus.Name = "chkCanGetFocus";
            this.chkCanGetFocus.Size = new System.Drawing.Size(94, 23);
            this.chkCanGetFocus.TabIndex = 118;
            this.chkCanGetFocus.Text = "Can get focus";
            this.chkCanGetFocus.UseVisualStyleBackColor = true;
            this.chkCanGetFocus.CheckedChanged += new System.EventHandler(this.chkCanGetFocus_CheckedChanged);
            // 
            // chkSetNotification1000
            // 
            this.chkSetNotification1000.Location = new System.Drawing.Point(714, 263);
            this.chkSetNotification1000.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.chkSetNotification1000.Name = "chkSetNotification1000";
            this.chkSetNotification1000.Size = new System.Drawing.Size(290, 17);
            this.chkSetNotification1000.TabIndex = 118;
            this.chkSetNotification1000.Text = "0x1000 Debug Messages";
            this.chkSetNotification1000.UseVisualStyleBackColor = true;
            this.chkSetNotification1000.CheckedChanged += new System.EventHandler(this.chkSetNotificationsMask_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1571, 761);
            this.Controls.Add(this.chkCanGetFocus);
            this.Controls.Add(this.chkAutoconnect);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.gbClient);
            this.Controls.Add(this.btnConnect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(10, 10);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MVBD Test Client";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.gbClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnGetBrailleDevices;
        private System.Windows.Forms.Button btnGetNotificationsMask;
        private System.Windows.Forms.CheckBox chkSetNotification0020;
        private System.Windows.Forms.CheckBox chkSetNotification0010;
        private System.Windows.Forms.CheckBox chkSetNotification0008;
        private System.Windows.Forms.CheckBox chkSetNotification0004;
        private System.Windows.Forms.CheckBox chkSetNotification0002;
        private System.Windows.Forms.CheckBox chkSetNotification0001;
        private System.Windows.Forms.Button btnEventsClear;
        private System.Windows.Forms.Button btnGetVersion;
        private System.Windows.Forms.ComboBox cboIdentifier;
        private System.Windows.Forms.Label lblPins;
        private System.Windows.Forms.CheckBox chkAutoconnect;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.Button btnTcpRoots;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblEvents;
        private System.Windows.Forms.Panel gbClient;
        private System.Windows.Forms.CheckBox chkPinPlayer;
        private System.Windows.Forms.Button btnSendKeyLeft;
        private System.Windows.Forms.Button btnSendKeyRight;
        private System.Windows.Forms.Button btnSendPinsAsMVDA;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnGetPins;
        private System.Windows.Forms.Button btnAllOn;
        private System.Windows.Forms.Label lblIdentifier;
        private System.Windows.Forms.Label lblPWMValue;
        private System.Windows.Forms.Button btnAllOff;
        private System.Windows.Forms.ComboBox cboPWMValue;
        private System.Windows.Forms.Button btnGetDeviceTypes;
        private System.Windows.Forms.ListBox lstEvents;
        private System.Windows.Forms.Button btnSetVisibilityNotifyIcon;
        private System.Windows.Forms.Button btnSetVisibilityWindow;
        private System.Windows.Forms.Button btnSetVisibilityHidden;
        private System.Windows.Forms.Button btnGetDeviceGraphic;
        private System.Windows.Forms.Button btnGetDeviceInfo;
        private System.Windows.Forms.Button btnTrigger;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.CheckBox chkSetNotification0040;
        private System.Windows.Forms.Button btnMouseMove;
        private System.Windows.Forms.PictureBox picView;
        private System.Windows.Forms.CheckBox chkSetNotification0100;
        private System.Windows.Forms.CheckBox chkSetNotification0080;
        private System.Windows.Forms.CheckBox chkSetNotification0200;
        private System.Windows.Forms.Button btnGetScreensGraphic;
        private System.Windows.Forms.Button btnGetKeyboardGraphic;
        private System.Windows.Forms.Button btnGetConfigurations;
        private System.Windows.Forms.CheckBox chkSetConfiguration00;
        private System.Windows.Forms.CheckBox chkSetConfiguration09;
        private System.Windows.Forms.CheckBox chkSetConfiguration08;
        private System.Windows.Forms.CheckBox chkSetConfiguration07;
        private System.Windows.Forms.CheckBox chkSetConfiguration06;
        private System.Windows.Forms.CheckBox chkSetConfiguration05;
        private System.Windows.Forms.CheckBox chkSetConfiguration04;
        private System.Windows.Forms.CheckBox chkSetConfiguration03;
        private System.Windows.Forms.CheckBox chkSetConfiguration02;
        private System.Windows.Forms.CheckBox chkSetConfiguration01;
        private System.Windows.Forms.CheckBox chkSetConfiguration13;
        private System.Windows.Forms.CheckBox chkSetConfiguration12;
        private System.Windows.Forms.CheckBox chkSetConfiguration11;
        private System.Windows.Forms.CheckBox chkSetConfiguration10;
        private System.Windows.Forms.CheckBox chkSetConfiguration14;
        private System.Windows.Forms.CheckBox chkSetConfiguration15;
        private System.Windows.Forms.CheckBox chkCanGetFocus;
        private System.Windows.Forms.Button btnTestSendKeys;
        private System.Windows.Forms.CheckBox chkSetNotification0400;
        private System.Windows.Forms.CheckBox chkSetConfiguration18;
        private System.Windows.Forms.CheckBox chkSetConfiguration17;
        private System.Windows.Forms.CheckBox chkSetConfiguration16;
        private System.Windows.Forms.CheckBox chkSetConfiguration19;
        private System.Windows.Forms.Button btnSendFinger;
        private System.Windows.Forms.CheckBox chkSetNotification0800;
        private System.Windows.Forms.CheckBox chkSetNotification1000;
    }
}

