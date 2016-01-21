using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Interfaces;
using Poker.Enums;

namespace Poker.Core.Factories
{
    public class CardFactory:ICardFactory
    {
        public ICard CreateCard(int cardPower, CardType cardType)
        {
            //Todo: Implement
            throw new NotImplementedException();
        }
    }
}
