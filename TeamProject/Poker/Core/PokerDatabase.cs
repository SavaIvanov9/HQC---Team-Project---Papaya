﻿using System;
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
        private IList<ICharacter> botPlayers = new List<ICharacter>();
        private IList<ICharacter> humanPlayers = new List<ICharacter>();
        private IList<ICard> deck = new List<ICard>();
        private IList<ICard> tableCards = new List<ICard>();  
       
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

        public IList<ICard> TableCards
        {
            get { return this.tableCards; }
            set { this.tableCards = value; }
        }
        public void AddBot(ICharacter bot)
        {
            BotPlayers.Add(bot);
        }

        public void AddHuman(ICharacter human)
        {
            HumanPlayers.Add(human);
        }

        public void AddCard(ICard card)
        {
            Deck.Add(card);
        }
    }
}
