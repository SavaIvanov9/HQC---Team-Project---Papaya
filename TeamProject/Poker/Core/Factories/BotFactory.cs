using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Interfaces;

namespace Poker.Core.Factories
{
    public class BotFactory : IBotFactory
    {
        public ICharacter CreateBot(string name, IList<Models.Card> hand, int power)
        {
            //todo: implementS
            throw new NotImplementedException();
        }
    }
}
