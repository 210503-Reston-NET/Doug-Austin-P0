using System;
using Serilog;

namespace StoreUI
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("../logs/myLog.txt")
            .CreateLogger();
            Console.WriteLine("Hello!");
            MenuFactory.GetMenu("m").Start();
        }
    }
}
