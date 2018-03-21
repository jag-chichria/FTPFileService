using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using com.rssb.win.services.ffc.enums;

namespace com.rssb.win.services.ffc.interfaces
{
    public interface IFile
    {
        /// <summary>
        /// This attribute holds value when file was yet to processed and it can be/is deleted.
        /// </summary>
        bool doUpdateRequireOnRescan { get; set; }
        int FileId { get; set; }
        string Filename { get; set; }
        long Filesize { get; set; }
        DateTime CreationTime { get; set; }
        DateTime LastWriteTime { get; set; }
        DateTime LastAccessTime { get; set; }
        ActionToPerform performedAction { get; set; }
        
    }
}
