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

        public Bot(string name, int chips, int power = 0) 
            :base(name, chips, power)
        {
            this.Hand = new List<ICard>();            
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
          
        }

        public override void AllIn()
        {
            
        }

        public override string GetName()
        {
            return Name;
        }
    }
}
