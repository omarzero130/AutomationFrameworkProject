using AutomationFrameworkProject.Models;
using AutomationFrameworkProject.Pages;
using AutomationFrameworkProject.Selenium;
using AutomationFrameworkProject.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace AutomationFrameworkProject
{
    public class CardTests
    {
        [SetUp]
        public void BeforeEach()
        {
            Driver.Init();
            Pagess.Init();
            Driver.GoTo("https://statsroyale.com/");
        }

        [TearDown]
        public void AfterEach()
        {
            Driver.Current.Quit();
        }

        static IList<Card> apiCards = new ApiCardService().GetAllCards();

        [Test]
        [Category("cards")]
        [TestCaseSource("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        public void Ice_spirit_is_on_cards_page(Card carrd)
        {
            var cardOnPage = Pagess.Cards.GoTo().GetCardByName(carrd.Name);
            Assert.That(cardOnPage.Displayed); 
          
        } 

        [Test]
        [Category("cards")]
        [TestCaseSource("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_headers_are_correct_on_Card_Details_page(Card cardd)
        {
            Pagess.Cards.GoTo().GetCardByName(cardd.Name).Click();

            var cardOnPage = Pagess.CardDetails.GetBaseCard();
            var card = new InMemoryCardService().GetCardByName(cardd.Name);
            Assert.AreEqual(card.Name, cardOnPage.Name);
            Assert.AreEqual(card.Type, cardOnPage.Type);
            Assert.AreEqual(card.Arena, cardOnPage.Arena);
            Assert.AreEqual(card.Rarity, cardOnPage.Rarity);
        }
    }
}