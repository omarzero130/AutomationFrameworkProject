using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace AutomationFrameworkProject.Pages
{
    //Abstract Class because this class could be only inherited by other objects and can't be Instantiated by itself 
    public abstract class PageBase
    {
        public readonly HeaderNav HeaderNav;
        public PageBase()
        {
            HeaderNav = new HeaderNav();
        }
    }
}
