using KatanaConsoleDemo;
using Microsoft.Owin;
using Microsoft.Owin.Diagnostics;
using Owin;

[assembly: OwinStartup(typeof(MyStartup))]
namespace KatanaConsoleDemo
{
    public class MyStartup
    {
        public void Configuration(IAppBuilder app)
        {
            //var options = new WelcomePageOptions() { Path = new PathString("/welcome") };
            //app.Use<WelcomePageMiddleware>(options);
            app.UseWelcomePage("/welcome");
        }
    }
}