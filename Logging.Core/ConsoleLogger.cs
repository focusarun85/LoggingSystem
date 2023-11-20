namespace Logging.Core
{
    /// <summary>
    /// ConsoleLogger
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        public required LogLevel DefaultLogLevel { get; set; }
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
