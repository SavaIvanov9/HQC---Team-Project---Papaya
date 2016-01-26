
namespace Poker.Interfaces
{
    public interface IDealer: IDeckFillable, IDeckShuffler, ICardDealable, IHandPowerChecker, IWinnerSetter
    {
    }
}
