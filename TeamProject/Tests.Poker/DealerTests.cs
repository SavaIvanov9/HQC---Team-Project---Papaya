using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Core.Factories;
using Poker.Enums;
using Poker.Interfaces;
using Poker.Players;
using Poker.Table;

namespace Tests.Poker
{
    [TestClass]
    public class DealerTests
    {
        Dealer dealer = new Dealer();
        ICharacter player1 = new Human("Iphone",1000);
        ICharacter player2 = new Human("Sava", 1000);
        List<ICard> tableCards = new List<ICard>();
        ICardFactory cardFactory = new CardFactory();
      
        [TestMethod]
        public void Dealer_PowerSettingToPlayer_ShouldWork()
        {
            tableCards.Add(cardFactory.CreateCard(2, CardType.Diamonds));
            tableCards.Add(cardFactory.CreateCard(3, CardType.Spades));
            tableCards.Add(cardFactory.CreateCard(4, CardType.Diamonds));
            tableCards.Add(cardFactory.CreateCard(2, CardType.Diamonds));
            tableCards.Add(cardFactory.CreateCard(7, CardType.Diamonds));

            player1.Hand.Add(cardFactory.CreateCard(5,CardType.Diamonds));
            player1.Hand.Add(cardFactory.CreateCard(6,CardType.Hearts));
            
            player2.Hand.Add(cardFactory.CreateCard(5,CardType.Spades));
            player2.Hand.Add(cardFactory.CreateCard(13,CardType.Hearts));

            dealer.CheckHandPower(player1,tableCards);
            dealer.CheckHandPower(player2,tableCards);

            Assert.AreEqual(4.06m,player1.Power);
        }
    }
}
