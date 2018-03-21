using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using com.rssb.win.services.ffc.adapters.dsFFCTableAdapters;
using com.rssb.win.services.ffc.adapters;
using com.rssb.win.services.ffc.enums;
using System.IO;

namespace com.rssb.win.services.ffc.classes
{

	public abstract class DBManager
	{
		public DatabaseTypeEnum DatabaseType {get; set;}
		public string SaveToCSVFile{get; set;}

		public ScannedFiles Get()
		{
			if (DatabaseType == DatabaseTypeEnum.SQLDatabase)
			{
				return GetFromSQLDb();
			}
			else if (DatabaseType == DatabaseTypeEnum.CSVDatabase)
			{
				return GetFromCSV();            
			}
			return null;
		}
		public ScannedFiles Get(byte processType)
		{
			if (DatabaseType == DatabaseTypeEnum.SQLDatabase)
			{
				return GetFromSQLDb(processType);
			}
			else if (DatabaseType == DatabaseTypeEnum.CSVDatabase)
			{
				return GetFromCSV(processType);
			}
			return null;
		}
		public void Save(ScannedFile file)
		{
			if (DatabaseType == DatabaseTypeEnum.SQLDatabase)
			{
				SaveToSQLDb(file);
			}
			else if (DatabaseType == DatabaseTypeEnum.CSVDatabase)
			{
				SaveToCSV(file);
			}
		}
		public void Save(ScannedFile file, byte processType)
		{
			if (DatabaseType == DatabaseTypeEnum.SQLDatabase)
			{
				SaveToSQLDb(file,  processType);
			}
			else if (DatabaseType == DatabaseTypeEnum.CSVDatabase)
			{
				SaveToCSV(file,  processType);
			}
		}


		protected virtual void SaveToSQLDb(ScannedFile file){}
		protected virtual void SaveToSQLDb(ScannedFile file, byte processType){}
		protected void SaveToCSV(ScannedFile file, byte processType)
		{
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("Current Date", typeof(String)));
			dt.Columns.Add(new DataColumn("Current Time", typeof(String)));
			dt.Columns.Add(new DataColumn("File Deleted", typeof(String)));
			dt.Columns.Add(new DataColumn("Date Accessed", typeof(String)));
			dt.Columns.Add(new DataColumn("Date Modified", typeof(String)));
			dt.Columns.Add(new DataColumn("Date Created", typeof(String)));
			dt.Columns.Add(new DataColumn("File Size", typeof(String)));
			dt.Columns.Add(new DataColumn("Process Type", typeof(String)));

			DataRow scannedFile = dt.NewRow();
			scannedFile[0] = DateTime.Now.Date.ToString("MM/dd/yyyy");
			scannedFile[1] = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
			scannedFile[2] = file.Filepath + file.Filename;
			scannedFile[3] = file.LastAccessTime.ToString();
			scannedFile[4] = file.LastWriteTime.ToString();
			scannedFile[5] = file.CreationTime.ToString();
			scannedFile[6] = (file.Filesize / 1024).ToString();
			scannedFile[7] = processType.ToString();

			dt.Rows.Add(scannedFile);			
			dt.AcceptChanges();

			//WriteToCSV(dt);
		}
		protected void SaveToCSV(ScannedFile file)
		{
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("Current Date", typeof(String)));
			dt.Columns.Add(new DataColumn("Current Time", typeof(String)));
			dt.Columns.Add(new DataColumn("File Deleted", typeof(String)));
			dt.Columns.Add(new DataColumn("Date Accessed", typeof(String)));
			dt.Columns.Add(new DataColumn("Date Modified", typeof(String)));
			dt.Columns.Add(new DataColumn("Date Created", typeof(String)));
			dt.Columns.Add(new DataColumn("File Size", typeof(String)));

			DataRow scannedFile = dt.NewRow();
			scannedFile[0] = DateTime.Now.Date.ToString("MM/dd/yyyy");
			scannedFile[1] = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() ;
			scannedFile[2] = file.Filepath + file.Filename;
			scannedFile[3] = file.LastAccessTime.ToString();
			scannedFile[4] = file.LastWriteTime.ToString();
			scannedFile[5] = file.CreationTime.ToString();
			scannedFile[6] = (file.Filesize / 1024).ToString();

			dt.Rows.Add(scannedFile);
			dt.AcceptChanges();

