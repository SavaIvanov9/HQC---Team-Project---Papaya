using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Enums;
using Poker.Interfaces;

namespace Poker.Models
{
    public class Card : ICard
    {
        private decimal cardPower;
        private CardType cardType;

        public Card(decimal cardPower, CardType cardType)
        {
            this.CardPower = cardPower;
            this.CardType = cardType;
        }

        public decimal CardPower
        {
            get { return this.cardPower; }
            set { this.cardPower = value; }
        }

        public CardType CardType
        {
            get { return this.cardType; }
            set { this.cardType = value; }
        }
    }
}
