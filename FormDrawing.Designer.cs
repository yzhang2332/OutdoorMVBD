namespace Metec.MVBDClient
{
    partial class FormDrawing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDrawing));
            this.tmrStatus = new System.Windows.Forms.Timer(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnPinsClear = new System.Windows.Forms.Button();
            this.btnPinsDrawLine = new System.Windows.Forms.Button();
            this.btnPinsDrawCircle = new System.Windows.Forms.Button();
            this.btnPinsDrawPolygon = new System.Windows.Forms.Button();
            this.btnPinsDrawRectangle = new System.Windows.Forms.Button();
            this.txtSpeakText = new System.Windows.Forms.TextBox();
            this.lblSpeakText = new System.Windows.Forms.Label();
            this.lblPinsDraw = new System.Windows.Forms.Label();
            this.btnPinsFlush = new System.Windows.Forms.Button();
            this.chkPinsAutoClear = new System.Windows.Forms.CheckBox();
            this.chkPinsAutoFlush = new System.Windows.Forms.CheckBox();
            this.btnSpeakText = new System.Windows.Forms.Button();
            this.chkIsListening = new System.Windows.Forms.CheckBox();
            this.lstEvents = new System.Windows.Forms.ListBox();
            this.btnDrawGrid = new System.Windows.Forms.Button();
            this.btnLoadScene = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnDrawScene = new System.Windows.Forms.Button();
            this.btnClearBuffer = new System.Windows.Forms.Button();
            this.tmr_refresh = new System.Windows.Forms.Timer(this.components);
            this.spSerialPort = new System.IO.Ports.SerialPort(this.components);
            this.lblIMUData = new System.Windows.Forms.Label();
            this.chkEnableIMU = new System.Windows.Forms.CheckBox();
            this.chkChineseSpeech = new System.Windows.Forms.CheckBox();
            this.chkImmediateVoice = new System.Windows.Forms.CheckBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.chkPrintEvents = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tmrStatus
            // 
            this.tmrStatus.Enabled = true;
            this.tmrStatus.Interval = 300;
            this.tmrStatus.Tick += new System.EventHandler(this.tmrStatus_Tick);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(13, 10);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(579, 19);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPinsClear
            // 
            this.btnPinsClear.Location = new System.Drawing.Point(15, 204);
            this.btnPinsClear.Name = "btnPinsClear";
            this.btnPinsClear.Size = new System.Drawing.Size(100, 21);
            this.btnPinsClear.TabIndex = 1;
            this.btnPinsClear.Text = "Clear (35)";
            this.btnPinsClear.UseVisualStyleBackColor = true;
            this.btnPinsClear.Click += new System.EventHandler(this.btnPinsClear_Click);
            // 
            // btnPinsDrawLine
            // 
            this.btnPinsDrawLine.Location = new System.Drawing.Point(15, 81);
            this.btnPinsDrawLine.Name = "btnPinsDrawLine";
            this.btnPinsDrawLine.Size = new System.Drawing.Size(150, 21);
            this.btnPinsDrawLine.TabIndex = 3;
            this.btnPinsDrawLine.Text = "Draw Line (37)";
            this.btnPinsDrawLine.UseVisualStyleBackColor = true;
            this.btnPinsDrawLine.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // btnPinsDrawCircle
            // 
            this.btnPinsDrawCircle.Location = new System.Drawing.Point(15, 135);
            this.btnPinsDrawCircle.Name = "btnPinsDrawCircle";
            this.btnPinsDrawCircle.Size = new System.Drawing.Size(150, 21);
            this.btnPinsDrawCircle.TabIndex = 5;
            this.btnPinsDrawCircle.Text = "Draw Circle (40)";
            this.btnPinsDrawCircle.UseVisualStyleBackColor = true;
            this.btnPinsDrawCircle.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // btnPinsDrawPolygon
            // 
            this.btnPinsDrawPolygon.Location = new System.Drawing.Point(15, 108);
            this.btnPinsDrawPolygon.Name = "btnPinsDrawPolygon";
            this.btnPinsDrawPolygon.Size = new System.Drawing.Size(150, 21);
            this.btnPinsDrawPolygon.TabIndex = 4;
            this.btnPinsDrawPolygon.Text = "Draw Polygon (39)";
            this.btnPinsDrawPolygon.UseVisualStyleBackColor = true;
            this.btnPinsDrawPolygon.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // btnPinsDrawRectangle
            // 
            this.btnPinsDrawRectangle.Location = new System.Drawing.Point(15, 54);
            this.btnPinsDrawRectangle.Name = "btnPinsDrawRectangle";
            this.btnPinsDrawRectangle.Size = new System.Drawing.Size(150, 21);
            this.btnPinsDrawRectangle.TabIndex = 2;
            this.btnPinsDrawRectangle.Text = "Draw Rectangle (38)";
            this.btnPinsDrawRectangle.UseVisualStyleBackColor = true;
            this.btnPinsDrawRectangle.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // txtSpeakText
            // 
            this.txtSpeakText.Location = new System.Drawing.Point(225, 54);
            this.txtSpeakText.MaxLength = 255;
            this.txtSpeakText.Name = "txtSpeakText";
            this.txtSpeakText.Size = new System.Drawing.Size(272, 21);
            this.txtSpeakText.TabIndex = 6;
            this.txtSpeakText.Text = "Hallo!";
            this.txtSpeakText.WordWrap = false;
            this.txtSpeakText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSpeakText_KeyPress);
            // 
            // lblSpeakText
            // 
            this.lblSpeakText.AutoSize = true;
            this.lblSpeakText.Location = new System.Drawing.Point(222, 40);
            this.lblSpeakText.Name = "lblSpeakText";
            this.lblSpeakText.Size = new System.Drawing.Size(269, 12);
            this.lblSpeakText.TabIndex = 7;
            this.lblSpeakText.Text = "Speak a short text in the MVBD (Enter sends)";
            // 
            // lblPinsDraw
            // 
            this.lblPinsDraw.AutoSize = true;
            this.lblPinsDraw.Location = new System.Drawing.Point(12, 40);
            this.lblPinsDraw.Name = "lblPinsDraw";
            this.lblPinsDraw.Size = new System.Drawing.Size(161, 12);
            this.lblPinsDraw.TabIndex = 7;
            this.lblPinsDraw.Text = "Draw with random positions";
            // 
            // btnPinsFlush
            // 
            this.btnPinsFlush.Location = new System.Drawing.Point(15, 231);
            this.btnPinsFlush.Name = "btnPinsFlush";
            this.btnPinsFlush.Size = new System.Drawing.Size(100, 21);
            this.btnPinsFlush.TabIndex = 1;
            this.btnPinsFlush.Text = "Flush (36)";
            this.btnPinsFlush.UseVisualStyleBackColor = true;
            this.btnPinsFlush.Click += new System.EventHandler(this.btnPinsFlush_Click);
            // 
            // chkPinsAutoClear
            // 
            this.chkPinsAutoClear.AutoSize = true;
            this.chkPinsAutoClear.Checked = true;
            this.chkPinsAutoClear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPinsAutoClear.Location = new System.Drawing.Point(15, 162);
            this.chkPinsAutoClear.Name = "chkPinsAutoClear";
            this.chkPinsAutoClear.Size = new System.Drawing.Size(174, 16);
            this.chkPinsAutoClear.TabIndex = 8;
            this.chkPinsAutoClear.Text = "Send Clear before Draw...";
            this.chkPinsAutoClear.UseVisualStyleBackColor = true;
            // 
            // chkPinsAutoFlush
            // 
            this.chkPinsAutoFlush.AutoSize = true;
            this.chkPinsAutoFlush.Checked = true;
            this.chkPinsAutoFlush.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPinsAutoFlush.Location = new System.Drawing.Point(15, 183);
            this.chkPinsAutoFlush.Name = "chkPinsAutoFlush";
            this.chkPinsAutoFlush.Size = new System.Drawing.Size(168, 16);
            this.chkPinsAutoFlush.TabIndex = 8;
            this.chkPinsAutoFlush.Text = "Send Flush after Draw...";
            this.chkPinsAutoFlush.UseVisualStyleBackColor = true;
            // 
            // btnSpeakText
            // 
            this.btnSpeakText.Location = new System.Drawing.Point(503, 54);
            this.btnSpeakText.Name = "btnSpeakText";
            this.btnSpeakText.Size = new System.Drawing.Size(100, 21);
            this.btnSpeakText.TabIndex = 9;
            this.btnSpeakText.Text = "Send Text (41)";
            this.btnSpeakText.UseVisualStyleBackColor = true;
            this.btnSpeakText.Click += new System.EventHandler(this.btnSpeakText_Click);
            // 
            // chkIsListening
            // 
            this.chkIsListening.AutoSize = true;
            this.chkIsListening.Checked = true;
            this.chkIsListening.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsListening.Location = new System.Drawing.Point(224, 81);
            this.chkIsListening.Name = "chkIsListening";
            this.chkIsListening.Size = new System.Drawing.Size(96, 16);
            this.chkIsListening.TabIndex = 10;
            this.chkIsListening.Text = "Is Listening";
            this.chkIsListening.UseVisualStyleBackColor = true;
            this.chkIsListening.CheckedChanged += new System.EventHandler(this.chkIsListening_CheckedChanged);
            // 
            // lstEvents
            // 
            this.lstEvents.FormattingEnabled = true;
            this.lstEvents.ItemHeight = 12;
            this.lstEvents.Location = new System.Drawing.Point(224, 103);
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(379, 196);
            this.lstEvents.TabIndex = 11;
            // 
            // btnDrawGrid
            // 
            this.btnDrawGrid.Location = new System.Drawing.Point(71, 278);
            this.btnDrawGrid.Name = "btnDrawGrid";
            this.btnDrawGrid.Size = new System.Drawing.Size(69, 21);
            this.btnDrawGrid.TabIndex = 12;
            this.btnDrawGrid.Text = "Draw Grid";
            this.btnDrawGrid.UseVisualStyleBackColor = true;
            this.btnDrawGrid.Click += new System.EventHandler(this.btnDrawGrid_Click);
            // 
            // btnLoadScene
            // 
            this.btnLoadScene.Location = new System.Drawing.Point(26, 326);
            this.btnLoadScene.Name = "btnLoadScene";
            this.btnLoadScene.Size = new System.Drawing.Size(75, 23);
            this.btnLoadScene.TabIndex = 13;
            this.btnLoadScene.Text = "Load";
            this.btnLoadScene.UseVisualStyleBackColor = true;
            this.btnLoadScene.Click += new System.EventHandler(this.btnLoadScene_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(120, 326);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(275, 21);
            this.txtPath.TabIndex = 14;
            // 
            // btnDrawScene
            // 
            this.btnDrawScene.Location = new System.Drawing.Point(26, 367);
            this.btnDrawScene.Name = "btnDrawScene";
            this.btnDrawScene.Size = new System.Drawing.Size(75, 25);
            this.btnDrawScene.TabIndex = 15;
            this.btnDrawScene.Text = "Draw Scene";
            this.btnDrawScene.UseVisualStyleBackColor = true;
            this.btnDrawScene.Click += new System.EventHandler(this.btnDrawScene_Click);
            // 
            // btnClearBuffer
            // 
            this.btnClearBuffer.Location = new System.Drawing.Point(119, 367);
            this.btnClearBuffer.Name = "btnClearBuffer";
            this.btnClearBuffer.Size = new System.Drawing.Size(89, 23);
            this.btnClearBuffer.TabIndex = 16;
            this.btnClearBuffer.Text = "Clear Buffer";
            this.btnClearBuffer.UseVisualStyleBackColor = true;
            this.btnClearBuffer.Click += new System.EventHandler(this.btnClearBuffer_Click);
            // 
            // tmr_refresh
            // 
            this.tmr_refresh.Interval = 500;
            this.tmr_refresh.Tick += new System.EventHandler(this.DisplayRefresh);
            // 
            // spSerialPort
            // 
            this.spSerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort_DataReceived);
            // 
            // lblIMUData
            // 
            this.lblIMUData.AutoSize = true;
            this.lblIMUData.Location = new System.Drawing.Point(496, 330);
            this.lblIMUData.Name = "lblIMUData";
            this.lblIMUData.Size = new System.Drawing.Size(41, 12);
            this.lblIMUData.TabIndex = 17;
            this.lblIMUData.Text = "label1";
            // 
            // chkEnableIMU
            // 
            this.chkEnableIMU.AutoSize = true;
            this.chkEnableIMU.Checked = true;
            this.chkEnableIMU.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableIMU.Location = new System.Drawing.Point(472, 304);
            this.chkEnableIMU.Name = "chkEnableIMU";
            this.chkEnableIMU.Size = new System.Drawing.Size(84, 16);
            this.chkEnableIMU.TabIndex = 18;
            this.chkEnableIMU.Text = "enable IMU";
            this.chkEnableIMU.UseVisualStyleBackColor = true;
            this.chkEnableIMU.CheckedChanged += new System.EventHandler(this.chkEnableIMU_CheckedChanged);
            // 
            // chkChineseSpeech
            // 
            this.chkChineseSpeech.AutoSize = true;
            this.chkChineseSpeech.Checked = true;
            this.chkChineseSpeech.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChineseSpeech.Location = new System.Drawing.Point(224, 373);
            this.chkChineseSpeech.Name = "chkChineseSpeech";
            this.chkChineseSpeech.Size = new System.Drawing.Size(108, 16);
            this.chkChineseSpeech.TabIndex = 19;
            this.chkChineseSpeech.Text = "Chinese Speech";
            this.chkChineseSpeech.UseVisualStyleBackColor = true;
            // 
            // chkImmediateVoice
            // 
            this.chkImmediateVoice.AutoSize = true;
            this.chkImmediateVoice.Checked = true;
            this.chkImmediateVoice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImmediateVoice.Location = new System.Drawing.Point(224, 352);
            this.chkImmediateVoice.Margin = new System.Windows.Forms.Padding(2);
            this.chkImmediateVoice.Name = "chkImmediateVoice";
            this.chkImmediateVoice.Size = new System.Drawing.Size(156, 16);
            this.chkImmediateVoice.TabIndex = 19;
            this.chkImmediateVoice.Text = "Send Voice Immediately";
            this.chkImmediateVoice.UseVisualStyleBackColor = true;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(429, 329);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 12);
            this.lblPort.TabIndex = 20;
            this.lblPort.Text = "Port";
            // 
            // chkPrintEvents
            // 
            this.chkPrintEvents.AutoSize = true;
            this.chkPrintEvents.Location = new System.Drawing.Point(368, 81);
            this.chkPrintEvents.Name = "chkPrintEvents";
            this.chkPrintEvents.Size = new System.Drawing.Size(96, 16);
            this.chkPrintEvents.TabIndex = 21;
            this.chkPrintEvents.Text = "Print Events";
            this.chkPrintEvents.UseVisualStyleBackColor = true;
            // 
            // FormDrawing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 413);
            this.Controls.Add(this.chkPrintEvents);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.chkChineseSpeech);
            this.Controls.Add(this.chkImmediateVoice);
            this.Controls.Add(this.chkEnableIMU);
            this.Controls.Add(this.lblIMUData);
            this.Controls.Add(this.btnClearBuffer);
            this.Controls.Add(this.btnDrawScene);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnLoadScene);
            this.Controls.Add(this.btnDrawGrid);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.chkIsListening);
            this.Controls.Add(this.btnSpeakText);
            this.Controls.Add(this.chkPinsAutoFlush);
            this.Controls.Add(this.chkPinsAutoClear);
            this.Controls.Add(this.lblPinsDraw);
            this.Controls.Add(this.lblSpeakText);
            this.Controls.Add(this.txtSpeakText);
            this.Controls.Add(this.btnPinsFlush);
            this.Controls.Add(this.btnPinsClear);
            this.Controls.Add(this.btnPinsDrawLine);
            this.Controls.Add(this.btnPinsDrawCircle);
            this.Controls.Add(this.btnPinsDrawPolygon);
            this.Controls.Add(this.btnPinsDrawRectangle);
            this.Controls.Add(this.lblStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDrawing";
            this.Text = "2nd Example (Drawings)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDrawing_FormClosing);
            this.Load += new System.EventHandler(this.FormDrawings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnPinsClear;
        private System.Windows.Forms.Button btnPinsDrawLine;
        private System.Windows.Forms.Button btnPinsDrawCircle;
        private System.Windows.Forms.Button btnPinsDrawPolygon;
        private System.Windows.Forms.Button btnPinsDrawRectangle;
        private System.Windows.Forms.TextBox txtSpeakText;
        private System.Windows.Forms.Label lblSpeakText;
        private System.Windows.Forms.Label lblPinsDraw;
        private System.Windows.Forms.Button btnPinsFlush;
        private System.Windows.Forms.CheckBox chkPinsAutoClear;
        private System.Windows.Forms.CheckBox chkPinsAutoFlush;
        private System.Windows.Forms.Button btnSpeakText;
        private System.Windows.Forms.CheckBox chkIsListening;
        private System.Windows.Forms.ListBox lstEvents;
        private System.Windows.Forms.Button btnDrawGrid;
        private System.Windows.Forms.Button btnLoadScene;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnDrawScene;
        private System.Windows.Forms.Button btnClearBuffer;
        private System.Windows.Forms.Timer tmr_refresh;
        private System.IO.Ports.SerialPort spSerialPort;
        private System.Windows.Forms.Label lblIMUData;
        private System.Windows.Forms.CheckBox chkEnableIMU;
        private System.Windows.Forms.CheckBox chkChineseSpeech;
        private System.Windows.Forms.CheckBox chkImmediateVoice;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.CheckBox chkPrintEvents;
    }
}