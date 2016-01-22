using System;
using System.Collections.Generic;
using Poker.Interfaces;
using Poker.Models;
using Poker.Players;

namespace Poker.Core
{
    public class PokerDatabase:IPokerDatabase
    {
        private readonly IBotFactory botFactory;
        private readonly ICharacter character;
        public IList<Card> Deck
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<ICharacter> HumanPlayers
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<ICharacter> BotPlayers
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void AddBot(string name, IList<Card> hand, int power, int chips)
        {
            BotPlayers.Add(botFactory.CreateBot(name, hand, power, chips));
        }
    }
}
