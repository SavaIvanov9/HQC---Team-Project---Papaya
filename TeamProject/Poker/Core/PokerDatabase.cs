using System;
using System.Collections.Generic;
using Poker.Interfaces;
using Poker.Models;
namespace Poker.Core
{
    public class PokerDatabase:IPokerDatabase
    {
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
    }
}
