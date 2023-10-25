using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLibrary
{
    public class LoadConfiguration
    {
        public List<ILogSink> Sinks = new List<ILogSink>();
        public LogLevel DefaultLogLevel { get; set; }
        LogConfiguration logconfig;
        public LoadConfiguration(LogConfiguration config)
        {
            logconfig = config;
            AddSink();
        }
        private void AddSink()
        {
            if (!String.IsNullOrEmpty(logconfig.logpath))
            {
                var fsink = new FileSink()
                {
                    logPath = logconfig.logpath
                };
                Sinks.Add(fsink);
            }
            if (!String.IsNullOrEmpty(logconfig.dbConnectionString))
            {
                var dsink = new DatabaseSink()
                {
                    connectionString = "",
                    tableName = ""
                };
                Sinks.Add(dsink);
            }
        }
    }
}
