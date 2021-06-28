﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using AutomationFrameworkProject.Pages;
using AutomationFrameworkProject.Selenium;
using NUnit.Framework;

namespace AutomationFrameworkProject.Pages
{

    //when the method stays on the same page we don't need to return itself but when it takes us to another we need to return itself 
    //we need to change the type of the function to the class name
    //to get xpath from console typr $X(xpath)
    public class CopyDeckPage
    {
        public readonly CopyDeckPageMap Map;

        public CopyDeckPage()
        {
            Map = new CopyDeckPageMap();
        }

        public CopyDeckPage Yes()
        {
            Map.YesButton.Click();
            Driver.Wait.Until(drvr => Map.CopiedMessage.Displayed);
            return this;
        }

        public CopyDeckPage No()
        {
            Map.NoButton.Click();
            AcceptCookies();
            Driver.Wait.Until(drvr => Map.OtherStoresButton.Displayed);
            return this;
        }

        public void AcceptCookies()
        {
            Map.AcceptCookiesButton.Click();
            Driver.Wait.Until(drvr => !Map.AcceptCookiesButton.Displayed);
        }

        public void OpenAppStore()
        {
            Map.AppStoreButton.Click();
        }

        public void OpenGooglePlay()
        {
            Map.GooglePlayButton.Click();
        }


    }
    public class CopyDeckPageMap
    {
        public Element YesButton => Driver.FindElement(By.Id("button-open"), "Yes Button");

        public Element CopiedMessage => Driver.FindElement(By.CssSelector(".notes.active"), "Copied Message");

        public Element NoButton => Driver.FindElement(By.Id("not-installed"), "No Button");

        public Element AppStoreButton => Driver.FindElement(By.XPath("//a[text()='App Store']"), "App Store Button");

        public Element GooglePlayButton => Driver.FindElement(By.XPath("//a[text()='Google Play']"), "Google Play Button");

        public Element AcceptCookiesButton => Driver.FindElement(By.CssSelector("a.cc-btn.cc-dismiss"), "Accept Cookies Button");

        public Element OtherStoresButton => Driver.FindElement(By.Id("other-stores"), "Other Stores Button");
    }
}
