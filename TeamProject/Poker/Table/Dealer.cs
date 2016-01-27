using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Enums;
using Poker.Interfaces;
using Poker.Models;

namespace Poker.Table
{
    public class Dealer : IDealer
    {

        public void CheckHandPower()
        {

        }

        public void DealCards(IList<ICard> deck, IList<ICharacter> humans, IList<ICharacter> bots, IList<ICard> tableCards)
        {
            //for (int i = 0; i <= 17; i++)
            //{
            //    humans[]
            //}
            foreach (ICharacter human in humans)
            {
                human.Hand.Add(deck[deck.Count - 1]);
                deck.RemoveAt(deck.Count - 1);

                human.Hand.Add(deck[deck.Count - 1]);
                deck.RemoveAt(deck.Count - 1);
            }

            foreach (ICharacter bot in bots)
            {
                bot.Hand.Add(deck[deck.Count - 1]);
                deck.RemoveAt(deck.Count - 1);

                bot.Hand.Add(deck[deck.Count - 1]);
                deck.RemoveAt(deck.Count - 1);
            }

            for (int i = 0; i < 5; i++)
            {
                tableCards.Add(deck[deck.Count - 1]);
                deck.RemoveAt(deck.Count - 1);
            }

        }

        public void ReturnCards(IList<ICard> deck, IList<ICharacter> humans, IList<ICharacter> bots, IList<ICard> tableCards)
        {
            //for (int i = 0; i <= 17; i++)
            //{
            //    humans[]
            //}
            foreach (ICharacter human in humans)
            {
                deck.Add(human.Hand[1]);
                human.Hand.Remove(human.Hand[1]);

                deck.Add(human.Hand[0]);
                human.Hand.Remove(human.Hand[0]);

            }

            foreach (ICharacter bot in bots)
            {
                deck.Add(bot.Hand[1]);
                bot.Hand.Remove(bot.Hand[1]);

                deck.Add(bot.Hand[0]);
                bot.Hand.Remove(bot.Hand[0]);
            }

            //for (int i = 0; i < 5; i++)
            //{
            //    tableCards.Add(deck[deck.Count - 1]);
            //    deck.RemoveAt(deck.Count - 1);
            //}

            for (int i = 0; i < 5; i++)
            {
                deck.Add(tableCards[tableCards.Count - 1]);
                tableCards.RemoveAt(tableCards.Count - 1);
            }


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

        public void FillDeck(IPokerDatabase database, ICardFactory cardFactory)
        {
            for (int cardPower = 2; cardPower <= 14; cardPower++)
            {
                foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
                {
                    database.AddCard(cardFactory.CreateCard(cardPower, cardType));
                }
            }
        }
    }
}
