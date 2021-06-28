using System;
using System.IO;

namespace AutomationFrameworkProject.Logging
{
    public class Logger
    {
        private readonly string _filepath;

        public Logger(string testname, string filepath)

        {
            _filepath = filepath;
            using (var log = File.CreateText(_filepath))
            {
                log.WriteLine($"Satrting TimeStamp: {DateTime.Now.ToLocalTime()}");
                log.WriteLine($"Test Name :{testname}");
            }
        }

        public void Info(String message)
        {
            WriteLine($"[INFO]: {message}");
        }

        public void Step(String message)
        {
            WriteLine($"    [STEP]: {message}");
        }

        public void Warning(String message)
        {
            WriteLine($"[WARNING]: {message}");
        }

        public void Error(String message)
        {
            WriteLine($"[ERROR]: {message}");
        }

        public void Fatal(String message)
        {
            WriteLine($"[FATAL]: {message}");
        }

        private void WriteLine(string text)
        {
            using (var log = File.AppendText(_filepath))
            {
                log.WriteLine(text);
            }
        }

        private void Write(string text)
        {
            using (var log = File.AppendText(_filepath))
            {
                log.Write(text);
            }
        }
    }
}