using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker.Interfaces;

namespace Poker.Core
{
    public class Test : PokerDatabase
    {
        private readonly IBotFactory botFactory;
        private readonly IPokerDatabase pokerDatabase;

        public Test(IBotFactory botFactory,IPokerDatabase pokerDatabase)
        {
            this.botFactory = botFactory;
            this.pokerDatabase = pokerDatabase;
        }

        //public void Mainlol()
        //{
        //    pokerDatabase.AddBot("Bot1", null, 2, 2);
        //    DialogResult lol;
        //    lol = MessageBox.Show(pokerDatabase.botPlayers[0].GetType().Name);
        //}

    }
}
