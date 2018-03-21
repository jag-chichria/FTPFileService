using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using com.rssb.win.services.ffc.enums;
using com.rssb.win.services.ffc.classes;

namespace com.rssb.win.services.ffc.interfaces
{
    interface IFileSystem
    {
        
        ScannedFiles RunScan(int allowedAgeLimit, FileDateProperty fileProperty, string directoryLocation);
        ScannedFiles RunScan(int allowedAgeLimit, FileDateProperty fileProperty, ScannedFiles filesToCheck);
        ScannedFiles ScanFiles(string directoryLocation, FileDateProperty enumFileProperty, int fileAgeToValidate);
        ScannedFiles ScanFiles(ScannedFiles filesToScan);
        bool DeleteFile(string fileName);
        bool IsFileExists(string fileName);
        bool IsFilePassedAgeLimit(DateTime fileAuditDate, int fileAgeLimit);
        bool IsFileReadyForDelete(string fileName);
        ScannedFiles ProcessScannedFiles(int fileAgeLimit, FileDateProperty enumFileProperty, ScannedFiles cOfFiles);

    }
}
