using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Models;

namespace Poker.Players
{
    public class Human : Character
    {
        private IList<Card> hand;
        private string name;
        private int power;

        public Human(string name)
        {
            this.Name = name;
        }

        public Human(string name, IList<Card> hand, int power)
        {
            this.Name = name;
            this.Hand = hand;
            this.Power = power;
        }

        public override string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public override int Power
        {
            get { return this.power; }
            set { this.power = value; }
        }

        public override IList<Card> Hand
        {
            get { return this.hand; }
            set { this.hand = value; }
        }

        public override void Check()
        {
            
        }

        public override void Fold()
        {
            
        }

        public override void Call()
        {
            
        }

        public override void Raise()
        {
            
        }
    }
}
