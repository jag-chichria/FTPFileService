using System;
using System.Collections.Generic;
using System.Text;
using AMS.Profile;
using com.rssb.win.services.ffc.enums;

namespace com.rssb.win.services.ffc.classes
{
    


    class XMLMethods
    {
        public string DocumentPath { set; get; }
        public string Nodename { set; get; }
        public string NodeValue { set; get; }
        public string StartElement { set; get; }

    }

    /// <summary>
    /// Abstract class of settings.
    /// </summary>
    public class ApplicationSettings
    {
        public ApplicationSettings()
        {
            // Set default values
            ServerName = "Enter Server/IP address";
            Database = "Enter database name";
            User = "Enter UID to connect";
            Password = "Enter UID's password";


            DatabaseType = DatabaseTypeEnum.CSVDatabase;
            FileDeleteCSVFile  = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryToScan = AppDomain.CurrentDomain.BaseDirectory;
            FileAgeLimit = 35;
            ServiceExecuteEvery = "24H";
            Delimeter = "|";         
            
            //initialise values if settings.xml do not exist, default values will still persist else overridden.
            Get();
        }

        /// <summary>
        /// database connectivity configurations
        /// </summary>
        public string ServerName { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// File Delete CSV File saving
        /// </summary>
        public string FileDeleteCSVFile { get; set; }

        /// <summary>
        /// Delimeter
        /// </summary>
        public string Delimeter { get; set; }

        /// <summary>
        /// Database Type
        /// </summary>
        public DatabaseTypeEnum DatabaseType { get; set; }


        /// <summary>
        /// application configurations
        /// </summary>        
        public string DirectoryToScan { get; set; }
        public int FileAgeLimit { get; set; }
        public string ServiceExecuteEvery { get; set; }

        public void Save()
        {
            Xml settings = new Xml(AppDomain.CurrentDomain.BaseDirectory+"settings.xml");            
            settings.RootName = "FTPFileSystemCleanup";

            settings.RemoveSection("Server"); settings.SetValue("Server", ServerName, String.Empty);
            settings.RemoveSection("Database"); settings.SetValue("Database", Database, String.Empty);
            settings.RemoveSection("User"); settings.SetValue("User", User, String.Empty);
            settings.RemoveSection("Password"); settings.SetValue("Password", Password, String.Empty);
            settings.RemoveSection("DirectoryToScan"); settings.SetValue("DirectoryToScan", DirectoryToScan, String.Empty);
            settings.RemoveSection("FileAgeLimit"); settings.SetValue("FileAgeLimit", FileAgeLimit.ToString(), String.Empty);
            settings.RemoveSection("ServiceExecuteEvery"); settings.SetValue("ServiceExecuteEvery", ServiceExecuteEvery.ToString(), String.Empty);
            settings.RemoveSection("FileDeleteCSVFile"); settings.SetValue("FileDeleteCSVFile", FileDeleteCSVFile.ToString(), String.Empty);
            settings.RemoveSection("DatabaseType"); settings.SetValue("DatabaseType", DatabaseType.GetHashCode().ToString(), String.Empty);
            settings.RemoveSection("Delimeter"); settings.SetValue("Delimeter", Delimeter.ToString(), String.Empty);
            
        }   

        public void Get() 
        {

            if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "settings.xml")) { return; }
            Xml settings = new Xml(AppDomain.CurrentDomain.BaseDirectory+"settings.xml");                        
            settings.RootName = "FTPFileSystemCleanup";

            ServerName = settings.GetEntryNames("Server")[0];
            Database = settings.GetEntryNames("Database")[0];
            User = settings.GetEntryNames("User")[0];
            Password = settings.GetEntryNames("Password")[0];
            DirectoryToScan = settings.GetEntryNames("DirectoryToScan")[0];
            FileAgeLimit = Convert.ToInt32(settings.GetEntryNames("FileAgeLimit")[0]);
            ServiceExecuteEvery = settings.GetEntryNames("ServiceExecuteEvery")[0];

            
            if (settings.HasSection("FileDeleteCSVFile")) { 
                FileDeleteCSVFile = settings.GetEntryNames("FileDeleteCSVFile")[0];
            }
                      
            
            if (settings.HasSection("DatabaseType"))
            {
                DatabaseType = (DatabaseTypeEnum)Convert.ToInt32(settings.GetEntryNames("DatabaseType")[0]);
            }

            if (settings.HasSection("Delimeter"))
            {
                Delimeter = settings.GetEntryNames("Delimeter")[0];
            }
        }

        public string getDbConnectionString()
        { return String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", ServerName, Database, User, Password); }
    }


}
