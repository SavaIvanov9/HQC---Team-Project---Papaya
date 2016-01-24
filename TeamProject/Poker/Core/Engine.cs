using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Core.Factories;
using Poker.Enums;
using Poker.Interfaces;
using Poker.Table;

namespace Poker.Core
{
    public class Engine : IRunnable
    {
        private readonly IBotFactory botFactory = new BotFactory();
        private readonly IHumanFactory humanFactory = new HumanFactory();
        private readonly ICardFactory cardFactory = new CardFactory();
        private readonly IPokerDatabase database = new PokerDatabase();
        private readonly IDealer dealer = new Dealer();
        
        private const bool IsRunning = true;
        private int startingChips = 10000;

        public Engine(
            IBotFactory botFactory,
            IHumanFactory humanFactory,
            ICardFactory cardFactory,
            IPokerDatabase database)
        {
            this.botFactory = botFactory;
            this.humanFactory = humanFactory;
            this.cardFactory = cardFactory;
            this.database = database;
        }

        public void Run()
        {
            FillDeck();
            dealer.Shuffle(database.Deck);
            
            database.AddHuman(humanFactory.CreateHuman("Player", startingChips));
            database.AddBot(botFactory.CreateBot("Bot1", startingChips));
            database.AddBot(botFactory.CreateBot("Bot2", startingChips));
            database.AddBot(botFactory.CreateBot("Bot3", startingChips));
            database.AddBot(botFactory.CreateBot("Bot4", startingChips));
            database.AddBot(botFactory.CreateBot("Bot5", startingChips));

            while (IsRunning)
            {

            }
        }

        private void FillDeck()
        {
            for (int cardPower = 2; cardPower <= 14; cardPower++)
            {
                foreach (CardType cardType in Enum.GetValues(typeof (CardType)))
                {
                    database.AddCard(cardFactory.CreateCard(cardPower, cardType));
                }
            }
        }
    }
}