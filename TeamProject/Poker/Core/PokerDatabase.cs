using System;
using System.Collections.Generic;
using Poker.Interfaces;
using Poker.Models;
namespace Poker.Core
{
    public class PokerDatabase:IPokerDatabase
    {
        public IList<Card> deck
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

        public IList<ICharacter> humanPlayers
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

        public IList<ICharacter> botPlayers
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
    }
}
