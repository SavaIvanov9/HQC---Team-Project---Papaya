using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private decimal power = 0;
        private const decimal initialPowerOnePair = 1;
        private const decimal initialPowerTwoPair = 2;
        private const decimal initialPowerThreeOfKind = 3;
        private const decimal initialPowerStraight = 4;
        private const decimal initialPowerFlush = 5;
        private const decimal initialPowerFullHouse = 6;
        private const decimal initialPowerFourOfKind = 7;
        private const decimal initialStraightFlush = 8;
        private const decimal initialPowerRoyalFlush = 9;




        //TODO:from int to double return type
        public void CheckHandPower(ICharacter player, IList<ICard> tableCards)
        {
            decimal powerToSet = 0;

            powerToSet = CheckForFlush(player, tableCards);
            if (powerToSet >= initialPowerFlush)
            {
                player.Power = powerToSet;
                return;
            }

            powerToSet = CheckForStraight(player, tableCards);
            if (powerToSet >= initialPowerStraight)
            {
                player.Power = powerToSet;
                return;
            }

            powerToSet = CheckForThreeOfKind(player, tableCards);
            if (powerToSet >= initialPowerThreeOfKind)
            {
                player.Power = powerToSet;
                return;
            }

            powerToSet = CheckForTwoPair(player, tableCards);
            if (powerToSet >= initialPowerTwoPair)
            {
                player.Power = powerToSet;
                return;
            }

            powerToSet = CheckForOnePair(player, tableCards);
            if (powerToSet >= initialPowerOnePair)
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

        private decimal CheckForFlush(ICharacter player, IList<ICard> tableCards)
        {
            List<ICard> allCards = new List<ICard>();
            allCards.AddRange(tableCards);
            allCards.AddRange(player.Hand);
            int counter = 0;
            decimal flushPower = 0;
            foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
            {
                foreach (ICard card in allCards)
                {
                    if (card.CardType == cardType)
                    {
                        flushPower += card.CardPower;
                        counter++;
                    }
                }
                if (counter >= 5)
                {
                    return initialPowerFlush + (flushPower/100);
                }
                counter = 0;
            }
            return 0;
        }


        private decimal CheckForStraight(ICharacter player, IList<ICard> tableCards)
        {
            List<ICard> allCards = new List<ICard>();
            List<ICard> sortedList = new List<ICard>();
            allCards.AddRange(tableCards);
            allCards.AddRange(player.Hand);
            sortedList.AddRange(allCards.OrderBy(p => p.CardPower));

            bool done = false;
            int counter = 0;
            ICard lastCard = null;
            for (int i = 0; i < allCards.Count-1; i++)
            {
                if (sortedList[i].CardPower == sortedList[i + 1].CardPower - 1)
                {
                    counter++;
                    if (counter == 4)
                    {
                        lastCard = sortedList[i + 1];
                        done = true;
                        break;
                    }
                }
                else
                {
                    done = false;
                    counter = 0;
                }
            }
            if (done)
            {
                return initialPowerStraight + (lastCard.CardPower/100);
            }
            return 0;
        }

        private decimal CheckForThreeOfKind(ICharacter player, IList<ICard> tableCards)
        {
            int counter = 0;
            //two equal cards in hand and searching for the thrid one in table cards
            if (CheckForPairInHand(player))
            {
                for (int i = 0; i < tableCards.Count; i++)
                {
                    if (player.Hand[0] == tableCards[i])
                    {
                        power = initialPowerThreeOfKind + (player.Hand[0].CardPower/100);
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
                power = initialPowerThreeOfKind + (player.Hand[0].CardPower / 100);
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
                power = initialPowerThreeOfKind + (player.Hand[1].CardPower / 100);
                return power;
            }
            return 0;

        }

        private decimal CheckForTwoPair(ICharacter player, IList<ICard> tableCards)
        {
            power = 0;
            for (int i = 0; i < tableCards.Count; i++)
            { //TODO:if find one pair then check for second
                
                if (player.Hand[0].CardPower == tableCards[i].CardPower)
                {
                    for (int j = 0; j < tableCards.Count; j++)
                    {
                        if (player.Hand[1].CardPower == tableCards[j].CardPower)
                        {
                            power = initialPowerTwoPair + (player.Hand[0].CardPower / 100) + (player.Hand[1].CardPower / 100);
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
                            power = initialPowerTwoPair + (player.Hand[0].CardPower / 100) + (player.Hand[1].CardPower / 100);
                            return power;
                        }
                    }
                }
            }
            return power;
        }

        private decimal CheckForOnePair(ICharacter player, IList<ICard> tableCards)
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

        private decimal CheckForHighCard(ICharacter player)
        {
            decimal[] powers = new decimal[2];
            decimal highCardInHandPower = 0;
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
