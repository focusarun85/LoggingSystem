using Logging.Core;
using Microsoft.Extensions.Configuration;

namespace Logging.Startup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            IConfiguration config = builder.Build();
           
            //Get Default log level
            string? strDefaultLogLevel = config.GetSection("DefaultLogLevel").Value;
            LogLevel defaultLogLevel;
            Enum.TryParse(strDefaultLogLevel, out defaultLogLevel);

            //Register logs
            LogHelper.AddLogTarget(LogTarget.File, defaultLogLevel);
            LogHelper.AddLogTarget(LogTarget.Console, defaultLogLevel);

            // Write to logs
            LogHelper.LogTrace("Hello world");
            LogHelper.LogInformation("Hello world");
            LogHelper.LogDebug("Hello world");
            LogHelper.LogError("Hello world");
            LogHelper.LogCritical("Hello world");

            Console.ReadLine();
        }
    }
}