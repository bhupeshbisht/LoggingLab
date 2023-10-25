using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Reflection;
using System.Xml;

namespace LogLibrary
{
    public class FileSink : ILogSink
    {
        public string logPath { get; set; }=String.Empty;
        public void LogMessage(LogMessage message)
        {
            // Implement logging to a file here
            // Create a file to write to.            
            string path = String.Empty;
            try
            {
                if (message.Level == LogLevel.INFO || message.Level == LogLevel.WARN)
                {
                    path = logPath; //"D:\\AppLogs\\";
                    string logFileName = "logs_" + DateTime.Now.ToString("dd") + "_" + DateTime.Now.ToString("MM") + "_" + DateTime.Now.ToString("yyyy") + ".txt";
                    string filePathName = path + logFileName;
                    if (File.Exists(filePathName))
                    {
                        System.IO.File.AppendAllText(filePathName, message.Content + Environment.NewLine);
                    }
                    else
                    {
                        if (!Directory.Exists(path))
                        {
                            DirectoryInfo di = Directory.CreateDirectory(path);
                            File.Create(path + logFileName).Close();
                            string jsonErrorLogger = System.IO.File.ReadAllText(filePathName);
                            System.IO.File.AppendAllText(filePathName, message.Content + Environment.NewLine);
                        }
                        else
                        {
                            File.Create(path + logFileName).Close();
                            string jsonErrorLogger = System.IO.File.ReadAllText(filePathName);
                            System.IO.File.AppendAllText(filePathName, message.Content + Environment.NewLine);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //create one file on temp location if any error on loglibrarry
            }
            finally
            {
            
            }
            Console.WriteLine($"FileSink: [{message.Level}] {message.Namespace}: {message.Content}");
        }
    }
}
