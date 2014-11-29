namespace Poker
{
    using Poker.Enums;

    // Defines methods that a value type or class implements
    // to evaluate poker hands.
    public interface IHandEvaluator
    {
        bool IsValid(IHand hand);

        HandCategory GetCategory(IHand hand);

        int CompareHands(IHand hand1, IHand hand2);
    }
}
