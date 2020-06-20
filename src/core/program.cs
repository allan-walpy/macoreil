using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Macoreil.Core
{
    public static class Program
    {
        public static void Main(string[] args) =>
            Program.CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddHostedService<Worker>();
                })
                .ConfigureLogging(loggingBuilder =>
                {
                    // TODO: check it works as `loggingBuilder.Clear();` in previous versions of dotnet;
                    loggingBuilder.Services.Clear();
                    loggingBuilder.AddConsole();
                });

    }
}
