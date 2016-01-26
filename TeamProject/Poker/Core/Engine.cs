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
using Poker.Players;
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

        public static Form1 form;
        
        public bool isRunning = true;
        private int startingChips = 10000;

        private static Engine instance;

        private Engine() { }

        public static Engine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Engine();
                }

                return instance;
            }
        }

        //public Engine(
        //    IBotFactory botFactory,
        //    IHumanFactory humanFactory,
        //    ICardFactory cardFactory,
        //    IPokerDatabase database,
        //    IDealer dealer)
        //{
        //    this.botFactory = botFactory;
        //    this.humanFactory = humanFactory;
        //    this.cardFactory = cardFactory;
        //    this.database = database;
        //    this.dealer = dealer;
            
        //}

        private static void ThreadStart()
        {
            Application.Run(form = new Form1()); // <-- form started on its own UI thread
        }

        public void Run()
        {
            
            var thread = new Thread(ThreadStart);
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start();

            dealer.FillDeck(database, cardFactory);
            //dealer.Shuffle(database.Deck);
            
            database.AddHuman(humanFactory.CreateHuman("Player", startingChips));
            database.AddBot(botFactory.CreateBot("Bot1", startingChips));
            database.AddBot(botFactory.CreateBot("Bot2", startingChips));
            database.AddBot(botFactory.CreateBot("Bot3", startingChips));
            database.AddBot(botFactory.CreateBot("Bot4", startingChips));
            database.AddBot(botFactory.CreateBot("Bot5", startingChips));

            //database.BotPlayers.Add(this.botFactory.CreateBot("go6o", 10));
            //MessageBox.Show(database.BotPlayers[0].Name;

            Update(isRunning);

        }

        private void Update(bool isRunning)
        {
            while (isRunning)
            {
                dealer.Shuffle(database.Deck);
                foreach (ICharacter human in database.HumanPlayers)
                {
                    database.CurrPlayers.Add(human);
                }
                foreach (ICharacter bot in database.BotPlayers)
                {
                    database.CurrPlayers.Add(bot);
                }
                dealer.DealCards(database.Deck, database.HumanPlayers, database.BotPlayers, database.TableCards);
                if (database.Stages["preflop"])
                {
                    //MessageBox.Show("it works!");
                    foreach (ICharacter player in database.CurrPlayers)
                    {
                        if (player.Chips <= 0)
                        {
                            database.CurrPlayers.Remove(player);
                        }

                        if (player is Human)
                        {
                            HumanDecision();
                        }
                        else if (player is Bot)
                        {
                            player.MakeDecision();
                        }
                    }

                    database.Stages["preflop"] = false;
                    database.Stages["flop"] = true;
                }
                if (database.Stages["flop"])
                {
                    database.Stages["flop"] = false;
                    database.Stages["turn"] = true;
                }
                if (database.Stages["turn"])
                {
                    database.Stages["turn"] = false;
                    database.Stages["river"] = true;
                }
                if (database.Stages["river"])
                {
                    database.Stages["river"] = false;
                    database.Stages["end"] = true;
                }
                if (database.Stages["end"])
                {
                    database.Stages["end"] = false;
                    database.Stages["preflop"] = true;
                }
                isRunning = false;
            }
        }

        private void DoFold()
        {
            
        }

        private void HumanDecision()
        {
            
        }
        
    }
}