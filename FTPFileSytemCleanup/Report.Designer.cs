namespace com.rssb.win.services.ffc
{
    partial class Report
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
            this.chkFilesDeleted = new System.Windows.Forms.CheckBox();
            this.chkFilesFailedToDelete = new System.Windows.Forms.CheckBox();
            this.chkFilesForNextIteration = new System.Windows.Forms.CheckBox();
            this.grdFiles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // chkFilesDeleted
            // 
            this.chkFilesDeleted.AutoSize = true;
            this.chkFilesDeleted.Location = new System.Drawing.Point(23, 12);
            this.chkFilesDeleted.Name = "chkFilesDeleted";
            this.chkFilesDeleted.Size = new System.Drawing.Size(87, 17);
            this.chkFilesDeleted.TabIndex = 0;
            this.chkFilesDeleted.Text = "Files Deleted";
            this.chkFilesDeleted.UseVisualStyleBackColor = true;
            this.chkFilesDeleted.CheckedChanged += new System.EventHandler(this.chkFilesDeleted_CheckedChanged);
            // 
            // chkFilesFailedToDelete
            // 
            this.chkFilesFailedToDelete.AutoSize = true;
            this.chkFilesFailedToDelete.Location = new System.Drawing.Point(207, 12);
            this.chkFilesFailedToDelete.Name = "chkFilesFailedToDelete";
            this.chkFilesFailedToDelete.Size = new System.Drawing.Size(119, 17);
            this.chkFilesFailedToDelete.TabIndex = 1;
            this.chkFilesFailedToDelete.Text = "Files failed to delete";
            this.chkFilesFailedToDelete.UseVisualStyleBackColor = true;
            this.chkFilesFailedToDelete.CheckedChanged += new System.EventHandler(this.chkFilesFailedToDelete_CheckedChanged);
            // 
            // chkFilesForNextIteration
            // 
            this.chkFilesForNextIteration.AutoSize = true;
            this.chkFilesForNextIteration.Location = new System.Drawing.Point(393, 12);
            this.chkFilesForNextIteration.Name = "chkFilesForNextIteration";
            this.chkFilesForNextIteration.Size = new System.Drawing.Size(125, 17);
            this.chkFilesForNextIteration.TabIndex = 2;
            this.chkFilesForNextIteration.Text = "Files for next iteration";
            this.chkFilesForNextIteration.UseVisualStyleBackColor = true;
            this.chkFilesForNextIteration.CheckedChanged += new System.EventHandler(this.chkFilesForNextIteration_CheckedChanged);
            // 
            // grdFiles
            // 
            this.grdFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFiles.Location = new System.Drawing.Point(23, 46);
            this.grdFiles.Name = "grdFiles";
            this.grdFiles.Size = new System.Drawing.Size(816, 413);
            this.grdFiles.TabIndex = 3;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 471);
            this.Controls.Add(this.grdFiles);
            this.Controls.Add(this.chkFilesForNextIteration);
            this.Controls.Add(this.chkFilesFailedToDelete);
            this.Controls.Add(this.chkFilesDeleted);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Report";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkFilesDeleted;
        private System.Windows.Forms.CheckBox chkFilesFailedToDelete;
        private System.Windows.Forms.CheckBox chkFilesForNextIteration;
        private System.Windows.Forms.DataGridView grdFiles;
    }
}