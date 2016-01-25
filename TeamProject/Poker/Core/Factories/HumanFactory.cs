using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Interfaces;
using Poker.Players;

namespace Poker.Core.Factories
{
    public class HumanFactory : IHumanFactory
    {
        public ICharacter CreateHuman(string name, int chips, int power = 0)
        {
            var player = new Human(name, chips, power);

            return player;
        }
    }
}
