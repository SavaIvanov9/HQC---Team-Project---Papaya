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

        public int raiseAmount = bigBlind * 2;

        public static Form1 form;

        public static bool isRunning = true;

        private static int startingChips = 10000;
        public static int smallBlind = 500;
        public static int bigBlind = smallBlind * 2;
        public List<int> blinds = new List<int>();

        public string currDecision;
        public string humanDecision;
        public int humanRaise;

        private static Engine instance;

        //Singleton patern
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

        //Thread for UI
        private static void ThreadStart()
        {
            Application.Run(form = new Form1());
        }

        public void Run()
        {
            //Start thread for UI
            var thread = new Thread(ThreadStart);
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start();

            CreatePlayers();

            //Sets players in current game
            GenerateCurrPlayers();

            //Fill deck with cards
            dealer.FillDeck(database, cardFactory);

            //New cycle (нова врътка)
            if (database.Stages["preflop"])
            {
                ResetRaiseAmount();
                dealer.Shuffle(database.Deck);
                dealer.DealCards(database.Deck, database.HumanPlayers, database.BotPlayers, database.TableCards);

                //врътка players
                GenerateCyclePlayers();

                //Sets players power depending on their cards combinations
                SetPlayersPower();

                //Sets the first starting player 
                SetFirstPlayer();

                AddBlindsToPot();
            }

            //This happens when human make decision 
            Update(humanRaise);
        }

        public void Update(int raise = 0)
        {
            //Stages of the round (стейдж на врътката)
            if (database.Stages["preflop"])
            {
                PlayerRotator();

                RemoveFoldedPlayers();

                ContinueStage("preflop", "flop");
            }

            else if (database.Stages["flop"])
            {
                PlayerRotator();

                RemoveFoldedPlayers();

                ContinueStage("flop", "turn");
            }

            else if (database.Stages["turn"])
            {
                PlayerRotator();

                RemoveFoldedPlayers();

                ContinueStage("turn", "river");
            }

            else if (database.Stages["river"])
            {
                PlayerRotator();

                RemoveFoldedPlayers();

                ContinueStage("river", "end");
            }

            else if (database.Stages["end"])
            {
                dealer.SetWinner(database.CyclePlayers, database);

                ClearCyclePlayers();

                CheckForEnd();

                ClearCyclePlayers();

                dealer.ReturnCards(database.Deck, database.HumanPlayers, database.BotPlayers, database.TableCards);

                ContinueStage("end", "preflop");
            }
        }

        //Sets players that are declared in the game
        private void GenerateCurrPlayers()
        {
            foreach (ICharacter bot in database.BotPlayers)
            {
                database.CurrPlayers.Add(bot);
            }

            foreach (ICharacter human in database.HumanPlayers)
            {
                database.CurrPlayers.Add(human);
            }
        }

        //Sets players with more than 0 chips for new cycle
        private void GenerateCyclePlayers()
        {
            foreach (ICharacter bot in database.BotPlayers)
            {
                if (bot.Chips > 0)
                {
                    database.CyclePlayers.Add(bot);
                }
            }

            foreach (ICharacter human in database.HumanPlayers)
            {
                if (human.Chips > 0)
                {
                    database.CyclePlayers.Add(human);
                }
            }
        }

        //Gives players permission for action
        private void PlayerRotator()
        {
            for (int i = 0; i < database.CyclePlayers.Count; i++)
            {
                if (database.CyclePlayers[i] is Human)
                {
                    if (currDecision == "raise")
                    {
                        form.bCheck.Enabled = false;

                        if (database.CyclePlayers[i].Chips < raiseAmount)
                        {
                            form.bCall.Enabled = false;

                            if (humanDecision == "allin")
                            {
                                commandProcessor.AllIn(database, database.CyclePlayers[i]);
                            }

                            if (humanDecision == "fold")
                            {
                                commandProcessor.Fold(database, database.CyclePlayers[i]);
                            }
                        }

                        else
                        {
                            if (humanDecision == "call")
                            {
                                commandProcessor.Call(database, database.CyclePlayers[i], raiseAmount);
                            }

                            if (humanDecision == "allin")
                            {
                                commandProcessor.AllIn(database, database.CyclePlayers[i]);
                            }

                            if (humanDecision == "raise")
                            {
                                commandProcessor.Raise(database, database.CyclePlayers[i], humanRaise);
                            }

                            if (humanDecision == "fold")
                            {
                                commandProcessor.Fold(database, database.CyclePlayers[i]);
                            }
                        }

                        AddCalledChips(database.CurrPlayers[i], raiseAmount);
                    }

                    else
                    {
                        if (humanDecision == "call")
                        {
                            commandProcessor.Call(database, database.CyclePlayers[i], raiseAmount);
                        }

                        if (humanDecision == "allin")
                        {
                            commandProcessor.AllIn(database, database.CyclePlayers[i]);
                        }

                        if (humanDecision == "raise")
                        {
                            commandProcessor.Raise(database, database.CyclePlayers[i], humanRaise);
                        }

                        if (humanDecision == "check")
                        {
                            commandProcessor.Check();
                        }

                        if (humanDecision == "fold")
                        {
                            commandProcessor.Fold(database, database.CyclePlayers[i]);
                        }

                        AddCalledChips(database.CurrPlayers[i], raiseAmount);
                    }
                }

                if (database.CurrPlayers[i] is Bot)
                {
                    database.CurrPlayers[i].MakeDecision(currDecision, database.CyclePlayers[i]);
                }

                if (i == database.CurrPlayers.Count - 1 && currDecision == "raise")
                {
                    i = 0;
                }
            }
        }

        private void RemoveFoldedPlayers()
        {
            foreach (ICharacter player in database.CyclePlayers)
            {
                if (player.IsFolded)
                {
                    database.CyclePlayers.Remove(player);
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

        private void ClearCyclePlayers()
        {
            database.CyclePlayers.Clear();
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
            var tempObj = database.CyclePlayers[database.CyclePlayers.Count - 1];

            for (int i = database.CyclePlayers.Count - 1; i >= 1; i--)
            {
                database.CyclePlayers[i] = database.CyclePlayers[i - 1];
            }

            database.CyclePlayers[0] = tempObj;
        }

        //moje da ne trea
        private void SetBlinds()
        {
            for (int i = 0; i < database.CyclePlayers.Count; i++)
            {
                if (i < database.CyclePlayers.Count - 2)
                {
                    blinds.Add(0);
                }
                if (i == database.CyclePlayers.Count - 2)
                {
                    blinds.Add(smallBlind);
                }
                else if (i == database.CyclePlayers.Count - 1)
                {
                    blinds.Add(bigBlind);
                }
            }
        }

        private void AddCalledChips(ICharacter player, int raiseAmount)
        {
            player.Chips -= raiseAmount;
            database.Pot += raiseAmount;
        }

        private void AddBlindsToPot()
        {
            database.Pot += bigBlind + smallBlind;
            database.CyclePlayers[database.CyclePlayers.Count - 1].Chips -= bigBlind;
            database.CyclePlayers[database.CyclePlayers.Count - 2].Chips -= smallBlind;
        }

        private void SetPlayersPower()
        {
            foreach (var player in database.CyclePlayers)
            {
                dealer.CheckHandPower(player, database.TableCards);
            }
        }

        private void ResetRaiseAmount()
        {
            raiseAmount = bigBlind * 2;
        }

        private void CheckForEnd()
        {
            foreach (var player in database.CurrPlayers)
            {
                if (player is Human && player.Chips <= 0)
                {
                    MessageBox.Show("You lose!!!");
                    Application.Exit();
                }
            }
        }
    }
}