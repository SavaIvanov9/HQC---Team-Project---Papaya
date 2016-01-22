using System;
using System.Collections.Generic;
using Poker.Interfaces;
using Poker.Models;
using Poker.Players;

namespace Poker.Core
{
    public class PokerDatabase:IPokerDatabase
    {
        private IBotFactory botFactory;
        private ICharacter character;
        public IList<ICharacter> botPlayers = new List<ICharacter>();

        public IList<ICard> Deck
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


        public void AddBot(string name, IList<ICard> cards, int chips, int power)
        {
            botPlayers.Add(botFactory.CreateBot(name, cards, chips, power));
        }
    }
}
