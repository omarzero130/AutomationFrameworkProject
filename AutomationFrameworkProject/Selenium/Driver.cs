using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;

namespace AutomationFrameworkProject.Selenium
{
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        [ThreadStatic]
        public static Wait Wait;

        public static void Init()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments(
            "start-maximized",
            "enable-automation",
            "--no-sandbox");
            _driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"), options,TimeSpan.FromMinutes(2));
            Wait = new Wait(10);
        }
      

        public static IWebDriver Current => _driver ??throw new NullReferenceException("Driver is null");

        public static string Title => Current.Title;

        public static void GoTo(String url)
        {
            /*if(url!.StartsWith("https"))
            {
                url = $"http://{url}";l       
            }*/
            Current.Navigate().GoToUrl(url);
        }
        public static IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
        }
        public static IList<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }
    }
}