using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.rssb.win.services.ffc.enums;

namespace com.rssb.win.services.ffc.classes
{
    /// <summary>
    /// Abstract class for Scanned File
    /// </summary>
    public abstract class FileSystemCleanup
    {
        public DatabaseTypeEnum DatabaseType { get; set; }
        public string SaveToCSVFile { get; set; }
        public String ConnectionString { set; get; }
        protected ScannedFiles _files = new ScannedFiles();
        protected ScannedFile _currentFile = null;

        public virtual void AddFile(ScannedFile file) { _files.Add(file); _currentFile = file; }

        public virtual ScannedFiles GetFiles() { return _files; }

        public virtual ScannedFile GetFile() { return _currentFile; }

        public abstract bool SaveFileList(ScannedFiles files);
        
        public abstract bool SaveFile(ScannedFile file);

        public virtual bool SaveFile() { return this.SaveFile(this._currentFile); }

    }//end IScannedFile
}
