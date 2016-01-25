using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Models;

namespace Poker.Interfaces
{
    public interface IHumanFactory
    {
        ICharacter CreateHuman(string name, int chips, IList<ICard> hand = null, int power = 0);
    }
}
