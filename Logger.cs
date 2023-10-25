using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLibrary
{
    // Logger class implementing the Singleton pattern
    public class Logger
    {
        private LogConfiguration logConfiguration;
        private static Logger instance;
        private List<ILogSink> sinks;
        private static readonly object lockObject = new object();
        private Logger(LogConfiguration configuration)
        {
            logConfiguration = configuration;
            LoadConfiguration load = new LoadConfiguration(logConfiguration);           
            sinks = load.Sinks;
        }

        public static Logger GetInstance(LogConfiguration logConfiguration)
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {                      
                        instance = new Logger(logConfiguration);
                    }
                }
            }
            return instance;
        }      

        public void Log(LogLevel level, string content, string logNamespace)
        {
            LogMessage message = new LogMessage
            {
                Level = level,
                Content = content,
                Namespace = logNamespace
            };
            foreach (var sink in sinks)
            {
                sink.LogMessage(message);
            }
        }
    }
}
