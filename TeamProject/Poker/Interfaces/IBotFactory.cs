using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Models;

namespace Poker.Interfaces
{
    public interface IBotFactory
    {
        ICharacter CreateBot(string name, IList<Card> hand, int power, int chips);
    }
}
