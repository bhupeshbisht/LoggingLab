using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLibrary
{
    // Sink interface to define destinations for log messages
    public interface ILogSink
    {
        void LogMessage(LogMessage message);
    }
    public class LogMessage
    {
        public string Content { get; set; }
        public LogLevel Level { get; set; }
        public string Namespace { get; set; }
    }
    // Message level enumeration
    public enum LogLevel
    {
        FATAL,
        ERROR,
        WARN,
        INFO,
        DEBUG
    }
}
