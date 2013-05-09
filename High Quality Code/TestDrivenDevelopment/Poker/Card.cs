using System;
using System.Text;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        private string GetCardFace()
        {
            string faceAsString = string.Empty;

            if (this.Face <= CardFace.Ten)
            {
                faceAsString = ((int)this.Face).ToString();
            }
            else
            {
                string cardFaceName = this.Face.ToString();
                // Gets the first letter of the name.
                faceAsString = cardFaceName[0].ToString();
            }

            return faceAsString;
        }

        private string GetCartSuit()
        {
            string suitAsString = string.Empty;

            switch(this.Suit)
            {
                case CardSuit.Clubs:
                    suitAsString = "♣";
                    break;
                case CardSuit.Diamonds:
                    suitAsString = "♦";
                    break;
                case CardSuit.Hearts:
                    suitAsString = "♥";
                    break;
                case CardSuit.Spades:
                    suitAsString = "♠";
                    break;
            }

            return suitAsString;
        }

        public override string ToString()
        {
            StringBuilder cardAsString = new StringBuilder();

            cardAsString.AppendFormat("{0}{1}", GetCardFace(), GetCartSuit());

            return cardAsString.ToString();
        }
    }
}
