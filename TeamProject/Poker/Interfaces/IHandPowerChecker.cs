using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Interfaces
{
    public interface IHandPowerChecker
    {
        //from int to double return type
        void CheckHandPower(ICharacter player,IList<ICard> tableCards);
    }
}
