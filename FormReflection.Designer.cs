namespace MVBDClientReflection
{
    partial class FormReflection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReflection));
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStartReflection = new System.Windows.Forms.Button();
            this.tv = new MVBDClientReflection.GridTreeView();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(12, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(579, 21);
            this.lblStatus.TabIndex = 21;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStartReflection
            // 
            this.btnStartReflection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartReflection.Location = new System.Drawing.Point(645, 12);
            this.btnStartReflection.Name = "btnStartReflection";
            this.btnStartReflection.Size = new System.Drawing.Size(75, 23);
            this.btnStartReflection.TabIndex = 23;
            this.btnStartReflection.Text = "Start";
            this.btnStartReflection.UseVisualStyleBackColor = true;
            this.btnStartReflection.Click += new System.EventHandler(this.btnStartReflection_Click);
            // 
            // tv
            // 
            this.tv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tv.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.tv.FullRowSelect = true;
            this.tv.HideSelection = false;
            this.tv.Indent = 10;
            this.tv.ItemHeight = 20;
            this.tv.Location = new System.Drawing.Point(15, 41);
            this.tv.Name = "tv";
            this.tv.ShowLines = false;
            this.tv.ShowNodeToolTips = true;
            this.tv.Size = new System.Drawing.Size(705, 439);
            this.tv.TabIndex = 22;
            this.tv.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterExpand);
            // 
            // FormReflection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 492);
            this.Controls.Add(this.btnStartReflection);
            this.Controls.Add(this.tv);
            this.Controls.Add(this.lblStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReflection";
            this.Text = "Demo Reflection";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblStatus;
        private GridTreeView tv;
        private System.Windows.Forms.Button btnStartReflection;
    }
}

