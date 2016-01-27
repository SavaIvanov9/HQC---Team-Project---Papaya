﻿using System;
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

        public Bot(string name, int chips, float power = 0) 
            :base(name, chips, power)
        {
            this.Hand = new List<ICard>();            
        }
        

        public override void MakeDecision(string currDecision, ICharacter player)
        {
            if (currDecision == "raise")
            {
                Random random = new Random();
                int rInt = random.Next(1, 4);

                if (rInt == 1)
                {
                    Engine.Instance.commandProcessor.AllIn(Engine.Instance.database, player);
                }

                if (rInt == 2)
                {
                    Engine.Instance.commandProcessor.Call(Engine.Instance.database, player, Engine.Instance.raiseAmount);
                }

                if (rInt == 3)
                {
                    Engine.Instance.commandProcessor.Fold(Engine.Instance.database, player);
                }

                if (rInt == 4)
                {
                    Engine.Instance.commandProcessor.Raise(Engine.Instance.database, player, Engine.Instance.raiseAmount);
                }
            }
            else
            {
                Random random = new Random();
                int rInt = random.Next(1, 5);

                if (rInt == 1)
                {
                    Engine.Instance.commandProcessor.AllIn(Engine.Instance.database, player);
                }

                if (rInt == 2)
                {
                    Engine.Instance.commandProcessor.Call(Engine.Instance.database, player, Engine.Instance.raiseAmount);
                }

                if (rInt == 3)
                {
                    Engine.Instance.commandProcessor.Fold(Engine.Instance.database, player);
                }

                if (rInt == 4)
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
