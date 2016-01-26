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

        public void SetWinner()
        {
        }
        
        public void Shuffle(IList<ICard> deck)
        {
            var randomNumberGenerator = new Random();

            var shuffledDeck = deck;
            for (var currentCardIndex = 0; currentCardIndex < 52; currentCardIndex++)
            {
                int nextPositionInDeck = currentCardIndex + randomNumberGenerator.Next(0, 52 - currentCardIndex);
                var movedCard = shuffledDeck[currentCardIndex];
                shuffledDeck[currentCardIndex] = shuffledDeck[nextPositionInDeck];
                shuffledDeck[nextPositionInDeck] = movedCard;
            }
            deck = shuffledDeck;
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
