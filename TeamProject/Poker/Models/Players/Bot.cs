using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Interfaces;
using Poker.Models;

namespace Poker.Players
{
    public class Bot : Character, IBot
    {

        public Bot(string name, int chips, int power = 0) 
            :base(name, chips, power)
        {
            this.Hand = new List<ICard>();            
        }
        

        public override void MakeDecision()
        {
            
        }

    }
}
