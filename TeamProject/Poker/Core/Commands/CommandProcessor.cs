using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker.Interfaces;

namespace Poker.Core.Commands
{
    public class CommandProcessor : IProcessCommand
    {
        private int raiseAmount = 0;

        public CommandProcessor()
        {
            this.RaiseAmount = raiseAmount;
        }

        public int RaiseAmount 
        {
            get { return this.raiseAmount; }
            set { this.raiseAmount = value; }
        }

        public void ProcessCommand(string command, IPokerDatabase database, ICharacter player, int raiseAmount)
        {
            switch (command)
            {
                case Constants.Player_Fold:
                    this.Fold(database, player);
                    break;
                case Constants.Player_Call:
                    this.Call(database, player, raiseAmount);
                    break;
                case Constants.Player_AllIn:
                    this.AllIn(database, player);
                    break;
                case Constants.Player_Raise:
                    this.Raise(database, player, raiseAmount);
                    break;
                case Constants.Player_Check:
                    this.Check();
                    break;
                default:
                    break;
            }
        }
        
        public void Fold(IPokerDatabase database, ICharacter player)
        {
            Engine.Instance.currDecision = "fold";
            database.CurrPlayers.Remove(player);
        }

        public void Call(IPokerDatabase database, ICharacter player, int raiseAmount)
        {
            Engine.Instance.currDecision = "call";
            if (player.Chips >= raiseAmount)
            {
                database.Pot += (ulong) raiseAmount;
                player.Chips -= raiseAmount;
            }
        }

        public void AllIn(IPokerDatabase database, ICharacter player)
        {
            Engine.Instance.currDecision = "allin";
            database.Pot += (ulong) player.Chips;
        }

        public void Raise(IPokerDatabase database, ICharacter player, int raiseAmount)
        {
            Engine.Instance.currDecision = "raise";
            if (player.Chips >= raiseAmount)
            {
                database.Pot += (ulong) raiseAmount;
                player.Chips -= raiseAmount;
            }
        }

        public void Check()
        {
            
        }
    }
}