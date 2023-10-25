namespace LogLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new LogConfiguration();
            config.logpath = "D:\\AppLogs\\";
            config.dbConnectionString="dbconnn";
            Logger logger = Logger.GetInstance(config);

            //Log messages with different levels
            logger.Log(LogLevel.INFO, "This is an informational message.", "AppNamespace");
            logger.Log(LogLevel.ERROR, "This is an error message.", "AppNamespace");
            Form1 objf1=new Form1(logger);
            objf1.writelog();
            Console.WriteLine("Hello, World!");
            Console.ReadLine();
        }
    }
}