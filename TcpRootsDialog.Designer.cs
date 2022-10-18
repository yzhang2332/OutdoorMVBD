namespace Metec.MVBDClient
{
    partial class TcpRootsDialog
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.cboCommands = new System.Windows.Forms.ComboBox();
            this.btnSetTcpRoots = new System.Windows.Forms.Button();
            this.chkSendImmediate = new System.Windows.Forms.CheckBox();
            this.btnGetTcpRoots = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(13, 143);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 50;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(626, 377);
            this.dgv.TabIndex = 0;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);
            // 
            // cboCommands
            // 
            this.cboCommands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCommands.FormattingEnabled = true;
            this.cboCommands.Location = new System.Drawing.Point(12, 116);
            this.cboCommands.Name = "cboCommands";
            this.cboCommands.Size = new System.Drawing.Size(121, 21);
            this.cboCommands.TabIndex = 1;
            this.cboCommands.SelectedIndexChanged += new System.EventHandler(this.cboCommands_SelectedIndexChanged);
            // 
            // btnSetTcpRoots
            // 
            this.btnSetTcpRoots.Location = new System.Drawing.Point(12, 41);
            this.btnSetTcpRoots.Name = "btnSetTcpRoots";
            this.btnSetTcpRoots.Size = new System.Drawing.Size(300, 23);
            this.btnSetTcpRoots.TabIndex = 3;
            this.btnSetTcpRoots.Text = "SetTcpRoots (32) Send full array";
            this.btnSetTcpRoots.UseVisualStyleBackColor = true;
            this.btnSetTcpRoots.Click += new System.EventHandler(this.btnSetTcpRoots_Click);
            // 
            // chkSendImmediate
            // 
            this.chkSendImmediate.Location = new System.Drawing.Point(13, 70);
            this.chkSendImmediate.Name = "chkSendImmediate";
            this.chkSendImmediate.Size = new System.Drawing.Size(299, 24);
            this.chkSendImmediate.TabIndex = 4;
            this.chkSendImmediate.Text = "Send immediate when changed with command (33)";
            this.chkSendImmediate.UseVisualStyleBackColor = true;
            this.chkSendImmediate.CheckedChanged += new System.EventHandler(this.chkSendImmediate_CheckedChanged);
            // 
            // btnGetTcpRoots
            // 
            this.btnGetTcpRoots.Location = new System.Drawing.Point(12, 12);
            this.btnGetTcpRoots.Name = "btnGetTcpRoots";
            this.btnGetTcpRoots.Size = new System.Drawing.Size(300, 23);
            this.btnGetTcpRoots.TabIndex = 5;
            this.btnGetTcpRoots.Text = "GetTcpRoots (31)";
            this.btnGetTcpRoots.UseVisualStyleBackColor = true;
            this.btnGetTcpRoots.Click += new System.EventHandler(this.btnGetTcpRoots_Click);
            // 
            // TcpRootsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 532);
            this.Controls.Add(this.btnGetTcpRoots);
            this.Controls.Add(this.chkSendImmediate);
            this.Controls.Add(this.btnSetTcpRoots);
            this.Controls.Add(this.cboCommands);
            this.Controls.Add(this.dgv);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "TcpRootsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tcp Roots";
            this.Load += new System.EventHandler(this.FormTcpRoots_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ComboBox cboCommands;
        private System.Windows.Forms.Button btnSetTcpRoots;
        private System.Windows.Forms.CheckBox chkSendImmediate;
        private System.Windows.Forms.Button btnGetTcpRoots;
    }
}