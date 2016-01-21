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

        public Bot(string name, IList<Card> hand, int power) 
            :base(name, hand, power)
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
    }
}
