using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Enums;

namespace Poker.Interfaces
{
   public interface ICardFactory
   {
       ICard CreateCard(decimal cardPower, CardType cardType);
   }
}
