using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.rssb.win.services.ffc.classes;
using com.rssb.win.services.ffc.enums;

namespace com.rssb.win.services.ffc
{
    public partial class frmAppSettings : Form
    {
        public frmAppSettings()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Future implement
        /// </summary>
        private void btnAddToList_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Call SaveSettings
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                SaveSettings();
                Close();
            }
            catch
            { }
            
        }


        /// <summary>
        /// Call ReadSettings
        /// </summary>
        private void frmAppSettings_Load(object sender, EventArgs e)
        {
            ReadSettings();
        }


        /// <summary>
        /// save default/last saved settings
        /// </summary>
        private void SaveSettings()
        {
            ApplicationSettings settings = new ApplicationSettings();

            /// <summary>
            /// application settings
            /// </summary>
            settings.DirectoryToScan = txtDirectoryToScan.Text.Trim();
            settings.FileAgeLimit = Convert.ToInt32(txtFileAgeLimit.Text.Trim());
            settings.ServiceExecuteEvery = txtServiceInterval.Text.Trim();

            /// <summary>
            /// database settings
            /// </summary>
            settings.ServerName = txtServer.Text.Trim();
            settings.Database = txtDatabase.Text.Trim();
            settings.User = txtUser.Text.Trim();
            settings.Password = txtPassword.Text.Trim();

            settings.FileDeleteCSVFile = txtFileDeleteCSVFile.Text.Trim();
            settings.DatabaseType = rdoSQLDatabase.Checked ? DatabaseTypeEnum.SQLDatabase : DatabaseTypeEnum.CSVDatabase;
            settings.Delimeter = txtDelimeter.Text.Trim();
            settings.Save();
        }

        /// <summary>
        /// read default/last saved settings
        /// </summary>
        private void ReadSettings()
        {
            ApplicationSettings settings = new ApplicationSettings();
            settings.Get();

            /// <summary>
            /// application settings
            /// </summary>
            txtDirectoryToScan.Text = settings.DirectoryToScan.Trim();
            txtFileAgeLimit.Text = settings.FileAgeLimit.ToString();
            txtServiceInterval.Text = settings.ServiceExecuteEvery.ToString();

            /// <summary>
            /// database settings
            /// </summary>
            txtServer.Text = settings.ServerName.Trim();
            txtDatabase.Text = settings.Database.Trim();
            txtUser.Text = settings.User.Trim();
            txtPassword.Text = settings.Password;

            /// <summary>
            /// File Delete CSV File
            /// </summary>            
            txtFileDeleteCSVFile.Text = settings.FileDeleteCSVFile.Trim();

            rdoCSVDatabase.Checked = settings.DatabaseType == DatabaseTypeEnum.CSVDatabase;
            rdoSQLDatabase.Checked = settings.DatabaseType == DatabaseTypeEnum.SQLDatabase;

            //forcibly execute routine to enable/disable respective controls
            rdoCSVDatabase_CheckedChanged(null, null);
            rdoSQLDatabase_CheckedChanged(null, null);

            txtDelimeter.Text = settings.Delimeter;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {

            System.Data.SqlClient.SqlConnection connection = null;
            try
            {
                connection = new System.Data.SqlClient.SqlConnection();
               connection.ConnectionString = String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", txtServer.Text.Trim(), txtDatabase.Text.Trim(), txtUser.Text.Trim(), txtPassword.Text.Trim());
                connection.Open();
                MessageBox.Show("Text connection successful.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                if (connection != null && connection.State != ConnectionState.Closed)
                {
                    connection.Close(); 
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnBrowseCSV_Click(object sender, EventArgs e)
        {
            fbdBrowserDialog.Description = "Please select folder path to store the file deleted log. The log file name will be used as - filesrem.csv";            
            fbdBrowserDialog.ShowNewFolderButton = true;
            fbdBrowserDialog.SelectedPath = txtFileDeleteCSVFile.Text.Trim();
            fbdBrowserDialog.ShowDialog();
            txtFileDeleteCSVFile.Text = fbdBrowserDialog.SelectedPath + "\\filesrem.csv";
        }

        private void rdoSQLDatabase_CheckedChanged(object sender, EventArgs e)
        {
            btnTestConnection.Enabled = rdoSQLDatabase.Checked;
            txtServer.Enabled = rdoSQLDatabase.Checked;
            txtDatabase.Enabled = rdoSQLDatabase.Checked;
            txtPassword.Enabled = rdoSQLDatabase.Checked;
            txtUser.Enabled = rdoSQLDatabase.Checked;
        }

        private void rdoCSVDatabase_CheckedChanged(object sender, EventArgs e)
        {
            btnBrowseCSV.Enabled = rdoCSVDatabase.Checked;
            txtFileDeleteCSVFile.Enabled = rdoCSVDatabase.Checked;
        }        
    }
}
