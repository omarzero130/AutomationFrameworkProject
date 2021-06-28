using AutomationFrameworkProject.Logging;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.IO;

namespace AutomationFrameworkProject
{
    public class FW
    {
        public static string WORKSPACE_DIRECTORY = Path.GetFullPath(@"../../../../");

        //public static string WORKSPACE_JSONFILE = Path.GetFullPath(@"../../../");

        public static Logger Log => _logger ?? throw new NullReferenceException("Logger is null , Set logger() First");

        public static FwConfig Config => _Configuration ?? throw new NullReferenceException("Config is Null . call Fw.setconfig() first");

        [ThreadStatic]
        public static DirectoryInfo CurrentTestDirectory;

        [ThreadStatic]
        private static Logger _logger;

        private static FwConfig _Configuration;

        public static DirectoryInfo CreateTestResultDirectory()
        {
            var testDirectory = WORKSPACE_DIRECTORY + "TestResults";
            if (Directory.Exists(testDirectory))
            {
                Directory.Delete(testDirectory, recursive: true);
            }
            return Directory.CreateDirectory(testDirectory);
        }
        public static void SetConfig()
        {
            if (_Configuration == null)
            {
                var jasonStr = File.ReadAllText(WORKSPACE_DIRECTORY + "/framework-config.json");
                _Configuration = JsonConvert.DeserializeObject<FwConfig>(jasonStr);
            }


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