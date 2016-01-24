using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Interfaces;
using Poker.Models;
using Poker.Players;
using Poker.Table;

namespace Poker.Core.Factories
{
    public class BotFactory : IBotFactory
    {
        public ICharacter CreateBot(string name, int chips, IList<ICard> hand = null, int power = 0)
        {
            ICharacter bot = new Bot(name, chips, hand, power);
            
            return bot;
        }
    }
}
