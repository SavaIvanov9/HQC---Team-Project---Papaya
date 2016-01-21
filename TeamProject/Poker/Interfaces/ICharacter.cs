using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Interfaces
{
    public interface ICharacter
    {
        void Check();

        void Raise();

        void Call();

        void Fold();
    }
}
