using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Interfaces
{
    public interface ICardDealable
    {
        void DealCards(IList<ICard> deck, IList<ICharacter> humans, IList<ICharacter> bots, IList<ICard> tableCards);
        void ReturnCards(IList<ICard> deck, IList<ICharacter> humans, IList<ICharacter> bots, IList<ICard> tableCards);

    }
}
