using AutomationFrameworkProject.Pages;
using AutomationFrameworkProject.Selenium;
using NUnit.Framework;
using AutomationFrameworkProject.Base;
using System.Text.RegularExpressions;

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
        [Category("copydeck")]
        public void User_opens_app_store()
        {
            Pagess.DeckBuilder.Goto().AddCardsManually();
            Pagess.DeckBuilder.CopySuggestedDeck();
            Pagess.CopyDeck.No().OpenAppStore();
            var title = Regex.Replace(Driver.Title, @"\u0200e", string.Empty);

            Assert.That(title, Is.EqualTo("‎Clash Royale on the App Store"));
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