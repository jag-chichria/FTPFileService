using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using com.rssb.win.services.ffc.enums;

namespace com.rssb.win.services.ffc.classes
{
    public class FileSystemCleanupFactory
    {
        public DatabaseTypeEnum DatabaseType { get; set; }
        public string SaveToCSVFile { get; set; }
        FileSystemCleanup objBaseScannedFile = null;
        public void AddFile(ActionToPerform action, ScannedFile fileInfo)
        {
            switch (action)
            {
                case ActionToPerform.FileFailedToDelete:
                    objBaseScannedFile = FilesFailedToDelete.GetInstance();
                    break;
                case ActionToPerform.FileForNextIteration:
                    objBaseScannedFile = FilesForNextIteration.GetInstance();
                    break;
                case ActionToPerform.FileDeleted:
                    objBaseScannedFile = FilesDeleted.GetInstance();
                    break;
            }
            objBaseScannedFile.AddFile(fileInfo);
            objBaseScannedFile.DatabaseType = DatabaseType;
            objBaseScannedFile.SaveToCSVFile = SaveToCSVFile;
            objBaseScannedFile.SaveFile();
        }
        public ScannedFiles Get()
        {
            ScannedFiles objAllFiles = new ScannedFiles();

            FileSystemCleanup objBaseScannedFile = null;
            objBaseScannedFile = FilesFailedToDelete.GetInstance();
            objBaseScannedFile.DatabaseType = DatabaseType;
            ScannedFiles objFilesFailedToDelete = objBaseScannedFile.GetFiles();

            objBaseScannedFile = FilesForNextIteration.GetInstance();
            objBaseScannedFile.DatabaseType = DatabaseType;
            ScannedFiles objFilesForNextIteration = objBaseScannedFile.GetFiles();

            objBaseScannedFile = FilesDeleted.GetInstance();
            objBaseScannedFile.DatabaseType = DatabaseType;
            ScannedFiles objFilesToDelete = objBaseScannedFile.GetFiles();

            objAllFiles.AddRange(objFilesFailedToDelete);
            objAllFiles.AddRange(objFilesForNextIteration);
            objAllFiles.AddRange(objFilesToDelete);

            return objAllFiles;
        }
        public ScannedFiles Get(ActionToPerform action)
        {
            FileSystemCleanup objBaseScannedFile = null;
            ScannedFiles files = null;
            switch (action)
            {
                case ActionToPerform.FileFailedToDelete:
                    objBaseScannedFile = FilesFailedToDelete.GetInstance();
                    break;
                case ActionToPerform.FileForNextIteration:
                    objBaseScannedFile = FilesForNextIteration.GetInstance();
                    break;
                case ActionToPerform.FileDeleted:
                    objBaseScannedFile = FilesDeleted.GetInstance();
                    break;
            }
            objBaseScannedFile.DatabaseType = DatabaseType;
            objBaseScannedFile.SaveToCSVFile = SaveToCSVFile;
            files = objBaseScannedFile.GetFiles();
            return files;
        }
    }
}
