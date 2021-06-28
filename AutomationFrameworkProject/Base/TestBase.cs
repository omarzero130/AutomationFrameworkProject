using AutomationFrameworkProject.Pages;
using AutomationFrameworkProject.Selenium;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace AutomationFrameworkProject.Base
{
    // Its abstract because we don't want new instance from it
    //add virtual key word because it means it can be overriden
    public abstract class TestBase
    {
        [OneTimeSetUp]
        public virtual void BeforeAll()
        {
            FW.SetConfig();
            FW.CreateTestResultDirectory();
        }

        [SetUp]
        public virtual void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init();
            Pagess.Init();
            Driver.GoTo(FW.Config.Test.url);
        }

        [TearDown]
        public virtual void AfterEach()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;
            if (outcome == TestStatus.Passed)
            {
                FW.Log.Info("Outcome : PASSED");
            }
            else if (outcome == TestStatus.Failed)
            {
                FW.Log.Info("Outcome : FAILED !!");
            }
            else
            {
                Driver.TakeScreenShot("Test_failed");
                FW.Log.Warning("Outcome" + outcome);
            }
            Driver.Current.Quit();
        }
    }
}