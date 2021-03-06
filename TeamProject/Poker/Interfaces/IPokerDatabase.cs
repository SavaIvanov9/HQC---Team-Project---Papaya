﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Poker.Models;

namespace Poker.Interfaces
{
    public interface IPokerDatabase
    {
        IList<ICard> Deck { get; set; }
        IList<ICharacter> HumanPlayers { get; set; }
        IList<ICharacter> BotPlayers { get; set; }
        IList<ICard> TableCards { get; set; }
        int Pot { get; set; }
        Dictionary<string, bool>  Stages { get; set; }
        IList<ICharacter> CurrPlayers { get; set; }
        List<ICharacter> CyclePlayers { get; set; }


        void AddBot(ICharacter bot);
        void AddHuman(ICharacter human);
        void AddCard(ICard card);
    }
}
