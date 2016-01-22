using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Interfaces;
using Poker.Enums;
using Poker.Models;

namespace Poker.Core.Factories
{
    public class CardFactory:ICardFactory
    {
        public ICard CreateCard(int cardPower, CardType cardType)
        {
            var card = new Card(cardPower, cardType);

            return card;
        }
    }
}
