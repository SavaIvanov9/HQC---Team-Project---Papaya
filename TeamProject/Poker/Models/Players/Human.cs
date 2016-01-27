using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Interfaces;
using Poker.Models;

namespace Poker.Players
{
    public class Human : Character
    {

        public Human(string name, int chips, float power = 0)
            :base(name, chips, power)
        {
            this.Hand = new List<ICard>();
        }

    }
}
