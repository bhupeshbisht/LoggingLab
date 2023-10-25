using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLibrary
{
    public class DatabaseSink : ILogSink
    {
        public string connectionString { get; set; }
        public string tableName { get; set; }
        public void LogMessage(LogMessage message)
        {
            // Implement logging to a file here
            if (message.Level == LogLevel.ERROR || message.Level == LogLevel.FATAL || message.Level == LogLevel.DEBUG)
            {
                bool flag = Helper.InsertLogData(connectionString, tableName, message.Content);
                Console.WriteLine($"DatabaseSink: [{message.Level}] {message.Namespace}: {message.Content}");
            }
        }
    }
}
