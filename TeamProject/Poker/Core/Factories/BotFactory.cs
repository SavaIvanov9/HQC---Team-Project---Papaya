﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Interfaces;
using Poker.Models;
using Poker.Players;

namespace Poker.Core.Factories
{
    public class BotFactory : IBotFactory
    {
        public ICharacter CreateBot(string name, IList<Card> hand, int power, int chips)
        {
            var bot = new Bot(name, hand, power, chips);

            return bot;
        }
    }
}
