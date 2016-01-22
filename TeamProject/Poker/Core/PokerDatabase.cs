using System;
using System.Collections.Generic;
using Poker.Enums;
using Poker.Interfaces;
using Poker.Models;
using Poker.Players;

namespace Poker.Core
{
    public class PokerDatabase : IPokerDatabase
    {
        private IHumanFactory humanFactory;
        private IBotFactory botFactory;
        private ICardFactory cardFactory;

        public IList<ICharacter> botPlayers = new List<ICharacter>();

        public IList<ICard> Deck { get; set; }

        public IList<ICharacter> HumanPlayers { get; set; }

        public IList<ICharacter> BotPlayers { get; set; }

        public void AddBot(string name, IList<ICard> hand, int power, int chips)
        {
            BotPlayers.Add(botFactory.CreateBot(name, hand, power, chips));
        }

        public void AddHuman(string name, IList<ICard> hand, int power, int chips)
        {
            HumanPlayers.Add(humanFactory.CreateHuman(name, hand, power, chips));
        }

        public void AddCard(int cardPower, CardType cardType)
        {
            Deck.Add(cardFactory.CreateCard(cardPower, cardType));
        }
    }
}
