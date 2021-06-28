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
        private static RemoteWebDriver _driver;
        

        [ThreadStatic]
        public static Wait Wait;

        public static void Init()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments(
            "start-maximized",
            "enable-automation",
            "--no-sandbox");
            FW.Log.Info("Browser : Chrome");
            _driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"), options, TimeSpan.FromMinutes(4));
            Wait = new Wait(10);
        }

        public static RemoteWebDriver Current => _driver ?? throw new NullReferenceException("Driver is null");

        public static string Title => Current.Title;

        public static void GoTo(String url)
        {
            /*if(url!.StartsWith("https"))
            {
                url = $"http://{url}";l
            }*/
            FW.Log.Info(url);
            Current.Navigate().GoToUrl(url);
        }

        public static Element FindElement(By by, string elementName)
        {
            return new Element(Current.FindElement(by), elementName)
            {
                FoundBy = by
            };
        }

        public static Elements FindElements(By by)
        {
            return new Elements(Current.FindElements(by))
            {
                FoundBy = by
            };
        }

        public static void Quit()
        {
            FW.Log.Info("Close Browser");
            Current.Quit();
        }
    }
}