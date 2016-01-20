using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Models;

namespace Poker.Players
{
    public class Bot : Character
    {
        private IList<Card> hand;
        private string name;
        private int power;



        public Bot(string name, IList<Card> hand, int power )
        {
            this.Name = name;
            this.Hand = hand;
            this.Power = power;
        }

        public IList<Card> Hand
        {
            get
            {
                return this.hand;
                
            }
            set
            {
                this.hand = value;
                
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                
            }
        }

        public int Power { get; set; }
    }
}
