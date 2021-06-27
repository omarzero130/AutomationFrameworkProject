﻿using AutomationFrameworkProject.Selenium;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace AutomationFrameworkProject.Pages
{
    public class CardsPage : PageBase
    {
        public readonly CardsPageMap Map;

        public CardsPage()
        {
            Map = new CardsPageMap();
            
        }

        public CardsPage GoTo()
        {
            HeaderNav.GoToCardsPage();
            
            return this;
        }

        public IWebElement GetCardByName(String CardName)
        {
            if (CardName.Contains(""))
            {
                CardName = CardName.Replace(" ", "+");
            }
            
            return Map.Card(CardName);
        }
    }

    public class CardsPageMap
    {
        public IWebElement Card(String name) => Driver.FindElement(By.CssSelector($"a[href*='{name}']"));
        
    }
}