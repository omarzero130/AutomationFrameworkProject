using System;
using System.Collections.Generic;
using System.Text;
using AutomationFrameworkProject.Models;

namespace AutomationFrameworkProject.Services
{
    public class InMemoryCardService : ICardService
    {
        public Card GetCardByName(string cardName)
        {
            switch (cardName)
            {
                case "Ice Spirit":
                    return new IceSpiritCard();
                case "Mirror":
                    return new MirrorCard();
                default:
                    throw new System.ArgumentException("The Card is not Avilable : "+cardName);
            }
            
        }
    }
}
