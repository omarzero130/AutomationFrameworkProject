using OpenQA.Selenium;
using System;
using System.IO;

namespace AutomationFrameworkProject.Selenium
{
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        [ThreadStatic]
        public static Wait Wait;

        [ThreadStatic]
        public static Window Window;

        public static void Init()
        {
            /*  ChromeOptions options = new ChromeOptions();
              options.AddArguments(
              "start-maximized",
              "enable-automation",
              "--no-sandbox");*/
            _driver = DriverFactory.Build(FW.Config.Driver.Browser);
            Wait = new Wait(10);
            //Window = new Window();
            //Window.Maximize();
            _driver.Manage().Window.Maximize();
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("Driver is null");

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

        public static void TakeScreenShot(string imageName)
        {
            var ss = ((ITakesScreenshot)Current).GetScreenshot();
            var ssFileName = Path.Combine(FW.CurrentTestDirectory.FullName, imageName);
            ss.SaveAsFile($"{ssFileName}.png", ScreenshotImageFormat.Png);
        }

        public static void Quit()
        {
            FW.Log.Info("Close Browser");
            Current.Quit();
            Current.Dispose();
        }

        public static Element FindElement(By by, string elementName)
        {
            var element = Wait.Until(drvr => drvr.FindElement(by));
            return new Element(element, elementName)
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
    }
}