using AutomationFrameworkProject.Logging;
using NUnit.Framework;
using System;
using System.IO;

namespace AutomationFrameworkProject
{
    public class FW
    {
        public static string WORKSPACE_DIRECTORY = Path.GetFullPath(@"../../../../");

        public static Logger Log => _logger ?? throw new NullReferenceException("Logger is null , Set logger() First");

        [ThreadStatic]
        public static DirectoryInfo CurrentTestDirectory;

        [ThreadStatic]
        private static Logger _logger;

        public static DirectoryInfo CreateTestResultDirectory()
        {
            var testDirectory = WORKSPACE_DIRECTORY + "TestResults";
            if (Directory.Exists(testDirectory))
            {
                Directory.Delete(testDirectory, recursive: true);
            }
            return Directory.CreateDirectory(testDirectory);
        }

        public static void SetLogger()
        {
            lock (_setLoggerLock)
            {
                var testResultDir = WORKSPACE_DIRECTORY + "TestResults";
                var testName = TestContext.CurrentContext.Test.Name;
                var fullPath = $"{testResultDir}/{testName}";
                if (Directory.Exists(fullPath))
                {
                    CurrentTestDirectory = Directory.CreateDirectory(fullPath + TestContext.CurrentContext.Test.ID);
                }
                else
                {
                    CurrentTestDirectory = Directory.CreateDirectory(fullPath);
                }

                _logger = new Logger(testName, CurrentTestDirectory.FullName + "/log.txt");

            }
        }

        private static object _setLoggerLock = new object();
    }
}