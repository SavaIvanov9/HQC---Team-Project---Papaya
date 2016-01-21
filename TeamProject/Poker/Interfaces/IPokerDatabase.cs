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
        IList<Card> Deck { get; set; }
        IList<ICharacter> HumanPlayers { get; set; }
        IList<ICharacter> BotPlayers { get; set; }
    }
}
