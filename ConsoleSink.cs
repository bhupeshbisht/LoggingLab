using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLibrary
{
    public class ConsoleSink : ILogSink
    {
        public void LogMessage(LogMessage message)
        {
            // Implement logging to the console here
            Console.WriteLine($"ConsoleSink: [{message.Level}] {message.Namespace}: {message.Content}");
        }
    }
}
