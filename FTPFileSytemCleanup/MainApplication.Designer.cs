namespace com.rssb.win.services.ffc
{
    partial class frmMain
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
            this.btnRunScan = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.lstScannedFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRunScan
            // 
            this.btnRunScan.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunScan.Location = new System.Drawing.Point(28, 84);
            this.btnRunScan.Name = "btnRunScan";
            this.btnRunScan.Size = new System.Drawing.Size(197, 36);
            this.btnRunScan.TabIndex = 0;
            this.btnRunScan.Text = "Run Scan";
            this.btnRunScan.UseVisualStyleBackColor = true;
            this.btnRunScan.Visible = false;
            this.btnRunScan.Click += new System.EventHandler(this.btnRunScan_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(28, 32);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(197, 36);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "Settings...";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // lstScannedFiles
            // 
            this.lstScannedFiles.FormattingEnabled = true;
            this.lstScannedFiles.Location = new System.Drawing.Point(28, 152);
            this.lstScannedFiles.Name = "lstScannedFiles";
            this.lstScannedFiles.Size = new System.Drawing.Size(503, 147);
            this.lstScannedFiles.TabIndex = 2;
            this.lstScannedFiles.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Scanned Files:";
            this.label1.Visible = false;
            // 
            // btnGetFiles
            // 
            this.btnGetFiles.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetFiles.Location = new System.Drawing.Point(253, 32);
            this.btnGetFiles.Name = "btnGetFiles";
            this.btnGetFiles.Size = new System.Drawing.Size(197, 36);
            this.btnGetFiles.TabIndex = 4;
            this.btnGetFiles.Text = "Report...";
            this.btnGetFiles.UseVisualStyleBackColor = true;
            this.btnGetFiles.Click += new System.EventHandler(this.btnGetFiles_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 78);
            this.Controls.Add(this.btnGetFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstScannedFiles);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnRunScan);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmMain";
            this.Text = "Administer FTP Filesystem Cleanup";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRunScan;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.ListBox lstScannedFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetFiles;
    }
}