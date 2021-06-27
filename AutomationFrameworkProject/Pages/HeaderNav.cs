using System;
using System.Collections.Generic;
using System.Text;
using AutomationFrameworkProject.Selenium;
using OpenQA.Selenium;

namespace AutomationFrameworkProject.Pages
{
    public class HeaderNav
    {
        public readonly HeaderNavMap Map;
        public HeaderNav()
        {
            Map = new HeaderNavMap();
        }

        public void GoToCardsPage()
        {
            
            Map.CardsTabLink.Click();

        }

    }

    public class HeaderNavMap
    {
      
        public IWebElement CardsTabLink => Driver.FindElement(By.CssSelector("a[href='/cards']"));
        public IWebElement DeckBuilderLink => Driver.FindElement(By.CssSelector("a[href='/deckbuilder']"));

    }
}
