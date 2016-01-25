using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
    
        protected Character(string name, int chips, int power = 0)
        {
            this.Name = name;
            this.Hand = new List<ICard>();
            this.Power = power;
            this.Chips = chips;
        }

        public int Chips { get; set; }

        public string Name { get; set; }

        public int Power { get; set; }

        public IList<ICard> Hand
        {
            get
            {
                return this.hand;
            }
            set { this.hand = value; }
        }

        public abstract void Check();

        public abstract void Raise();

        public abstract void Call();

        public abstract void Fold();

        public abstract void AllIn();

        public abstract string GetName();
    }
}
