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
    public abstract class Character : ICharacter, IBot
    {
        private string name;
        private int power = 0;
        private IList<ICard> hand;
        private int chips;
        private bool isOnTurn = false;
        private bool isFolded = false;

        private Dictionary<string, bool> action = new Dictionary<string, bool>()
        {
            {"check", false },
            {"fold", false },
            {"rise", false },
            {"call", false }
        }; 

        protected Character(string name, int chips, int power = 0)
        {
            this.Name = name;
            this.Hand = new List<ICard>();
            this.Power = power;
            this.Chips = chips;
        }

        public bool IsOnTurn
        {
            get { return this.isOnTurn; }
            set { this.isOnTurn = value; }
        }

        public bool IsFolded
        {
            get { return this.isFolded; }
            set { this.isFolded = value; }
        }

        public int Chips { get; set; }

        public string Name { get; set; }

        public int Power { get; set; }

        public IList<ICard> Hand
        {
            get { return this.hand; }
            set { this.hand = value; }
        }

        public virtual void Check()
        {
            
        }

        public virtual void Raise()
        {
            
        }

        public virtual void Call()
        {
            
        }

        public virtual void Fold()
        {
            
        }

        public virtual void AllIn()
        {
            
        }

        public virtual string MakeDecision()
        {
            string hui = null;
            return hui;
        }
    }
}
