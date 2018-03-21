using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using com.rssb.win.services.ffc.helper;
using System.IO;

namespace com.rssb.win.services.ffc
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            if (args.Length > 0)
            {
                DateTime startTime = DateTime.Now;
                string[] commandSwtiches = args;                
                bool deleteFiles = commandSwtiches.Contains("/delete");
                bool executeScan = commandSwtiches.Contains ("/e");
                try
                {
                    startTime = DateTime.Now;
                    //ExecuteProcess.scanPreviousData();        // deprecated. we dont have to scan as we are not maintaining any further information for failed to delete files.
                    if (executeScan) { ExecuteProcess.scanCurrentFileSystem(deleteFiles); }

                }
                catch (Exception ex)
                {
                    //logFFCBatch.WriteEntry( DateTime.Now.ToString() + ": Error Occured: " + ex.Message + "-OnElapsedTime()");
                    File.AppendAllText(ExecuteProcess._FileName, "\r\n" + DateTime.Now.ToString() + ": Error Occured: " + ex.Message + "-OnElapsedTime()");
                }
                finally
                {
                    //logFFCBatch.WriteEntry( DateTime.Now.ToString() + ": Finished job @ " + System.DateTime.Now.ToString() + " and took " + DateTime.Now.Subtract(startTime).Minutes + " min. -OnElapsedTime()");
                    File.AppendAllText(ExecuteProcess._FileName, "\r\n" + DateTime.Now.ToString() + ": Finished job @ " + System.DateTime.Now.ToString() + " and took " + DateTime.Now.Subtract(startTime).Seconds + " sec(s). -OnElapsedTime()");
                }
                Application.Exit(); Application.ExitThread(); return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
