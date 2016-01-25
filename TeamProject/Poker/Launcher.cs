using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker.Core;
using Poker.Core.Factories;
using Poker.Table;

namespace Poker
{
    static class Launcher
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //var botFactory = new BotFactory();
            //var database = new PokerDatabase();
            //var humanFactory = new HumanFactory();
            //var cardFactory = new CardFactory();
            //var dealer = new Dealer();

           // var form = new Form1();

            //var engine = new Engine(botFactory, humanFactory, cardFactory, database, dealer);
            //engine.Run();
            
         }
    }
}
