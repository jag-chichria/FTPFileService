using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.rssb.win.services.ffc.classes
{
    public class FilesFailedToDelete : FileSystemCleanup
    {
        private static FilesFailedToDelete _thisInstance;

        // Lock synchronization object
        private static object syncLock = new object();

        // Constructor is 'protected'
        protected FilesFailedToDelete()
        {

        }

        // Support multithreaded applications through
        // 'Double checked locking' pattern which (once
        // the instance exists) avoids locking each
        // time the method is invoked
        public static FilesFailedToDelete GetInstance()
        {

            if (_thisInstance == null)
            {
                lock (syncLock)
                {
                    if (_thisInstance == null)
                    {
                        _thisInstance = new FilesFailedToDelete();
                    }
                }
            }

            return _thisInstance;
        }

        public override ScannedFiles GetFiles()
        {
            FileYetToProcessDbManager dbManager = new FileYetToProcessDbManager();
            dbManager.DatabaseType = DatabaseType;
            return dbManager.Get(2);
        }

        /// <summary>
        /// <b>Description:</b>
        /// Accepts file system as parameter, this will save file information to database
        /// of only file which was failed to delete. Since, saving could be to different
        /// table other than next iteration or deleted files, this will help to build
        /// report for those files where were failed to delete.
        /// </summary>
        /// <param name="file"></param>  
        public override bool SaveFileList(ScannedFiles files)
        {
            foreach (ScannedFile file in files) { this.SaveFile(file); }
            return true;
        }

        /// <summary>
        /// <b>Description:</b>
        /// Accepts file system as parameter, this will save file information to database
        /// of only file which was failed to delete. Since, saving could be to different
        /// table other than next iteration or deleted files, this will help to build
        /// report for those files where were failed to delete.
        /// </summary>
        /// <param name="file"></param>  
        public override bool SaveFile(ScannedFile file)
        {
            FileYetToProcessDbManager dbManager = new FileYetToProcessDbManager();
            dbManager.DatabaseType = DatabaseType;
            dbManager.SaveToCSVFile = SaveToCSVFile;
            dbManager.Save(file, 2);
            return true;
        }
    }
}
