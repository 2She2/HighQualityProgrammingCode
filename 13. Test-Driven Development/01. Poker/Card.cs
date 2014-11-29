namespace Poker
{
    using Poker.Enums;

    /// <summary>
    /// Represents a poker card.
    /// </summary>
    public class Card : ICard
    {
        /// <summary>
        /// String representations of the card ranks.
        /// </summary>
        private static readonly string[] Ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        /// <summary>
        /// Char representations of the card suits.
        /// </summary>
        private static readonly char[] Suits = { '♣', '♦', '♥', '♠' };

        public Card(CardRank rank, CardSuit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public CardRank Rank { get; private set; }

        public CardSuit Suit { get; private set; }

        /// Return the rank and suit of a card represented as a string.
        public override string ToString()
        {
            return Ranks[(int)this.Rank - 2] + Suits[(int)this.Suit];
        }

        public int CompareTo(ICard other)
        {
            return this.Rank.CompareTo(other.Rank);
        }

        public bool Equals(ICard other)
        {
            return this.Rank == other.Rank && this.Suit == other.Suit;
        }
    }
}
