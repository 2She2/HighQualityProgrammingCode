﻿namespace Poker.Enums
{
    /// <summary>
    /// Specifies constants that define poker hand categories.
    /// </summary>
    public enum HandCategory : int
    {
        HighCard = 0,
        OnePair = 1,
        TwoPair = 2,
        ThreeOfAKind = 3,
        Straight = 4,
        Flush = 5,
        FullHouse = 6,
        FourOfAKind = 7,
        StraightFlush = 8
    }
}
