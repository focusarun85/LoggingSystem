using Logging.Core;

namespace Logging.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestLogHelper()
        {
            ////// Arrange
            //string logFilePath = "Log.txt";

            //string expectedMessage = "Test log message";
            //LogLevel logLevel = LogLevel.Info;

            //ILoggger logger = new Logger(logFilePath, logLevel);

            ////// Act
            //logger.Logging(LogLevel.Debug.ToString(), expectedMessage);

            ////// Assert
            //string fileContent = File.ReadAllText(logFilePath);

            //Assert.That(fileContent, Contains.Substring(expectedMessage).IgnoreCase);

            //var logger = new Mock<Logging.Core.ILogger>();
            //FileLogger fileLogger = new FileLogger(logger.Object);

            LogHelper.LogDebug("Test Message"); // Do not write
            LogHelper.LogInformation("Test Message");

            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Log.txt");
            var fileText = File.ReadAllText(fileName);          

            Assert.Multiple(() =>
            {
                Assert.That(File.Exists(fileName), Is.True);
                Assert.That(fileText.IndexOf("[Debug]"), Is.Not.EqualTo(-1));
                Assert.That(fileText.IndexOf("[Info]"), Is.Not.EqualTo(-1));
            });
        }
    }
}