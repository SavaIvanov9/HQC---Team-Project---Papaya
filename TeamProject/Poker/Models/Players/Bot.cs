using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Core;
using Poker.Interfaces;
using Poker.Models;

namespace Poker.Players
{
    public class Bot : Character, IBot
    {
        private Random random = new Random();

        public Bot(string name, int chips, decimal power = 0)
            : base(name, chips, power)
        {
            this.Hand = new List<ICard>();
        }


        public override void MakeDecision(string currDecision, ICharacter player)
        {
            if (currDecision == "raise")
            {
                if (player.Chips < Engine.Instance.raiseAmount)
                {
                    int rInt = random.Next(1, 2);
                    if (rInt == 1)
                    {
                        Engine.Instance.raiseAmount = player.Chips;
                        Engine.Instance.commandProcessor.AllIn(Engine.Instance.database, player);
                    }

                    if (rInt == 3)
                    {
                        Engine.Instance.commandProcessor.Fold(Engine.Instance.database, player);
                    }
                }
                else
                {
                    int rInt = random.Next(1, 4);

                    if (rInt == 1)
                    {
                        Engine.Instance.raiseAmount = player.Chips;
                        Engine.Instance.commandProcessor.AllIn(Engine.Instance.database, player);
                    }

                    if (rInt == 2 && player.Chips > Engine.Instance.raiseAmount)
                    {
                        Engine.Instance.commandProcessor.Call(Engine.Instance.database, player,
                            Engine.Instance.raiseAmount);
                    }

                    if (rInt == 3)
                    {
                        Engine.Instance.commandProcessor.Fold(Engine.Instance.database, player);
                    }

                    if (rInt == 4 && Engine.Instance.raiseAmount < player.Chips)
                    {
                        Engine.Instance.commandProcessor.Raise(Engine.Instance.database, player,
                            Engine.Instance.raiseAmount * 2);
                    }
                }

            }
            else
            {
                int rInt = random.Next(1, 5);

                if (rInt == 1)
                {
                    Engine.Instance.commandProcessor.AllIn(Engine.Instance.database, player);
                }

                if (rInt == 2 && player.Chips > Engine.Instance.raiseAmount)
                {
                    Engine.Instance.commandProcessor.Call(Engine.Instance.database, player, Engine.Instance.raiseAmount);
                }

                if (rInt == 3)
                {
                    Engine.Instance.commandProcessor.Fold(Engine.Instance.database, player);
                }

                if (rInt == 4 && Engine.Instance.raiseAmount < player.Chips)
                {
                    Engine.Instance.commandProcessor.Raise(Engine.Instance.database, player, Engine.Instance.raiseAmount);
                }

                if (rInt == 5)
                {
                    Engine.Instance.commandProcessor.Check();
                }
            }
        }
    }
}
