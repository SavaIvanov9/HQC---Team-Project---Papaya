using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Interfaces
{
    public interface IDeckShuffler
    {
        void Shuffle(IList<Object> deck);
    }
}
