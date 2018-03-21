using System;
using System.IO;
using System.ServiceProcess;
using System.Timers;
using com.rssb.win.services.ffc.classes;
using com.rssb.win.services.ffc.enums;
using com.rssb.win.services.ffc.helper;

namespace FFCService
{
    public partial class FFCService : ServiceBase
    {

        //Initialize the _serviceExecuteEvery
        Timer _serviceExecuteEvery;
        Timer _settingsWatcher;
        string _FileName = AppDomain.CurrentDomain.BaseDirectory + "eventLog.txt";
        String defaultServiceExecuteEvery = "1M";        
        public FFCService()
        {
            InitializeComponent();

            //String sSource = "FFC Batch Process";
            //String sLog = "FFC Batch Process log";

            //if (!System.Diagnostics.EventLog.SourceExists(sSource))
            //    System.Diagnostics.EventLog.CreateEventSource(sSource, sLog);

            //logFFCBatch.Source = sSource;
            //// the event log source by which 
            ////the application is registered on the computer
            //logFFCBatch.Log = sLog;
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                _serviceExecuteEvery = new Timer();
                _serviceExecuteEvery.Elapsed += new ElapsedEventHandler(OnElapsedTime);
                _serviceExecuteEvery.Interval = 60000; // that makes a day when converted from ms. 
                _serviceExecuteEvery.Enabled = true;


                _settingsWatcher = new Timer();
                _settingsWatcher.Elapsed += new ElapsedEventHandler(OnElapsedTimeSettingWatcher);
                _settingsWatcher.Interval = 60000; // that makes a day when converted from ms. 
                _settingsWatcher.Enabled = true;

            }
            catch (Exception ex)
            {
                StopProcesses();
                //logFFCBatch.WriteEntry(DateTime.Now.ToString() + ": Error Occured: " + ex.Message + "-OnStart()");
                File.AppendAllText(_FileName, "\r\n" + DateTime.Now.ToString() + ": Error Occured: " + ex.Message + "-OnStart()");
            }
            finally
            {
                //logFFCBatch.WriteEntry(DateTime.Now.ToString() + ": Started job. -OnStart()");
                File.AppendAllText(_FileName, "\r\n" + DateTime.Now.ToString() + ": Started job. -OnStart()");
            }
        }

        private double getServiceInterval()
        {
            ApplicationSettings settings = new ApplicationSettings();
            String serviceExecution = settings.ServiceExecuteEvery;
            double result = 0;
            double elapsedTime = _serviceExecuteEvery.Interval;
            

                if (serviceExecution.ToLower().EndsWith("h"))
                {
                    if (double.TryParse(serviceExecution.Substring(0, serviceExecution.ToLower().IndexOf("h")), out result))
                    {
                        elapsedTime = double.Parse(serviceExecution.Substring(0, serviceExecution.ToLower().IndexOf("h")));                         
                        elapsedTime *= 60 * 60 * 1000; 
                    }

                }
                else if (serviceExecution.ToLower().EndsWith("m"))
                {
                    if (double.TryParse(serviceExecution.Substring(0, serviceExecution.ToLower().IndexOf("m")), out result))
                    {
                        elapsedTime = double.Parse(serviceExecution.Substring(0, serviceExecution.ToLower().IndexOf("m")));
                        elapsedTime *= 60 * 1000; 
                    }
                }
                else if (serviceExecution.ToLower().EndsWith("s"))
                {
                    if (double.TryParse(serviceExecution.Substring(0, serviceExecution.ToLower().IndexOf("s")), out result))
                    {
                        elapsedTime = double.Parse(serviceExecution.Substring(0, serviceExecution.ToLower().IndexOf("s")));
                        elapsedTime *= 1000;
                    }
                }
            return elapsedTime;
        }
        private void OnElapsedTimeSettingWatcher(object source, ElapsedEventArgs e)
        {

            try
            {
                _serviceExecuteEvery.Interval = getServiceInterval();
            }
            catch (Exception ex)
            {
                //logFFCBatch.WriteEntry( DateTime.Now.ToString() + ": Error Occured: " + ex.Message + "-OnElapsedTimeSettingWatcher()");
                File.AppendAllText(_FileName, "\r\n" + DateTime.Now.ToString() + ": Error Occured: " + ex.Message + "-OnElapsedTimeSettingWatcher()");
            }
            finally
            {
                //logFFCBatch.WriteEntry( DateTime.Now.ToString() + ": Error Occured: " + ex.Message + "-OnElapsedTimeSettingWatcher()");
                File.AppendAllText(_FileName, "\r\n" + DateTime.Now.ToString() + ": Interval - " + _serviceExecuteEvery.Interval + "-OnElapsedTimeSettingWatcher()");
            }
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            DateTime startTime = DateTime.Now;
            try
            {
                startTime = DateTime.Now;
                ExecuteProcess.scanPreviousData();
                ExecuteProcess.scanCurrentFileSystem();
                
            }
            catch (Exception ex)
            {
                StopProcesses();
                //logFFCBatch.WriteEntry( DateTime.Now.ToString() + ": Error Occured: " + ex.Message + "-OnElapsedTime()");
                File.AppendAllText(_FileName, "\r\n" + DateTime.Now.ToString() + ": Error Occured: " + ex.Message + "-OnElapsedTime()");
            }
            finally
            {
                //logFFCBatch.WriteEntry( DateTime.Now.ToString() + ": Finished job @ " + System.DateTime.Now.ToString() + " and took " + DateTime.Now.Subtract(startTime).Minutes + " min. -OnElapsedTime()");
                File.AppendAllText(_FileName, "\r\n" + DateTime.Now.ToString() + ": Finished job @ " + System.DateTime.Now.ToString() + " and took " + DateTime.Now.Subtract(startTime).Seconds + " sec(s). -OnElapsedTime()");
            }

        }
        private void StopProcesses()
        {
            if (_serviceExecuteEvery != null)
            {
                _serviceExecuteEvery.Enabled = false;
                _serviceExecuteEvery.Dispose();
            }

            //logFFCBatch.WriteEntry( DateTime.Now.ToString() + ": Service stopped. -StopProcesses()");
            File.AppendAllText(_FileName, "\r\n" + DateTime.Now.ToString() + ": Service stopped. -StopProcesses()");
        }
       
        protected override void OnStop()
        {
            StopProcesses();
        }



        
    }
}
