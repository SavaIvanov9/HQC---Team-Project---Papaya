using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Core;
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
        ICharacter human = new Human("Iphone",1000);
        ICharacter player1 = new Bot("Doan", 1000);
        ICharacter player2 = new Bot("Pony",1000);
        ICharacter player3 = new Bot("Sava", 1000);
        ICharacter player4 = new Bot("Nakov",1000);
        ICharacter player5 = new Bot("Nexus",1000);

       
        List<ICard> tableCards = new List<ICard>();
        ICardFactory cardFactory = new CardFactory();
        IPokerDatabase database = new PokerDatabase();
        
        
        [TestMethod]
        public void Dealer_PowerSettingToPlayer_ShouldWork()
        {
            List<ICharacter> players = new List<ICharacter>();
            tableCards.Add(cardFactory.CreateCard(2, CardType.Diamonds));
            tableCards.Add(cardFactory.CreateCard(6, CardType.Spades));
            tableCards.Add(cardFactory.CreateCard(4, CardType.Spades));
            tableCards.Add(cardFactory.CreateCard(5, CardType.Clubs));
            tableCards.Add(cardFactory.CreateCard(5, CardType.Diamonds));

            player1.Hand.Add(cardFactory.CreateCard(5,CardType.Hearts));
            player1.Hand.Add(cardFactory.CreateCard(2,CardType.Hearts));
            
            player2.Hand.Add(cardFactory.CreateCard(5,CardType.Spades));
            player2.Hand.Add(cardFactory.CreateCard(9,CardType.Hearts));

            human.Hand.Add(cardFactory.CreateCard(11,CardType.Spades));
            human.Hand.Add(cardFactory.CreateCard(3,CardType.Hearts));
            
            player3.Hand.Add(cardFactory.CreateCard(7,CardType.Clubs));
            player3.Hand.Add(cardFactory.CreateCard(6,CardType.Clubs));

            player4.Hand.Add(cardFactory.CreateCard(11,CardType.Hearts));
            player4.Hand.Add(cardFactory.CreateCard(14,CardType.Hearts));
            
            player5.Hand.Add(cardFactory.CreateCard(8,CardType.Hearts));
            player5.Hand.Add(cardFactory.CreateCard(13,CardType.Diamonds));

            players.Add(player1);
            players.Add(player2);
            players.Add(human);
            players.Add(player3);
            players.Add(player4);
            players.Add(player5);

            dealer.CheckHandPower(player1,tableCards);
            dealer.CheckHandPower(player2,tableCards);
            dealer.CheckHandPower(human,tableCards);
            dealer.CheckHandPower(player3,tableCards);
            dealer.CheckHandPower(player4,tableCards);
            dealer.CheckHandPower(player5,tableCards);
            

            ICharacter winner = dealer.SetWinner(players, database);
            Assert.AreEqual(winner,player1);
        }

    }
}
