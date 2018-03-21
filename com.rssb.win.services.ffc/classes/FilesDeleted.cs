using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.rssb.win.services.ffc.classes
{
    public class FilesDeleted : FileSystemCleanup
    {
        private static FilesDeleted _thisInstance;
        // Lock synchronization object
        private static object syncLock = new object();

        // Constructor is 'protected'
        protected FilesDeleted()
        {

        }

        // Support multithreaded applications through
        // 'Double checked locking' pattern which (once
        // the instance exists) avoids locking each
        // time the method is invoked
        public static FilesDeleted GetInstance()
        {

            if (_thisInstance == null)
            {
                lock (syncLock)
                {
                    if (_thisInstance == null)
                    {
                        _thisInstance = new FilesDeleted();
                    }
                }
            }

            return _thisInstance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ScannedFiles GetFiles()
        {
            FileDeletedDbManager dbManager = new FileDeletedDbManager();
            dbManager.DatabaseType = DatabaseType;
            return dbManager.Get();
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
            FileDeletedDbManager dbManager = new FileDeletedDbManager();
            dbManager.DatabaseType = DatabaseType;
            dbManager.SaveToCSVFile = SaveToCSVFile;
            dbManager.Save(file);
            return true;
        }
    }
}
