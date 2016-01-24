using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Interfaces;
using Poker.Models;

namespace Poker.Table
{
    public class Dealer : IDealer
    {
        public void CheckHandPower()
        {
           
        }

        public void DealCards()
        {
        }

        public void SetWinner()
        {
        }

        public void Shuffle(IList<ICard> deck)
        {
            var rand = new Random();

            for (int i = deck.Count - 1; i > 0; i--)
            {
                int n = rand.Next(i + 1);
                var temp = deck[i];
                deck[i] = deck[n];
                deck[n] = temp;
            }
        }
    }
}
