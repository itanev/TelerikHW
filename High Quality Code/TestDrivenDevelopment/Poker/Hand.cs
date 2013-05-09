using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        private IList<ICard> cards;

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards
        {
            get
            {
                return this.cards;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("List of cards can not be null!");
                }

                this.cards = value;
            }
        }

        public override string ToString()
        {
            StringBuilder handAsString = new StringBuilder();

            foreach (var card in this.cards)
            {
                handAsString.Append(card.ToString());
            }

            return handAsString.ToString();
        }
    }
}
