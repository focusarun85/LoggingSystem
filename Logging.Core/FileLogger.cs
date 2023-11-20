namespace Logging.Core
{
    /// <summary>
    /// FileLogger
    /// </summary>
    public class FileLogger : ILogger
    {
        public required string Path { get; set; }
        public required LogLevel DefaultLogLevel { get; set; }
        public void WriteLine(string line)
        {
            using (var logWriter = new StreamWriter(Path, true))
            {
                logWriter.WriteLine(line);
            }
        }
    }
}
