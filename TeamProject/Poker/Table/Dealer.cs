using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
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
        private float power = 0;
        private const float initialPowerOnePair = 1;
        //TODO:from int to double return type
        public void CheckHandPower(ICharacter player, IList<ICard> tableCards)
        {
            float powerToSet = 0;

            powerToSet = CheckForThreeOfKind(player, tableCards);
            if (powerToSet >= 3)
            {
                player.Power = powerToSet;
                return;
            }
            powerToSet = CheckForTwoPair(player, tableCards);
            if (powerToSet >= 2)
            {
                player.Power = powerToSet;
                return;
            }
            powerToSet = CheckForOnePair(player, tableCards);
            if (powerToSet >= 1)
            {
                player.Power = powerToSet;
                return;
            }
            powerToSet = CheckForHighCard(player);
            if (powerToSet >= 1)
            {
                player.Power = powerToSet;
            }
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

        private float CheckForThreeOfKind(ICharacter player, IList<ICard> tableCards)
        {
            int counter = 0;
            //two equal cards in hand and searching for the thrid one in table cards
            if (CheckForPairInHand(player))
            {
                for (int i = 0; i < tableCards.Count; i++)
                {
                    if (player.Hand[0] == tableCards[i])
                    {
                        power = 3 + (player.Hand[0].CardPower/100);
                        return power;
                    } 
                }
            }
            //one card in hand and searching for another two in table cards
            for (int i = 0; i < tableCards.Count; i++)
            {
                if (player.Hand[0].CardPower == tableCards[i].CardPower)
                {
                    counter++;
                }
            }
            if (counter == 2)
            {
                power = 3 + (player.Hand[0].CardPower / 100);
                return power;
            }
            counter = 0;
            for (int i = 0; i < tableCards.Count; i++)
            {
                if (player.Hand[1].CardPower == tableCards[i].CardPower)
                {
                    counter++;
                }
            }
            if (counter == 2)
            {
                power = 3 + (player.Hand[1].CardPower / 100);
                return power;
            }
            return 0;

        }

        private float CheckForTwoPair(ICharacter player, IList<ICard> tableCards)
        {
            power = 0;
            for (int i = 0; i < tableCards.Count; i++)
            { //TODO:if find one pair then check for second
                
                if (player.Hand[0].CardPower == tableCards[i].CardPower)
                {
                    for (int j = 0; j < tableCards.Count; j++)
                    {
                        if (player.Hand[1].CardPower == tableCards[i].CardPower)
                        {
                            power = 2 + (player.Hand[0].CardPower / 100) + (player.Hand[1].CardPower / 100);
                            return power;
                        }
                    }
                }
                else if (player.Hand[1].CardPower == tableCards[i].CardPower)
                {
                    for (int j = 0; j < tableCards.Count; j++)
                    {
                        if (player.Hand[0].CardPower == tableCards[i].CardPower)
                        {
                            power = 2 + (player.Hand[0].CardPower / 100) + (player.Hand[1].CardPower / 100);
                            return power;
                        }
                    }
                }
            }
            return power;
        }

        private float CheckForOnePair(ICharacter player, IList<ICard> tableCards)
        {
            for (int i = 0; i < tableCards.Count; i++)
            {
                if (player.Hand[0].CardPower == tableCards[i].CardPower)
                {
                    power = initialPowerOnePair + (player.Hand[0].CardPower / 100);
                    return power;
                }
                if (player.Hand[1].CardPower == tableCards[i].CardPower)
                {
                    power = initialPowerOnePair + (player.Hand[1].CardPower / 100);
                    return power;
                }
                if (CheckForPairInHand(player))
                {
                    power = initialPowerOnePair + (player.Hand[0].CardPower / 100);
                    return power;
                }
            }
            return 0;
        }

        private float CheckForHighCard(ICharacter player)
        {
            float[] powers = new float[2];
            float highCardInHandPower = 0;
            powers[0] = player.Hand[0].CardPower;
            powers[1] = player.Hand[1].CardPower;
            highCardInHandPower = (powers.Max()/100);
            return highCardInHandPower;
        }

        private bool CheckForPairInHand(ICharacter player)
        {
            //return player.Hand[0].CardPower == player.Hand[1].CardPower ? true : false;
             if (player.Hand[0].CardPower == player.Hand[1].CardPower)
            {
                return true;
            }
            return false;
        }

        
    }
}
