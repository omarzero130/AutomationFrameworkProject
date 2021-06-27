using System;
using System.Collections.Generic;
using System.Text;
using AutomationFrameworkProject.Models;

namespace AutomationFrameworkProject.Services
{
    //Interfaces are rules or contracts that must be followed by any class that implements them.
    //This is powerful, because it guarantees that multiple classes will have the same method name or signatures
    public interface ICardService
    {
        Card GetCardByName(string cardName);
        
    }
}
