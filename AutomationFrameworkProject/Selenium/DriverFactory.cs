using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace AutomationFrameworkProject.Selenium
{
    public class DriverFactory
    {
        public static IWebDriver Build(string browserName)
        {
            FW.Log.Info($" Browser :{browserName}");
            switch(browserName)
            {
                case "chrome":
                    return new ChromeDriver(FW.WORKSPACE_DIRECTORY + "/_drivers");

                case "firefox":
                    return new FirefoxDriver();

                default:
                    throw new System.ArgumentException($"{browserName} not Supported");
            }
        }
    }
}
