using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Models;

namespace Poker.Interfaces
{
    public interface IPokerDatabase
    {
        IList<Card> deck { get; set; }
        IList<ICharacter> humanPlayers { get; set; }
        IList<ICharacter> botPlayers { get; set; }
    }
}
