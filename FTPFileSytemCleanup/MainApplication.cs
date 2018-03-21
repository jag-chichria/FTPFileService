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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnRunScan_Click(object sender, EventArgs e)
        {

            try
            {
                ScannedFiles files = null;
                ApplicationSettings settings = new ApplicationSettings();

                //initialise file system component
                FileSystem fileSystem = new FileSystem();

                
                FilesFailedToDelete filesFailedToDeleteInstance = FilesFailedToDelete.GetInstance();
                FilesForNextIteration filesForNextIterationInstance = FilesForNextIteration.GetInstance();


                ScannedFiles filesFailedToDelete = filesFailedToDeleteInstance.GetFiles();
                ScannedFiles filesForNextIteration = filesForNextIterationInstance.GetFiles();

                ScannedFiles scannedFiles = new ScannedFiles();
                scannedFiles.AddRange(filesFailedToDelete);
                scannedFiles.AddRange(filesForNextIteration);

                //run the scan passing the previous scan files data from database.
                //get new set of scanned files, and do some processing, if required.
                files = fileSystem.RunScan(settings.FileAgeLimit, FileDateProperty.DateModified, scannedFiles);
                

                /*
                //initialise file system component
                fileSystem = new FileSystem();

                //run the scan and pass application setting values.
                files = fileSystem.RunScan(settings.FileAgeLimit, FileDateProperty.DateModified, settings.DirectoryToScan);
                */
                
                
               
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmAppSettings appSettings = new frmAppSettings();
            appSettings.ShowDialog(this);
        }

        private void btnGetFiles_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.ShowDialog(this);

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
