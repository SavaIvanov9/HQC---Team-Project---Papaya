using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Interfaces;

namespace Poker.Core.Factories
{
    public class PlayerFactory:IPlayerFactory
    {
        public ICharacter CreateHuman(string name, IList<Models.Card> hand, int power)
        {
            //todo: implement
            throw new NotImplementedException();
        }
    }
}
