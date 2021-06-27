using System;
using System.Collections.Generic;
using System.Text;
using AutomationFrameworkProject.Selenium;


namespace AutomationFrameworkProject.Pages
{
    public  class Pagess
    {
        [ThreadStatic]
        public static CardsPage Cards;


        [ThreadStatic]
        public static CardsDetailsPage CardDetails;

        [ThreadStatic]
        public static DeckBuilderPage DeckBuilder;

        [ThreadStatic]
        public static CopyDeckPage CopyDeck;

        public static void Init()
        {
            Cards = new CardsPage();
            CardDetails = new CardsDetailsPage();
            DeckBuilder = new DeckBuilderPage();
            CopyDeck = new CopyDeckPage();
        }
    }
}
