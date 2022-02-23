namespace DeckOfCardsBlackJack.Entities
{
    public abstract class Deck<T> where T : Card
    {
        public List<T> Cards { get; protected set; }

        private int dealtIndex = 0;

        public Deck(List<T> cards)
        {
            Cards = cards;
        }

        public Deck()
        {
            Cards = new List<T>();
        }

        public abstract void Shuffle();

        public int GetRemainingCards()
        {
            return Cards.Count - dealtIndex;
        }

        public List<T> DealHand(int numberOfCards)
        {
            List<T> cards = new(numberOfCards);
            int finalDealtIndex = dealtIndex + numberOfCards - 1;
            for (int i = dealtIndex; i <= finalDealtIndex; i++)
            {
                cards.Add(Cards[i]);
            }

            return cards;
        }

        public T DealCard()
        {
            T card = Cards[dealtIndex];
            dealtIndex++;
            return card;
        }
    }
}
