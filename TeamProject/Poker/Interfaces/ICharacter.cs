using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Interfaces
{
    public interface ICharacter : IPlayable
    {
        string Name { get; set; }
        int Chips { get; set; }
        IList<ICard> Hand { get; set; }
        decimal Power { get; set; }
        bool IsOnTurn { get; set; }
        bool IsFolded { get; set; }
        void MakeDecision(string currDecision, ICharacter player);
    }
}
