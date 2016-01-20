using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Interfaces;
using Poker.Models;

namespace Poker.Players
{
    public abstract class Character : IPlayer
    {
        public abstract string Name { get; set; }

        public abstract int Power { get; set; }

        public abstract IList<Card> Hand { get; set; }

        public abstract void Check();

        public abstract void Raise();

        public abstract void Call();

        public abstract void Fold();
    }
}
