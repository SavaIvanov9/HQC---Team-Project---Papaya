using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Enums;

namespace Poker.Models
{
    public class Card
    {
        //LOL
        private int cardPower;
        private CardType cardType;

        public Card(int cardPower, CardType cardType)
        {
            this.CardPower = cardPower;
            this.CardType = cardType;
        }

        public int CardPower
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
