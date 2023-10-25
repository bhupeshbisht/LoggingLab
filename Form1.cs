using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLibrary
{
    public class Form1
    {
        Logger logger;
        public Form1(Logger log)
        {
            logger=log;
        }
        public void writelog()
        {
            logger.Log(LogLevel.INFO, "form 1 msg", "form1namespace");
        }
    }
}
