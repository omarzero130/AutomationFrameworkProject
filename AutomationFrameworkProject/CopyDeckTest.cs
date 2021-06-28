using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using AutomationFrameworkProject.Pages;
using AutomationFrameworkProject.Selenium;


namespace AutomationFrameworkProject
{
    public class CopyDeckTest
    {
        [OneTimeSetUp]
        public void beforeAll()
        {
            FW.CreateTestResultDirectory();
        }
        [SetUp]
        public void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init();
            Pagess.Init();
            Driver.GoTo("https://statsroyale.com/");
        }

        [TearDown]
        public void AfterEach()
        {
            Driver.Current.Quit();

        }

        
        [Test]
        [Category("copydeck")]
        public void User_can_copy_the_deck()
        {

            Pagess.DeckBuilder.Goto().AddCardsManually();
            Pagess.DeckBuilder.CopySuggestedDeck();
            Pagess.CopyDeck.Yes();
            Assert.That(Pagess.CopyDeck.Map.CopiedMessage.Displayed);
        }
        [Test]
        
        public void User_opens_app_store()
        {
            Pagess.DeckBuilder.Goto().AddCardsManually();
            Pagess.DeckBuilder.CopySuggestedDeck();
            Pagess.CopyDeck.No().OpenAppStore();
            Assert.That(Driver.Title, Is.EqualTo("Clash Royale on the App Store"));
        }

        [Test]
        [Category("copydeck")]
        public void User_opens_google_play()
        {
            Pagess.DeckBuilder.Goto().AddCardsManually();
            Pagess.DeckBuilder.CopySuggestedDeck();
            Pagess.CopyDeck.No().OpenGooglePlay();
            Assert.AreEqual("Clash Royale - Apps on Google Play", Driver.Title);
        }


    }
}