﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Interfaces;
using Poker.Players;

namespace Poker.Core.Factories
{
    public class HumanFactory:IHumanFactory
    {
        public ICharacter CreateHuman(string name, IList<ICard> hand, int power, int chips)
        {
            var player = new Human(name, hand, power, chips);

            return player;
        }
    }
}
