using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Interfaces;
using Poker.Models;

namespace Poker.Players
{
    public class Bot : Character, IComputerControlled
    {

        public Bot(string name, IList<Card> hand, int power,int chips) 
            :base(name, hand, power,chips)
        {
            
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

        public void MakeDecision()
        {
            throw new NotImplementedException();
        }

        public override void AllIn()
        {
            
        }
    }
}
