using Microsoft.Owin.Extensions;
using Owin;

namespace KatanaWebDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWelcomePage("/welcome");
            app.UseStageMarker(PipelineStage.AcquireState)
        }
    }
}