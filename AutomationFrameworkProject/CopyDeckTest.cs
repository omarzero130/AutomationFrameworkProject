using AutomationFrameworkProject.Pages;
using AutomationFrameworkProject.Selenium;
using NUnit.Framework;
using AutomationFrameworkProject.Base;

namespace AutomationFrameworkProject
{
    public class CopyDeckTest : TestBase
    {
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