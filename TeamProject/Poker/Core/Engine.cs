using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker.Core.Factories;
using Poker.Enums;
using Poker.Interfaces;
using Poker.Table;

namespace Poker.Core
{
    public class Engine : IRunnable
    {
        private readonly IBotFactory botFactory;
        private readonly IHumanFactory humanFactory;
        private readonly ICardFactory cardFactory;
        private readonly IPokerDatabase database;
        private readonly IDealer dealer;
     

        private const bool IsRunning = true;
        private int startingChips = 10000;

        public Engine(
            IBotFactory botFactory,
            IHumanFactory humanFactory,
            ICardFactory cardFactory,
            IPokerDatabase database,
            IDealer dealer)
        {
            this.botFactory = botFactory;
            this.humanFactory = humanFactory;
            this.cardFactory = cardFactory;
            this.database = database;
            this.dealer = dealer;
            
        }

        private static void ThreadStart()
        {
            Application.Run(new Form1()); // <-- form started on its own UI thread
        }

        public void Run()
        {
            var thread = new Thread(ThreadStart);
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start();

            FillDeck();
            dealer.Shuffle(database.Deck);
            
            database.AddHuman(humanFactory.CreateHuman("Player", startingChips));
            database.AddBot(botFactory.CreateBot("Bot1", startingChips));
            database.AddBot(botFactory.CreateBot("Bot2", startingChips));
            database.AddBot(botFactory.CreateBot("Bot3", startingChips));
            database.AddBot(botFactory.CreateBot("Bot4", startingChips));
            database.AddBot(botFactory.CreateBot("Bot5", startingChips));

            dealer.DealCards(database.Deck, database.HumanPlayers, database.BotPlayers, database.TableCards);
            
            database.BotPlayers.Add(this.botFactory.CreateBot("go6o", 10));
            DialogResult huie = MessageBox.Show(database.BotPlayers[0].Name);

            //while (IsRunning)
            //{

            //}
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