using Logging.Core;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Xml.XPath;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Logging.Test
{
    [TestClass]
    public class LogHelperTest
    {
        private void CreateLogs(string fileName)
        {
            LogHelper.LogTrace("Test Trace Message");
            LogHelper.LogDebug("Test Debug Message");
            LogHelper.LogInformation("Test Information Message");
            LogHelper.LogWarning("Test Warning Message");
            LogHelper.LogError("Test Error Message");
            LogHelper.LogCritical("Test Critical Message");
            Assert.IsTrue(File.Exists(fileName));            
        }

        [TestMethod]
        public void TestTraceLevelLog()
        {
            //Arrange
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Log.txt");
            if (File.Exists(fileName))
                File.Delete(fileName);

            //Act
            LogHelper.AddLogTarget(LogTarget.File, LogLevel.Trace);
            CreateLogs(fileName);
            var fileText = File.ReadAllText(fileName);

            //Assert
            Assert.AreNotEqual(fileText.IndexOf("[Trace]"), -1);
            Assert.AreNotEqual(fileText.IndexOf("[Debug]"), -1);
            Assert.AreNotEqual(fileText.IndexOf("[Information]"), -1);
            Assert.AreNotEqual(fileText.IndexOf("[Warning]"), -1);
            Assert.AreNotEqual(fileText.IndexOf("[Error]"), -1);
            Assert.AreNotEqual(fileText.IndexOf("[Critical]"), -1);

            Assert.AreNotEqual(fileText.IndexOf("Test Trace Message"), -1);
            Assert.AreNotEqual(fileText.IndexOf("Test Debug Message"), -1);
            Assert.AreNotEqual(fileText.IndexOf("Test Information Message"), -1);
            Assert.AreNotEqual(fileText.IndexOf("Test Warning Message"), -1);
            Assert.AreNotEqual(fileText.IndexOf("Test Error Message"), -1);
            Assert.AreNotEqual(fileText.IndexOf("Test Critical Message"), -1);
        }

        [TestMethod]
        public void TestDebugLevelLog()
        {
            //Arrange
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Log.txt");
            if (File.Exists(fileName))
                File.Delete(fileName);

            //Act
            LogHelper.AddLogTarget(LogTarget.File, LogLevel.Debug);
            CreateLogs(fileName);
            var fileText = File.ReadAllText(fileName);

            //Assert
            Assert.AreEqual(fileText.IndexOf("[Trace]"), -1);
            Assert.AreNotEqual(fileText.IndexOf("[Debug]"), -1);
            Assert.AreNotEqual(fileText.IndexOf("[Information]"), -1);
            Assert.AreNotEqual(fileText.IndexOf("[Warning]"), -1);
            Assert.AreNotEqual(fileText.IndexOf("[Error]"), -1);
            Assert.AreNotEqual(fileText.IndexOf("[Critical]"), -1);

            Assert.AreEqual(fileText.IndexOf("Test Trace Message"), -1);
            Assert.AreNotEqual(fileText.IndexOf("Test Debug Message"), -1);
            Assert.AreNotEqual(fileText.IndexOf("Test Information Message"), -1);
            Assert.AreNotEqual(fileText.IndexOf("Test Warning Message"), -1);
            Assert.AreNotEqual(fileText.IndexOf("Test Error Message"), -1);
            Assert.AreNotEqual(fileText.IndexOf("Test Critical Message"), -1);
        }

        [TestMethod]
        public void TestInformationLevelLog()
        {
            //Arrange
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Log.txt");
            if (File.Exists(fileName))
                File.Delete(fileName);

            //Act
            LogHelper.AddLogTarget(LogTarget.File, LogLevel.Information);
            CreateLogs(fileName);
            var fileText = File.ReadAllText(fileName);

            //Assert
            Assert.AreEqual(fileText.IndexOf("[Trace]"), -1);
            Assert.AreEqual(fileText.IndexOf("[Debug]"), -1);
            Assert.AreNotEqual(fileText.IndexOf("[Information]"), -1);
            Assert.AreNotEqual(fileText.IndexOf("[Warning]"), -1);
            Assert.AreNotEqual(fileText.IndexOf("[Error]"), -1);
            Assert.AreNotEqual(fileText.IndexOf("[Critical]"), -1);

            Assert.AreEqual(fileText.IndexOf("Test Trace Message"), -1);
            Assert.AreEqual(fileText.IndexOf("Test Debug Message"), -1);
            Assert.AreNotEqual(fileText.IndexOf("Test Information Message"), -1);
            Assert.AreNotEqual(fileText.IndexOf("Test Warning Message"), -1);
            Assert.AreNotEqual(fileText.IndexOf("Test Error Message"), -1);
            Assert.AreNotEqual(fileText.IndexOf("Test Critical Message"), -1);
        }

        [TestMethod]
        public void TestWarningLevelLog()
        {
            //Arrange
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Log.txt");
            if (File.Exists(fileName))
                File.Delete(fileName);

            //Act
            LogHelper.AddLogTarget(LogTarget.File, LogLevel.Warning);
            CreateLogs(fileName);
            var fileText = File.ReadAllText(fileName);

            //Assert
            Assert.AreEqual(fileText.IndexOf("[Trace]"), -1);
            Assert.AreEqual(fileText.IndexOf("[Debug]"), -1);
            Assert.AreEqual(fileText.IndexOf("[Information]"), -1);
            Assert.AreNotEqual(fileText.IndexOf("[Warning]"), -1);
            Assert.AreNotEqual(fileText.IndexOf("[Error]"), -1);
            Assert.AreNotEqual(fileText.IndexOf("[Critical]"), -1);

            Assert.AreEqual(fileText.IndexOf("Test Trace Message"), -1);
            Assert.AreEqual(fileText.IndexOf("Test Debug Message"), -1);
            Assert.AreEqual(fileText.IndexOf("Test Information Message"), -1);
            Assert.AreNotEqual(fileText.IndexOf("Test Warning Message"), -1);
            Assert.AreNotEqual(fileText.IndexOf("Test Error Message"), -1);
            Assert.AreNotEqual(fileText.IndexOf("Test Critical Message"), -1);
        }

        [TestMethod]
        public void TestErrorLevelLog()
        {
            //Arrange
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Log.txt");
            if (File.Exists(fileName))
                File.Delete(fileName);

            //Act
            LogHelper.AddLogTarget(LogTarget.File, LogLevel.Error);
            CreateLogs(fileName);
            var fileText = File.ReadAllText(fileName);

            //Assert
            Assert.AreEqual(fileText.IndexOf("[Trace]"), -1);
            Assert.AreEqual(fileText.IndexOf("[Debug]"), -1);
            Assert.AreEqual(fileText.IndexOf("[Information]"), -1);
            Assert.AreEqual(fileText.IndexOf("[Warning]"), -1);
            Assert.AreNotEqual(fileText.IndexOf("[Error]"), -1);
            Assert.AreNotEqual(fileText.IndexOf("[Critical]"), -1);

            Assert.AreEqual(fileText.IndexOf("Test Trace Message"), -1);
            Assert.AreEqual(fileText.IndexOf("Test Debug Message"), -1);
            Assert.AreEqual(fileText.IndexOf("Test Information Message"), -1);
            Assert.AreEqual(fileText.IndexOf("Test Warning Message"), -1);
            Assert.AreNotEqual(fileText.IndexOf("Test Error Message"), -1);
            Assert.AreNotEqual(fileText.IndexOf("Test Critical Message"), -1);
        }

        [TestMethod]
        public void TestCriticalLevelLog()
        {
            //Arrange
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Log.txt");
            if (File.Exists(fileName))
                File.Delete(fileName);

            //Act
            LogHelper.AddLogTarget(LogTarget.File, LogLevel.Critical);
            CreateLogs(fileName);
            var fileText = File.ReadAllText(fileName);

            //Assert
            Assert.AreEqual(fileText.IndexOf("[Trace]"), -1);
            Assert.AreEqual(fileText.IndexOf("[Debug]"), -1);
            Assert.AreEqual(fileText.IndexOf("[Information]"), -1);
            Assert.AreEqual(fileText.IndexOf("[Warning]"), -1);
            Assert.AreEqual(fileText.IndexOf("[Error]"), -1);
            Assert.AreNotEqual(fileText.IndexOf("[Critical]"), -1);

            Assert.AreEqual(fileText.IndexOf("Test Trace Message"), -1);
            Assert.AreEqual(fileText.IndexOf("Test Debug Message"), -1);
            Assert.AreEqual(fileText.IndexOf("Test Information Message"), -1);
            Assert.AreEqual(fileText.IndexOf("Test Warning Message"), -1);
            Assert.AreEqual(fileText.IndexOf("Test Error Message"), -1);
            Assert.AreNotEqual(fileText.IndexOf("Test Critical Message"), -1);
        }

        [TestMethod]
        public void TestNoneLevelLog()
        {
            //Arrange
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Log.txt");
            if (File.Exists(fileName))
                File.Delete(fileName);

            //Act
            LogHelper.AddLogTarget(LogTarget.File, LogLevel.None);
            LogHelper.LogTrace("Test Trace Message");
            LogHelper.LogDebug("Test Debug Message");
            LogHelper.LogInformation("Test Information Message");
            LogHelper.LogWarning("Test Warning Message");
            LogHelper.LogError("Test Error Message");
            LogHelper.LogCritical("Test Critical Message");

            //Assert
            Assert.IsFalse(File.Exists(fileName));                   
        }

    }
}