namespace DeckOfCardsBlackJack.Entities
{
    public abstract class Card
    {
        protected Card(int faceValue, SuitEnum suit)
        {
            FaceValue = faceValue;
            Suit = suit;
        }

        private bool Available { get; set; }

        // Number or Face that's on card - a number 2 through 10, or 11 for Jack, 12 for Queen, 13 for King, or 1 for Ace
        public int FaceValue { get; private set; }
        public SuitEnum Suit { get; private set; }

        /// <summary>
        /// Method to be defined based on the game being played
        /// </summary>
        /// <returns></returns>
        public abstract int GetValue();

        // Checks if the card is availabe to be given out to someone
        public bool IsAvailable() => Available;

        public void MarkUnavailable()
        {
            Available = false;
        }

        public void MarkAvailable()
        {
            Available = true;
        }
    }
}
