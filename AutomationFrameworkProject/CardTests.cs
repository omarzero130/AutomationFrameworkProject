using AutomationFrameworkProject.Models;
using AutomationFrameworkProject.Pages;
using AutomationFrameworkProject.Selenium;
using AutomationFrameworkProject.Services;
using NUnit.Framework;
using System.Collections.Generic;
using AutomationFrameworkProject.Base;

namespace AutomationFrameworkProject
{
    public class CardTests : TestBase
    {
       
        static IList<Card> apiCards = new ApiCardService().GetAllCards();

        [Test]
        [Category("cards")]
        [TestCaseSource("apiCards")]
        /*[Parallelizable(ParallelScope.Children)]*/
        public void Ice_spirit_is_on_cards_page(Card card)
        {
            var cardOnPage = Pagess.Cards.GoTo().GetCardByName(card.Name);
            Assert.That(cardOnPage.Displayed); 
          
        } 

        [Test]
        [Category("cards")]
        [TestCaseSource("apiCards")]
        /*[Parallelizable(ParallelScope.Children)]*/
        public void Card_headers_are_correct_on_Card_Details_page(Card card)
        {
            Pagess.Cards.GoTo().GetCardByName(card.Name).Click();

            var cardOnPage = Pagess.CardDetails.GetBaseCard();

            if (cardOnPage.Type == "troop")
                cardOnPage.Type = "character";

            Assert.AreEqual(card.Name, cardOnPage.Name);
            Assert.AreEqual(card.Arena, cardOnPage.Arena);
            Assert.AreEqual(card.Rarity, cardOnPage.Rarity);
            Assert.That(card.Type.Contains(cardOnPage.Type));
        }
    }
}