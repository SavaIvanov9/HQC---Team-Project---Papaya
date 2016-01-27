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
using Poker.Core.Commands;

namespace Poker.Core
{
    public class Engine : IRunnable
    {
        public readonly IBotFactory botFactory = new BotFactory();
        public readonly IHumanFactory humanFactory = new HumanFactory();
        public readonly ICardFactory cardFactory = new CardFactory();
        public readonly IPokerDatabase database = new PokerDatabase();
        public readonly IDealer dealer = new Dealer();
        public readonly IProcessCommand commandProcessor = new CommandProcessor();
         
        public int raiseAmount;

        public static Form1 form;

        public static bool isRunning = true;

        private static int startingChips = 10000;
        public static int smallBlind = 500;
        public static int bigBlind = smallBlind*2;
        public List<int> blinds = new List<int>();

        public string currDecision;

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

            CreatePlayers();

            Update(isRunning);
        }

        public void Update(bool isRunning)
        {
            while (isRunning)
            {
                CheckForEnd();

                dealer.Shuffle(database.Deck);
                dealer.DealCards(database.Deck, database.HumanPlayers, database.BotPlayers, database.TableCards);
                
                //players in врътката
                GenerateCurrPlayers();

                //sets the new first player
                SetFirstPlayer();

                // напраи го на метод // блинд логика
                database.Pot += (ulong)bigBlind + (ulong)smallBlind;
                database.CurrPlayers[database.CurrPlayers.Count - 1].Chips -= bigBlind;
                database.CurrPlayers[database.CurrPlayers.Count - 2].Chips -= smallBlind;

                //SetBlinds();

                //stages of врътката
                if (database.Stages["preflop"])
                {
                    PlayerRotator();

                    RemoveFoldedPlayers();

                    ContinueStage("preflop", "flop");
                }

                if (database.Stages["flop"])
                {
                    PlayerRotator();

                    RemoveFoldedPlayers();

                    ContinueStage("flop", "turn");
                }

                if (database.Stages["turn"])
                {
                    PlayerRotator();

                    RemoveFoldedPlayers();

                    ContinueStage("turn", "river");
                }

                if (database.Stages["river"])
                {
                    PlayerRotator();

                    RemoveFoldedPlayers();

                    ContinueStage("river", "end");
                }

                if (database.Stages["end"])
                {
                    ContinueStage("end", "preflop");
                }

                ClearCurrPlayers();

                dealer.ReturnCards(database.Deck, database.HumanPlayers, database.BotPlayers, database.TableCards);
            }
        }
        
        private void HumanDecision()
        {

        }

        private void GenerateCurrPlayers()
        {
            foreach (ICharacter human in database.HumanPlayers)
            {
                database.CurrPlayers.Add(human);
            }
            foreach (ICharacter bot in database.BotPlayers)
            {
                database.CurrPlayers.Add(bot);
            }
        }

        private void PlayerRotator()
        {
            for (int i = 0; i < database.CurrPlayers.Count; i++)
            {
                if (database.CurrPlayers[i] is Human && database.CurrPlayers[i].IsFolded == false)
                {
                    if (currDecision == "raise")
                    {
                        form.bCheck.Enabled = false;

                        HumanDecision();
                    }

                    else
                    {
                        HumanDecision();
                    }
                }

                if (database.CurrPlayers[i] is Bot && database.CurrPlayers[i].IsFolded == false)
                {
                    if (currDecision == "raise")
                    {
                        raiseAmount = bigBlind*2;
                        database.CurrPlayers[i].MakeDecision(currDecision, database.CurrPlayers[i]);
                    }

                    else
                    {
                        database.CurrPlayers[i].MakeDecision(currDecision, database.CurrPlayers[i]);
                    }                    
                }

                if (i == database.CurrPlayers.Count - 1 && currDecision == "raise")
                {
                    i = 0;
                }
            }
        }

        private void RemoveFoldedPlayers()
        {
            foreach (ICharacter player in database.CurrPlayers)
            {
                if (player.IsFolded)
                {
                    database.CurrPlayers.Remove(player);
                }
            }
        }

        private void CreatePlayers()
        {
            database.AddBot(botFactory.CreateBot("Bot1", startingChips));
            database.AddBot(botFactory.CreateBot("Bot2", startingChips));
            database.AddBot(botFactory.CreateBot("Bot3", startingChips));
            database.AddBot(botFactory.CreateBot("Bot4", startingChips));
            database.AddBot(botFactory.CreateBot("Bot5", startingChips));
            database.AddHuman(humanFactory.CreateHuman("Player", startingChips));
        }

        private void ClearCurrPlayers()
        {
            database.CurrPlayers.Clear();
        }

        public void GotinMethod()
        {
            //CheckPot();
            string x = "raboti bratooooo";
            MessageBox.Show(x);
        }

        public void CheckPot()
        {
            form.pStatus.Text = "lol";
        }

        private void ContinueStage(string currentStage, string nextStage)
        {
            database.Stages[currentStage] = false;
            database.Stages[nextStage] = true;
        }

        private void SetFirstPlayer()
        {
            var tempObj = database.CurrPlayers[0];

            for (int i = 0; i < database.CurrPlayers.Count - 1; i++)
            {
                database.CurrPlayers[i] = database.CurrPlayers[i + 1];
            }

            database.CurrPlayers[database.CurrPlayers.Count - 1] = tempObj;
        }

        private void SetBlinds()
        {
            for (int i = 0; i < database.CurrPlayers.Count; i++)
            {
                if (i < database.CurrPlayers.Count - 2)
                {
                    blinds.Add(0);
                }
                if (i == database.CurrPlayers.Count - 1)
                {
                    blinds.Add(smallBlind);
                }
                else if (i == database.CurrPlayers.Count -2)
                {
                    blinds.Add(bigBlind);
                }
            }
        }

        private void CheckForEnd()
        {
            foreach (var player in database.CurrPlayers)
            {
                if (player is Human && player.Chips <= 0)
                {
                    isRunning = false;
                }
            }
        }
    }
}