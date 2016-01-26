using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Interfaces
{
    public interface IDeckFillable
    {
        void FillDeck(IPokerDatabase database, ICardFactory cardFactory);
    }
}
