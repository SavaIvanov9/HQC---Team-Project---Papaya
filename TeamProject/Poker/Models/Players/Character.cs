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
        private int power = 0;
        private IList<ICard> hand;
        private int chips;
    
        protected Character(string name, IList<ICard> cards, int chips, int power = 0)
        {
            this.Name = name;
            this.Hand = hand;
            this.Power = power;
            this.Chips = chips;
        }

        public int Chips { get; set; }

        public string Name { get; set; }

        public int Power { get; set; }

        public IList<ICard> Hand { get; set; }

        public abstract void Check();

        public abstract void Raise();

        public abstract void Call();

        public abstract void Fold();

        public abstract void AllIn();

        public abstract string GetName();
    }
}
