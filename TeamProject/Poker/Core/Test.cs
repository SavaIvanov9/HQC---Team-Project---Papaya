using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Interfaces;

namespace Poker.Core
{
    public class Test : PokerDatabase
    {
        private readonly IBotFactory botFactory;
        private readonly ICharacter character;
        private readonly IPokerDatabase pokerDatabase;
        private PokerDatabase lol = new PokerDatabase();
        


    }
}
