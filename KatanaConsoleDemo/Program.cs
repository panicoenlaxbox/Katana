using System;
using Microsoft.Owin.Hosting;
using Owin;

namespace KatanaConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start("http://localhost:8888",
                app =>
                {
                    app.UseWelcomePage("/welcome");
                }))
            {
                Console.WriteLine("Press a key to stop server");
                Console.ReadKey();
            }
        }
    }
}
