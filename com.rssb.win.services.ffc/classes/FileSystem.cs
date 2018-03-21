using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;

using com.rssb.win.services.ffc.interfaces;
using com.rssb.win.services.ffc.enums;

namespace com.rssb.win.services.ffc.classes
{
    public class FileSystem : IFileSystem
    {

        FileSystemCleanupFactory processedFile = new FileSystemCleanupFactory();
        ScannedFiles _filesToProcess = new ScannedFiles();

        public FileSystem()
        {

        }

        ~FileSystem()
        {

        }

        public virtual void Dispose()
        {

        }

        public DatabaseTypeEnum DatabaseType { get; set; }
        public string SaveToCSVFile { get; set; }
        public bool PhysicalDelete { get; set; }

        /// <summary>
        /// <b>Description:</b>
        /// With pass in allowed age limit on specified date access property on specific
        /// location, scan through the files and prepare for files to delete, and add it to
        /// collection of scanned files.
        /// </summary>
        /// <param name="allowedAgeLimit">allowed age limit, in days, to check.</param>
        /// <param name="fileDateProperty">allowed age limit, in days, to check on
        /// specified file date property. date created, accessed, modified.</param>
        /// <param name="directoryLocation">directory location to access.</param>
        public ScannedFiles RunScan(int allowedAgeLimit, FileDateProperty fileProperty, string directoryLocation)
        {
            ScannedFiles cOfScannedFiles = ScanFiles(directoryLocation, fileProperty, allowedAgeLimit);
            ScannedFiles cOfProcessedFiles = ProcessScannedFiles(allowedAgeLimit, fileProperty, cOfScannedFiles);
            return cOfProcessedFiles;
        }

        /// <summary>
        /// <b>Description:</b>
        /// With already scanned files to check, iterate through and validate each file.
        /// </summary>
        /// <param name="allowedAgeLimit">allowed age limit, in days, to check.</param>
        /// <param name="filesToCheck"></param>
        public ScannedFiles RunScan(int allowedAgeLimit, FileDateProperty fileProperty, ScannedFiles filesToCheck)
        {
            ScannedFiles cOfProcessedFiles = this.ProcessScannedFiles(allowedAgeLimit, fileProperty, filesToCheck);
            return cOfProcessedFiles;
        }

        /// <summary>
        /// <b>Description:</b>
        /// This will iterate the file system on the given path.
        /// Prepare the list of files which has passed fileAgeToValidate limit and to be
        /// deleted.
        /// Prepare the list of files which yet to pass fileAgeToValidate limit and to be
        /// stored.
        /// Check File is not open.
        /// Delete the file.
        /// if file has passed fileAgeToValidate and still cannot be deleted, mark file as
        /// failed to delete and record to database.
        /// Return the list.
        /// </summary>
        /// <param name="directoryLocation"></param>
        /// <param name="enumFileProperty"></param>
        /// <param name="fileAgeToValidate"></param>
        public ScannedFiles ScanFiles(string directoryLocation, FileDateProperty enumFileProperty, int fileAgeToValidate)
        {

            //create an array of files using FileInfo object
            FileInfo[] directoryFiles;

            //Create a Directory object using DirectoryInfo 
            DirectoryInfo currentDirectory = new DirectoryInfo(directoryLocation);

            //get all files for the current directory
            directoryFiles = currentDirectory.GetFiles("*.*");

            //iterate through the directory and print the files
            foreach (FileInfo file in directoryFiles)
            {
                ScannedFile scannedFileInfo = new ScannedFile();
                //get details of each file using file object
                scannedFileInfo.Filename = file.FullName.Replace(file.DirectoryName+@"\", String.Empty);
                scannedFileInfo.Filesize = file.Length;
                scannedFileInfo.LastWriteTime = file.LastWriteTime;
                scannedFileInfo.LastAccessTime = file.LastAccessTime;
                scannedFileInfo.CreationTime = file.CreationTime;
                scannedFileInfo.Filepath = file.DirectoryName + @"\";
                _filesToProcess.Add(scannedFileInfo);
            }

            //get sub-folders for the current directory
            DirectoryInfo[] subDirectories = currentDirectory.GetDirectories("*.*");

            //This is the code that calls 
            //the getDirsFiles (calls itself recursively)
            //This is also the stopping point 
            //(End Condition) for this recursion function 
            //as it loops through until 
            //reaches the child folder and then stops.
            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                ScanFiles(subDirectory.FullName, enumFileProperty, fileAgeToValidate);
            }

            return _filesToProcess;
        }

        /// <summary>
        /// <b>Description:</b>
        /// This will iterate the file system on the given path.
        /// Prepare the list of files which has passed fileAgeToValidate limit and to be
        /// deleted.
        /// Prepare the list of files which yet to pass fileAgeToValidate limit and to be
        /// stored.
        /// Check File is not open.
        /// Delete the file.
        /// if file has passed fileAgeToValidate and still cannot be deleted, mark file as
        /// failed to delete and record to database.
        /// Return the list.
        /// </summary>
        /// <param name="filesToScan"></param>
        public ScannedFiles ScanFiles(ScannedFiles filesToScan)
        {

            return null;
        }

