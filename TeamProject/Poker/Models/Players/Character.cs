using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Interfaces;
using Poker.Models;

namespace Poker.Players
{
    public abstract class Character : ICharacter
    {
        private string name;
        private int power;
        private IList<Card> hand;
    
        protected Character(string name, IList<Card> hand, int power,int chips)
        {
            this.Name = name;
            this.Hand = hand;
            this.Power = power;
            this.Chips = chips;
        }

        public int Chips { get; set; }

        public string Name { get; set; }

        public int Power { get; set; }

        public IList<Card> Hand { get; set; }

        public abstract void Check();

        public abstract void Raise();

        public abstract void Call();

        public abstract void Fold();
    }
}
