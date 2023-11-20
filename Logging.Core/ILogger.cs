namespace Logging.Core
{
    /// <summary>
    ///  ILogger Interface
    /// </summary>
    public interface ILogger
    {
        void WriteLine(string line);
        LogLevel DefaultLogLevel { get; set; }
    }
}
