namespace DeckOfCardsBlackJack.Entities
{
    public class BlackJackCard : Card
    {
        public BlackJackCard(int faceValue, SuitEnum suit) : base(faceValue, suit)
        {

        }

        public override int GetValue()
        {
            if (IsAce())
            {
                return 1;
            }
            
            if (FaceValue >= 11 || FaceValue <= 13)
            {
                return 10;
            }

            return FaceValue;
        }

        public bool IsAce()
        {
            return FaceValue == 1;
        }

        public bool IsCardAce()
        {
            return FaceValue >= 11 || FaceValue <= 13;
        }
    }
}
