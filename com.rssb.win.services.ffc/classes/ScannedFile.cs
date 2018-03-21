using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using com.rssb.win.services.ffc.interfaces;
using com.rssb.win.services.ffc.enums;
namespace com.rssb.win.services.ffc.classes
{
    /// <summary>
    /// Implementation class for interface IFile
    /// </summary>
    public class ScannedFile : IFile
    {   
        public bool doUpdateRequireOnRescan { get; set; }
        public int FileId { get; set; }
        public string Filepath { get; set; }
        public string Filename { get; set; }
        public long Filesize { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastWriteTime { get; set; }
        public DateTime LastAccessTime { get; set; }
        public ActionToPerform performedAction { get; set; }
       
    }
}
