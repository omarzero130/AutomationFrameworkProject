using AutomationFrameworkProject.Models;
using AutomationFrameworkProject.Selenium;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace AutomationFrameworkProject.Pages
{
    public class CardsDetailsPage : PageBase
    {
        public readonly CardDetailsPageMap Map;

        public CardsDetailsPage()
        {
            Map = new CardDetailsPageMap();
        }

        public (String Category, String Arena) GetCardCategory()
        {
            var categories = Map.CardCategory.Text.Split(',');
            return (categories[0].Trim(), categories[1].Trim());
        }

        public Card GetBaseCard()
        {
            var (category, arena) = GetCardCategory();

            return new Card
            {
                Name = Map.CardName.Text,
                Rarity = Map.CardRarity.Text.Split('\n').Last(),
                Type = category,
                Arena = arena,
            };
        }
    }

    public class CardDetailsPageMap
    {

        public Element CardName => Driver.FindElement(By.CssSelector("div[class*='cardName']"), "Card Name");

        public Element CardCategory => Driver.FindElement(By.CssSelector("div[class*='card__rarity']"), "Card Category");

        public Element CardRarity => Driver.FindElement(By.CssSelector("div[class*='rarityCaption']"), "Card Rarity");
    }
}