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
        int Power { get; set; }
        bool IsOnTurn { get; set; }
        void MakeDecision();
    }
}
