using Microsoft.Owin;
using Microsoft.Owin.Diagnostics;
using Owin;

namespace KatanaConsoleDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var options = new WelcomePageOptions() { Path = new PathString("/welcome") };
            app.Use<WelcomePageMiddleware>(options);
            app.UseWelcomePage("/welcome");
        }
    }
}