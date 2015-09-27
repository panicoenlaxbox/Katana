using KatanaConsoleDemo;
using Microsoft.Owin;
using Microsoft.Owin.Diagnostics;
using Owin;

[assembly: OwinStartup(typeof(MyStartup), "Configuracion")]
namespace KatanaConsoleDemo
{
    public class MyStartup
    {
        public void Configuracion(IAppBuilder app)
        {
            //var options = new WelcomePageOptions() { Path = new PathString("/welcome") };
            //app.Use<WelcomePageMiddleware>(options);
            app.UseWelcomePage("/welcome");
        }
    }
}