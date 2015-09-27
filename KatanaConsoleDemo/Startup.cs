using Owin;

namespace KatanaConsoleDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWelcomePage("/welcome");
        }
    }
}