			WriteToCSV(dt);
		}

		protected virtual ScannedFiles GetFromCSV() { return new ScannedFiles(); }
		protected virtual ScannedFiles GetFromSQLDb() { return new ScannedFiles(); }
		protected virtual ScannedFiles GetFromCSV(byte processType) { return new ScannedFiles(); }
		protected virtual ScannedFiles GetFromSQLDb(byte processType) { return new ScannedFiles(); }

		protected void WriteToCSV(DataTable dt)
		{
			ApplicationSettings settings = new ApplicationSettings();
			settings.Get();
			//check if file exists, if exists, we dont have write the headers.
			bool fileExistsOnSystem = System.IO.File.Exists(SaveToCSVFile);

			// Create the CSV file to which grid data will be exported.
			StreamWriter sw = new StreamWriter(SaveToCSVFile, true);
			// First we will write the headers.	
			int iColCount = dt.Columns.Count;
			if (!fileExistsOnSystem) { 
			for(int i = 0; i < iColCount; i++)
			{
				sw.Write(dt.Columns[i]);
				if (i < iColCount - 1)
				{
					sw.Write(settings.Delimeter); 
				}
			}            
			sw.Write(sw.NewLine);
			}
			// Now write all the rows.
			foreach (DataRow dr in dt.Rows)
			{
				for (int i = 0; i < iColCount; i++)
				{
					if (!Convert.IsDBNull(dr[i]))
					{
						sw.Write(dr[i].ToString());
					}
					if ( i < iColCount - 1)
					{
						sw.Write(settings.Delimeter);
					}
				}
				sw.Write(sw.NewLine);
			}
			sw.Close();
		}

	}
	public class FileDeletedDbManager : DBManager 
	{
		protected override void SaveToSQLDb(ScannedFile file)
		{
			FilesDeletedTableAdapter filesDeletedTableAdapter = new FilesDeletedTableAdapter();
			ApplicationSettings appSettings = new ApplicationSettings();
			filesDeletedTableAdapter.Connection.ConnectionString = appSettings.getDbConnectionString();
			filesDeletedTableAdapter.Insert(file.Filename, file.Filepath, DateTime.Now, String.Empty, "SYSTEM", file.LastAccessTime, file.LastWriteTime, file.Filesize);
			if (file.doUpdateRequireOnRescan)
			{
				FileYetToProcessDbManager yetToProcess = new FileYetToProcessDbManager();
				yetToProcess.Update(file, 0, "deleted on " + DateTime.Now.ToString());
			}
		}

		protected override ScannedFiles GetFromCSV()
		{
			return new ScannedFiles();
		}

		protected override ScannedFiles GetFromSQLDb()
		{
			FilesDeletedTableAdapter filesDeletedTableAdapter = new FilesDeletedTableAdapter();
			ScannedFile scannedfile = new ScannedFile();
			ScannedFiles scannedfiles = new ScannedFiles();

			ApplicationSettings appSettings = new ApplicationSettings();
			filesDeletedTableAdapter.Connection.ConnectionString = appSettings.getDbConnectionString();
			dsFFC.FilesDeletedDataTable filesDeleted = filesDeletedTableAdapter.GetData();
			foreach (dsFFC.FilesDeletedRow file in filesDeleted.Rows)
			{
				scannedfile = new ScannedFile();
				scannedfile.Filename = file.fileName;
				scannedfile.Filepath = file.filePath;
				scannedfile.performedAction = enums.ActionToPerform.FileDeleted;
				scannedfiles.Add(scannedfile);
			}

			return scannedfiles;
		}

	   }

	public class FileYetToProcessDbManager : DBManager
	{
		

		public int Update(ScannedFile file, byte processType, string comments){
			FilesYetToProcessTableAdapter filesYetToProcessTableAdapter = new FilesYetToProcessTableAdapter();
			ApplicationSettings appSettings = new ApplicationSettings();
			filesYetToProcessTableAdapter.Connection.ConnectionString = appSettings.getDbConnectionString();
			return filesYetToProcessTableAdapter.updateFileWhichWasYetToProcess(comments, processType, file.Filename, file.Filepath, file.FileId);
		}

		protected override void SaveToSQLDb(ScannedFile file, byte processType)
		{
			FilesYetToProcessTableAdapter filesYetToProcessTableAdapter = new FilesYetToProcessTableAdapter();
			ApplicationSettings appSettings = new ApplicationSettings();
			filesYetToProcessTableAdapter.Connection.ConnectionString = appSettings.getDbConnectionString();
			if (!file.doUpdateRequireOnRescan)
			{
				filesYetToProcessTableAdapter.Insert(file.Filename, file.Filepath, DateTime.Now, String.Empty, "SYSTEM", processType, file.LastAccessTime, file.LastWriteTime, file.Filesize);
			}
			else
			{
				//only when failed to delete. this could be file no longer exists in directory.
				if (processType == 2)
				{
					string comments = "No action taken, this could be file no longer exists in directory or inaccessible.";
					this.Update(file, 3, comments);
				}
			}
		}

		protected override ScannedFiles GetFromSQLDb(byte processType)
		{
			FilesYetToProcessTableAdapter filesYetToProcessTableAdapter = new FilesYetToProcessTableAdapter();
			ScannedFile scannedfile = new ScannedFile();
			ScannedFiles scannedfiles = new ScannedFiles();

			ApplicationSettings appSettings = new ApplicationSettings();
			filesYetToProcessTableAdapter.Connection.ConnectionString = appSettings.getDbConnectionString();
			dsFFC.FilesYetToProcessDataTable filesYetToProcess = filesYetToProcessTableAdapter.GetData(processType);
			foreach (dsFFC.FilesYetToProcessRow file in filesYetToProcess.Rows)
			{
				scannedfile = new ScannedFile();
				scannedfile.FileId = file.fileId;
				scannedfile.Filename = file.fileName;
				scannedfile.Filepath = file.filePath;
				scannedfile.LastWriteTime = file.lastWriteTime;
				scannedfile.LastAccessTime = file.lastAccessedDate;
				scannedfile.Filesize = file.fileSize;
				scannedfile.doUpdateRequireOnRescan = true;
				scannedfile.performedAction = processType == 1 ? enums.ActionToPerform.FileForNextIteration : enums.ActionToPerform.FileFailedToDelete;
				scannedfiles.Add(scannedfile);
			}

			return scannedfiles;
		}
	}
}
