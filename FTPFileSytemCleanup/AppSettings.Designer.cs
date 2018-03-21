namespace com.rssb.win.services.ffc
{
    partial class frmAppSettings
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDirectoryToScan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFileAgeLimit = new System.Windows.Forms.TextBox();
            this.lstDirectoryToScan = new System.Windows.Forms.ListBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.btnRemoveFromList = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtServiceInterval = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rdoSQLDatabase = new System.Windows.Forms.RadioButton();
            this.rdoCSVDatabase = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFileDeleteCSVFile = new System.Windows.Forms.TextBox();
            this.btnBrowseCSV = new System.Windows.Forms.Button();
            this.fbdBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDelimeter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(405, 332);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(297, 332);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(138, 41);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(138, 21);
            this.txtServer.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Database:";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(139, 68);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(137, 21);
            this.txtDatabase.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "User:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(345, 41);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(150, 21);
            this.txtUser.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(345, 68);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(150, 21);
            this.txtPassword.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Directory To Scan:";
            // 
            // txtDirectoryToScan
            // 
            this.txtDirectoryToScan.Location = new System.Drawing.Point(139, 185);
            this.txtDirectoryToScan.Name = "txtDirectoryToScan";
            this.txtDirectoryToScan.Size = new System.Drawing.Size(357, 21);
            this.txtDirectoryToScan.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "File Age Limit:";
            // 
            // txtFileAgeLimit
            // 
            this.txtFileAgeLimit.Location = new System.Drawing.Point(139, 273);
            this.txtFileAgeLimit.Name = "txtFileAgeLimit";
            this.txtFileAgeLimit.Size = new System.Drawing.Size(58, 21);
            this.txtFileAgeLimit.TabIndex = 12;
            // 
            // lstDirectoryToScan
            // 
            this.lstDirectoryToScan.FormattingEnabled = true;
            this.lstDirectoryToScan.Location = new System.Drawing.Point(139, 214);
            this.lstDirectoryToScan.Name = "lstDirectoryToScan";
            this.lstDirectoryToScan.Size = new System.Drawing.Size(321, 43);
            this.lstDirectoryToScan.TabIndex = 14;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(365, 95);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(130, 23);
            this.btnTestConnection.TabIndex = 15;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(15, 315);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 11);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(469, 214);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(26, 21);
            this.btnAddToList.TabIndex = 18;
            this.btnAddToList.Text = "+";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // btnRemoveFromList
            // 
            this.btnRemoveFromList.Location = new System.Drawing.Point(469, 236);
            this.btnRemoveFromList.Name = "btnRemoveFromList";
            this.btnRemoveFromList.Size = new System.Drawing.Size(27, 21);
            this.btnRemoveFromList.TabIndex = 19;
            this.btnRemoveFromList.Text = "-";
            this.btnRemoveFromList.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(203, 276);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "day(s).";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Application Settings:";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(156, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 12);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(133, 166);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(363, 8);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(313, 279);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "* Execute Service Every:";
            // 
            // txtServiceInterval
            // 
            this.txtServiceInterval.Location = new System.Drawing.Point(438, 276);
            this.txtServiceInterval.Name = "txtServiceInterval";
            this.txtServiceInterval.Size = new System.Drawing.Size(58, 21);
            this.txtServiceInterval.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(14, 332);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(277, 31);
            this.label10.TabIndex = 26;
            this.label10.Text = "* Must be in this fomat: 00H or 00M or 00S where \'00\' can be replaced with 2 digi" +
    "t number.";
            // 
            // rdoSQLDatabase
            // 
            this.rdoSQLDatabase.AutoSize = true;
            this.rdoSQLDatabase.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSQLDatabase.Location = new System.Drawing.Point(11, 19);
            this.rdoSQLDatabase.Name = "rdoSQLDatabase";
            this.rdoSQLDatabase.Size = new System.Drawing.Size(147, 17);
            this.rdoSQLDatabase.TabIndex = 27;
            this.rdoSQLDatabase.TabStop = true;
            this.rdoSQLDatabase.Text = "SQL Server Database:";
            this.rdoSQLDatabase.UseVisualStyleBackColor = true;
            this.rdoSQLDatabase.CheckedChanged += new System.EventHandler(this.rdoSQLDatabase_CheckedChanged);
            // 
            // rdoCSVDatabase
            // 
            this.rdoCSVDatabase.AutoSize = true;
            this.rdoCSVDatabase.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCSVDatabase.Location = new System.Drawing.Point(11, 117);
            this.rdoCSVDatabase.Name = "rdoCSVDatabase";
            this.rdoCSVDatabase.Size = new System.Drawing.Size(99, 17);
            this.rdoCSVDatabase.TabIndex = 28;
            this.rdoCSVDatabase.TabStop = true;
            this.rdoCSVDatabase.Text = "CSV Settings:";
            this.rdoCSVDatabase.UseVisualStyleBackColor = true;
            this.rdoCSVDatabase.CheckedChanged += new System.EventHandler(this.rdoCSVDatabase_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(116, 122);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(380, 12);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Log File Path:";
            // 
            // txtFileDeleteCSVFile
            // 
            this.txtFileDeleteCSVFile.Location = new System.Drawing.Point(139, 140);
            this.txtFileDeleteCSVFile.Name = "txtFileDeleteCSVFile";
            this.txtFileDeleteCSVFile.Size = new System.Drawing.Size(321, 21);
            this.txtFileDeleteCSVFile.TabIndex = 30;
            // 
            // btnBrowseCSV
            // 
            this.btnBrowseCSV.Location = new System.Drawing.Point(466, 139);
            this.btnBrowseCSV.Name = "btnBrowseCSV";
            this.btnBrowseCSV.Size = new System.Drawing.Size(29, 21);
            this.btnBrowseCSV.TabIndex = 32;
            this.btnBrowseCSV.Text = "...";
            this.btnBrowseCSV.UseVisualStyleBackColor = true;
            this.btnBrowseCSV.Click += new System.EventHandler(this.btnBrowseCSV_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 303);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "Delimeter:";
            // 
            // txtDelimeter
            // 
            this.txtDelimeter.Location = new System.Drawing.Point(138, 300);
            this.txtDelimeter.Name = "txtDelimeter";
            this.txtDelimeter.Size = new System.Drawing.Size(58, 21);
            this.txtDelimeter.TabIndex = 33;
            // 
            // frmAppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 372);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtDelimeter);
            this.Controls.Add(this.btnBrowseCSV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFileDeleteCSVFile);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.rdoCSVDatabase);
            this.Controls.Add(this.rdoSQLDatabase);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtServiceInterval);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnRemoveFromList);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.lstDirectoryToScan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFileAgeLimit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDirectoryToScan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAppSettings";
            this.Text = "Application Settings";
            this.Load += new System.EventHandler(this.frmAppSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDirectoryToScan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFileAgeLimit;
        private System.Windows.Forms.ListBox lstDirectoryToScan;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.Button btnRemoveFromList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtServiceInterval;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rdoSQLDatabase;
        private System.Windows.Forms.RadioButton rdoCSVDatabase;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFileDeleteCSVFile;
        private System.Windows.Forms.Button btnBrowseCSV;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowserDialog;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDelimeter;
    }
}

