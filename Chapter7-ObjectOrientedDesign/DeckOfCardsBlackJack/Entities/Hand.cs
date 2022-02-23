namespace DeckOfCardsBlackJack.Entities
{
    public class Hand<T> where T : Card
    {
        public List<T> Cards { get; set; }

        public Hand()
        {
            Cards = new List<T>();
        }

        public Hand(int maxNumberOfCardsInHand)
        {
            Cards = new List<T>(maxNumberOfCardsInHand);
        }

        public int GetScore()
        {
            int score = 0;
            foreach (var card in Cards)
            {
                score += card.GetValue();
            }

            return score;
        }

        public void addCard(T card)
        {
            Cards.Add(card);    
        }
    }
}