        /// <summary>
        /// <b>Description:</b>
        /// Delete file from file system
        /// </summary>
        /// <param name="File"></param>
        public bool DeleteFile(string fileName)
        {
            if (PhysicalDelete) { System.IO.File.Delete(fileName); }
            return true;
        }

        /// <summary>
        /// <b>Description:</b>
        /// Validate whether physical file exists on system. Return true, if it is else
        /// false
        /// This is an extra security to capture exception if accidently or an application
        /// has deleted file.
        /// </summary>
        /// <param name="file"></param>
        public bool IsFileExists(string fileName)
        {
            return System.IO.File.Exists(fileName);            
        }

        /// <summary>
        /// <b>Description:</b>
        /// Validate whether file has passed its age limit. Return true, if it is else
        /// false
        /// </summary>
        /// <param name="fileAgeLimit"></param>
        public bool IsFilePassedAgeLimit(DateTime fileAuditDate, int fileAgeLimit)
        {
            //determine the file age by substracting it from today
            int fileAge = DateTime.Today.Subtract(fileAuditDate).Days;
            return  fileAge > fileAgeLimit;
        }


        /// <summary>
        /// <b>Description:</b>
        /// Validate whether file has passed its age limit. Return true, if it is else
        /// false
        /// </summary>
        /// <param name="fileCreatedDate"></param>
        /// <param name="fileAuditDate"></param>
        /// <param name="fileAgeLimit"></param>
        /// <returns></returns>
        public bool IsFilePassedAgeLimit(DateTime fileCreatedDate, DateTime fileAuditDate, int fileAgeLimit)
        {
            //determine the file age by substracting it from today
            int fileAge = DateTime.Today.Subtract(fileAuditDate).Days;
            int fileCreatedAge = DateTime.Today.Subtract(fileCreatedDate).Days;
            return fileAge > fileAgeLimit && fileCreatedAge > fileAgeLimit;
        }

        /// <summary>
        /// <b>Description:</b>
        /// Validate whether file is open mode, or system file, any other required
        /// validation. Return true, if it is else false.
        /// </summary>
        /// <param name="fileAgeLimit"></param>
        public bool IsFileReadyForDelete(string filePath)
        {
            //FileSecurity fileSecurity = File.GetAccessControl(filePath, AccessControlSections.Access);
            //fileSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount))
            return true;
        }

        /// <summary>
        /// <b>Description:</b>
        /// This will iterate the file system on the given path.
        /// Prepare the list of files which has passed fileAgeToValidate limit and to be
        /// deleted.
        /// Prepare the list of files which yet to pass fileAgeToValidate limit and to be
        /// stored.
        /// Check File is not open.
        /// Delete the file.
        /// if file has passed fileAgeToValidate and still cannot be deleted, mark file as
        /// failed to delete and record to database.
        /// Return the list.
        /// </summary>
        /// <param name="fileAgeLimit"></param>
        /// <param name="cOfFiles"></param>
        public ScannedFiles ProcessScannedFiles(int fileAgeLimit, FileDateProperty enumFileProperty, ScannedFiles cOfFiles)
        {
            processedFile.DatabaseType = DatabaseType;
            processedFile.SaveToCSVFile = SaveToCSVFile;

            DateTime fileAuditDate = DateTime.Today;
            foreach (ScannedFile currentFile in cOfFiles)
            {
                string fullFilePath = currentFile.Filepath + currentFile.Filename;
                if (IsFileExists(fullFilePath))
                {
                    if (enumFileProperty == FileDateProperty.DateAdded)
                    { fileAuditDate = currentFile.LastAccessTime; }
                    else if (enumFileProperty == FileDateProperty.DateModified)
                    { fileAuditDate = currentFile.LastWriteTime; }                    

                    //compulsory check on file accessed and file created date.
                    //IsFilePassedAgeLimit(fileAuditDate, fileAgeLimit) is depreceted
                    if (IsFilePassedAgeLimit(currentFile.LastWriteTime, currentFile.LastAccessTime, fileAgeLimit))
                    {
                        if (IsFileReadyForDelete(fullFilePath))
                        {
                            if (DeleteFile(fullFilePath))
                            {
                                currentFile.performedAction = ActionToPerform.FileDeleted;
                                processedFile.AddFile(ActionToPerform.FileDeleted, currentFile);
                                
                            }
                            else
                            {
                                currentFile.performedAction = ActionToPerform.FileFailedToDelete;
                                processedFile.AddFile(ActionToPerform.FileFailedToDelete, currentFile);
                            }
                        }
                        else
                        {
                            currentFile.performedAction = ActionToPerform.FileFailedToDelete;
                            processedFile.AddFile(ActionToPerform.FileFailedToDelete, currentFile);
                        }

                    }
                    else
                    {
                        currentFile.performedAction = ActionToPerform.FileForNextIteration;
                        processedFile.AddFile(ActionToPerform.FileForNextIteration, currentFile);
                    }

                }
                else
                {
                    currentFile.performedAction = ActionToPerform.FileFailedToDelete;
                    processedFile.AddFile(ActionToPerform.FileFailedToDelete, currentFile);
                }
            }
            return processedFile.Get();
        }

    }//end IFileSystem

}//end namespace System