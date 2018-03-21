using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.rssb.win.services.ffc.classes;
using com.rssb.win.services.ffc.enums;
using System.IO;

namespace com.rssb.win.services.ffc.helper
{
    
    public static class ExecuteProcess
    {
        public const string _FileName = "eventLog.txt";

        public static void scanPreviousData()
        { scanPreviousData(true); }
        public static void scanCurrentFileSystem()
        { scanCurrentFileSystem(true); }

        public static void scanPreviousData(bool physicalDelete)
        {
            DateTime startTime = DateTime.Now;
            try
            {
                startTime = DateTime.Now;
                ScannedFiles scannedFiles = new ScannedFiles();
                //run the scan and pass application setting values.
                ApplicationSettings settings = new ApplicationSettings();
                //initialise file system component
                FileSystem fileSystem = new FileSystem();

                FilesFailedToDelete filesFailedToDeleteInstance = FilesFailedToDelete.GetInstance();
                FilesForNextIteration filesForNextIterationInstance = FilesForNextIteration.GetInstance();

                filesFailedToDeleteInstance.DatabaseType = settings.DatabaseType;

                ScannedFiles filesFailedToDelete = filesFailedToDeleteInstance.GetFiles();
                ScannedFiles filesForNextIteration = filesForNextIterationInstance.GetFiles();

                scannedFiles.AddRange(filesFailedToDelete);
                scannedFiles.AddRange(filesForNextIteration);
                
                fileSystem.DatabaseType = settings.DatabaseType;
                fileSystem.SaveToCSVFile = settings.FileDeleteCSVFile;
                fileSystem.PhysicalDelete = physicalDelete;
                ScannedFiles files = fileSystem.RunScan(settings.FileAgeLimit, FileDateProperty.DateModified, scannedFiles);
                File.AppendAllText(_FileName, "\r\n" + DateTime.Now.ToString() + ": " + files.Count.ToString() + " files were scanned for previous files -scanPreviousData()");

            }
            catch (Exception ex)
            {
                //logFFCBatch.WriteEntry( DateTime.Now.ToString() + ": Error Occured: " + ex.Message + "-scanPreviousData()");
                File.AppendAllText(_FileName, "\r\n" + DateTime.Now.ToString() + ": Error Occured: " + ex.Message + "-scanPreviousData()");
            }
            finally
            {
                //logFFCBatch.WriteEntry( DateTime.Now.ToString() + ": Finished previous scanning job @ " + System.DateTime.Now.ToString() + " and took " + DateTime.Now.Subtract(startTime).Minutes + " min. -scanPreviousData()");
                File.AppendAllText(_FileName, "\r\n" + DateTime.Now.ToString() + ": Finished previous scanning job @ " + System.DateTime.Now.ToString() + " and took " + DateTime.Now.Subtract(startTime).Seconds + " sec(s). -scanPreviousData()");
            }

        }

        public static void scanCurrentFileSystem(bool physicalDelete)
        {
            DateTime startTime = DateTime.Now;
            try
            {
                startTime = DateTime.Now;


                //initialise file system component
                FileSystem fileSystem = new FileSystem();

                //run the scan and pass application setting values.
                ApplicationSettings settings = new ApplicationSettings();
                fileSystem.DatabaseType = settings.DatabaseType;
                fileSystem.SaveToCSVFile = settings.FileDeleteCSVFile;
                fileSystem.PhysicalDelete = physicalDelete;
                ScannedFiles files = fileSystem.RunScan(settings.FileAgeLimit, FileDateProperty.DateModified, settings.DirectoryToScan);
                File.AppendAllText(_FileName, "\r\n" + DateTime.Now.ToString() + ": " + files.Count.ToString() + " files were scanned on current file system -scanCurrentFileSystem()");
            }
            catch (Exception ex)
            {
                //logFFCBatch.WriteEntry(DateTime.Now.ToString() + ": Error Occured: " + ex.Message + "-scanCurrentFileSystem()");
                File.AppendAllText(_FileName, "\r\n" + DateTime.Now.ToString() + ": Error Occured: " + ex.Message + "-scanCurrentFileSystem()");
            }
            finally
            {
                //logFFCBatch.WriteEntry(DateTime.Now.ToString() + ": Finished scanning current file system job @ " + System.DateTime.Now.ToString() + " and took " + DateTime.Now.Subtract(startTime).Minutes + " min. -scanCurrentFileSystem()");
                File.AppendAllText(_FileName, "\r\n" + DateTime.Now.ToString() + ": Finished scanning current file system job @ " + System.DateTime.Now.ToString() + " and took " + DateTime.Now.Subtract(startTime).Seconds + " sec. -scanCurrentFileSystem()");
            }
        }
    }
}
