using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using com.rssb.win.services.ffc.classes;

namespace com.rssb.win.services.ffc
{
    public partial class Report : Form
    {
        ScannedFiles deletedfiles;
        ScannedFiles filesFailedToDelete;
        ScannedFiles filesForNextIteration;

        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            try
            {

                //ApplicationSettings appSettings = new ApplicationSettings();
                FilesDeleted fileDeletedInstance = FilesDeleted.GetInstance();
                deletedfiles = fileDeletedInstance.GetFiles();

                FilesFailedToDelete filesFailedToDeleteInstance = FilesFailedToDelete.GetInstance();
                filesFailedToDelete = filesFailedToDeleteInstance.GetFiles();

                FilesForNextIteration filesForNextIterationInstance = FilesForNextIteration.GetInstance();
                filesForNextIteration = filesForNextIterationInstance.GetFiles();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }

        private void updateGrid()
        { 
            ScannedFiles scannedFiles = new ScannedFiles();
            if (chkFilesDeleted.Checked) { scannedFiles.AddRange(deletedfiles); }
            if (chkFilesFailedToDelete.Checked) { scannedFiles.AddRange(filesFailedToDelete); }
            if (chkFilesForNextIteration.Checked) { scannedFiles.AddRange(filesForNextIteration); }

            grdFiles.DataSource = scannedFiles;            
        }

        private void chkFilesDeleted_CheckedChanged(object sender, EventArgs e)
        {
            this.updateGrid();
        }

        private void chkFilesFailedToDelete_CheckedChanged(object sender, EventArgs e)
        {
            this.updateGrid();
        }

        private void chkFilesForNextIteration_CheckedChanged(object sender, EventArgs e)
        {
            this.updateGrid();
        }
    }
}
