using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace KatanaConsoleDemo
{
    public class PoweredByMiddleware : OwinMiddleware
    {
        private readonly string _by;

        public PoweredByMiddleware(OwinMiddleware next, string by) : base(next)
        {
            _by = by;
        }

        public override Task Invoke(IOwinContext context)
        {
            context.Response.Headers.Append("Powered-by", _by);
            return Next.Invoke(context);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start("http://localhost:8888",
                app =>
                {
                    app.Use(new Func<AppFunc, AppFunc>(next => (async env =>
                    {
                        Console.WriteLine("Begin Request");
                        await next.Invoke(env);
                        Console.WriteLine("End Request");
                    })));
                    app.Use<PoweredByMiddleware>("tabconsultores");
                    app.Use(async (context, next) =>
                    {
                        var watch = Stopwatch.StartNew();
                        await next(); // Execute next middleware
                        watch.Stop(); // Back in the pipeline
                        await context.Response.WriteAsync("-- Elapsed: " + watch.Elapsed);
                    });
                    app.UseWelcomePage("/welcome");
                    app.Use((IOwinContext context, Func<Task> nextModule) =>
                    {
                        var startsWithHello = context.Request.Path.Value.StartsWith("/hello");
                        var name = context.Request.Query.Get("name");
                        var existsName = !string.IsNullOrWhiteSpace(name);
                        if (startsWithHello && existsName)
                        {
                            var greeting = string.Format("Hello {0}", name);
                            // Final module, the next middleware will not be executed
                            return context.Response.WriteAsync(greeting);
                        }
                        return nextModule();
                    });

                }))
            {
                Console.WriteLine("Press a key to stop server");
                Console.ReadKey();
            }
        }
    }
}
