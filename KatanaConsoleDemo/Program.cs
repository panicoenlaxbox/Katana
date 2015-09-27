using System;
using Microsoft.Owin.Hosting;

namespace KatanaConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:8888"))
            {
                Console.WriteLine("Press a key to stop server");
                Console.ReadKey();
            }
        }
    }
}
