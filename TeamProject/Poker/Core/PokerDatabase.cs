using System;
using System.Collections.Generic;
using Poker.Interfaces;
using Poker.Models;
using Poker.Players;

namespace Poker.Core
{
    public class PokerDatabase : IPokerDatabase
    {
        private IBotFactory botFactory;
        private ICharacter character;
        public IList<ICharacter> botPlayers = new List<ICharacter>();
        public IList<ICharacter> humanPlayers = new List<ICharacter>();

        public IList<ICard> deck = new List<ICard>();
        
        public IList<ICard> Deck
        {
            get { return this.deck; }
            set { this.deck = value; }
        }

        public IList<ICharacter> HumanPlayers
        {
            get { return this.humanPlayers; }
            set { this.humanPlayers = value; }
        }

        public IList<ICharacter> BotPlayers
        {
            get { return this.botPlayers; }
            set { this.botPlayers = value; }
        }


        public void AddBot(ICharacter go6o)
        {
            BotPlayers.Add(go6o);
        }

        public void AddHuman(string name, IList<ICard> cards, int chips, int power)
        {
            HumanPlayers.Add(botFactory.CreateBot(name, cards, chips, power));
        }

        //public void AddBot(string name, IList<ICard> cards, int chips, int power)
        //{
        //    BotPlayers.Add(botFactory.CreateBot(name, cards, chips, power));
        //}

        //public void AddHuman(string name, IList<ICard> cards, int chips, int power)
        //{
        //    HumanPlayers.Add(botFactory.CreateBot(name, cards, chips, power));
        //}


    }
}
