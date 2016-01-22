using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Poker.Models;

namespace Poker.Interfaces
{
    public interface IPokerDatabase
    {
        IList<ICard> Deck { get; set; }
        IList<ICharacter> HumanPlayers { get; set; }
        //IList<ICharacter> BotPlayers { get; set; }
        void AddBot(string name, IList<ICard> hand, int power, int chips);
    }
}
