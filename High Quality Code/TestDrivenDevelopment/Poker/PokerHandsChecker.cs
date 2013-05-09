using System;
using System.Collections.Generic;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            ValidateHand(hand);

            bool isValid = true;
            List<ICard> currCardsInHand = new List<ICard>();

            foreach (var card in hand.Cards)
            {
                if (!ContainsCard(currCardsInHand, card) || currCardsInHand.Count == 0)
                {
                    currCardsInHand.Add(card);
                }
                else
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        public bool IsStraightFlush(IHand hand)
        {
            ValidateHand(hand);

            SortHand(hand);

            var cardsInHand = hand.Cards;
            var card = cardsInHand[0];
            var suit = card.Suit;

            for (int i = 1; i < hand.Cards.Count; i++)
            {
                bool haveDiferentSuits = suit != cardsInHand[i].Suit;
                bool areNotInRow = cardsInHand[i].Face != cardsInHand[i - 1].Face + 1;
                if (haveDiferentSuits || areNotInRow)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            ValidateHand(hand);

            return AreSeveralOfAKind(hand, 4);
        }

        public bool IsFullHouse(IHand hand)
        {
            ValidateHand(hand);

            SortHand(hand);

            var cardsInHand = hand.Cards;

            bool firstAndSecondEqual = cardsInHand[0].Face == cardsInHand[1].Face;
            bool lastAndLastButOneEqual = cardsInHand[3].Face == cardsInHand[4].Face;
            bool middleEqualToFirst = cardsInHand[2].Face == cardsInHand[0].Face;
            bool middleEqualToLast = cardsInHand[2].Face == cardsInHand[4].Face;

            if (firstAndSecondEqual && lastAndLastButOneEqual)
            {
                if (middleEqualToFirst || middleEqualToLast)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsFlush(IHand hand)
        {
            ValidateHand(hand);

            bool haveSameSuits = true;
            var suit = hand.Cards[0].Suit;

            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].Suit != suit)
                {
                    haveSameSuits = false;
                    break;
                }
            }

            return haveSameSuits;
        }

        public bool IsStraight(IHand hand)
        {
            ValidateHand(hand);

            SortHand(hand);

            var cardsInHand = hand.Cards;

            for (int i = 1; i < cardsInHand.Count; i++)
            {
                bool areNotInRow = cardsInHand[i].Face != cardsInHand[i - 1].Face + 1;
                if (areNotInRow)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            ValidateHand(hand);

            return AreSeveralOfAKind(hand, 3);
        }

        public bool IsTwoPair(IHand hand)
        {
            ValidateHand(hand);

            SortHand(hand);

            byte pairCouter = 0;

            var cardsInHand = hand.Cards;

            for (int i = 0; i < cardsInHand.Count - 1; i++)
            {
                if (cardsInHand[i].Face == cardsInHand[i + 1].Face)
                {
                    pairCouter++;
                }

                if (pairCouter == 2)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsOnePair(IHand hand)
        {
            ValidateHand(hand);

            return AreSeveralOfAKind(hand, 2);
        }

        public bool IsHighCard(IHand hand)
        {
            ValidateHand(hand);

            if (!IsOnePair(hand) &&
                !IsTwoPair(hand) &&
                !IsThreeOfAKind(hand) &&
                !IsFullHouse(hand) &&
                !IsStraight(hand) &&
                !IsStraightFlush(hand) &&
                !IsFourOfAKind(hand) &&
                !IsFlush(hand))
            {
                return true;
            }

            return false;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            ValidateHand(firstHand);
            ValidateHand(secondHand);

            byte firstHandWeight = GetHandWeight(firstHand);
            byte secondHandWeight = GetHandWeight(secondHand);

            if (firstHandWeight > secondHandWeight)
            {
                return 1;
            }
            else if (firstHandWeight < secondHandWeight)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private byte GetHandWeight(IHand hand)
        {
            byte handWeight = 0;

            if (IsStraightFlush(hand))
            {
                handWeight = 9;
            }
            else if (IsFourOfAKind(hand))
            {
                handWeight = 8;
            }
            else if (IsFullHouse(hand))
            {
                handWeight = 7;
            }
            else if (IsFlush(hand))
            {
                handWeight = 6;
            }
            else if (IsStraight(hand))
            {
                handWeight = 5;
            }
            else if (IsThreeOfAKind(hand))
            {
                handWeight = 4;
            }
            else if (IsTwoPair(hand))
            {
                handWeight = 3;
            }
            else if (IsOnePair(hand))
            {
                handWeight = 2;
            }

            return handWeight;
        }

        private void ValidateHand(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException("Hand can not be null!");
            }
            else if (hand.Cards.Count != 5)
            {
                throw new ArgumentException("Cards in hand must be exactly five!");
            }
        }

        private bool AreSeveralOfAKind(IHand hand, byte numCardsOfAKind)
        {
            byte counter = 1;
            var cardsInHand = hand.Cards;

            for (byte currCardIndex = 0; currCardIndex < cardsInHand.Count; currCardIndex++)
            {
                for (byte cardIndex = 0; cardIndex < cardsInHand.Count; cardIndex++)
                {
                    if (cardIndex == currCardIndex)
                    {
                        continue;
                    }

                    if (cardsInHand[currCardIndex].Face == cardsInHand[cardIndex].Face)
                    {
                        counter++;
                    }

                    if (counter == numCardsOfAKind)
                    {
                        return true;
                    }
                }

                counter = 1;
            }

            return false;
        }

        private bool ContainsCard(List<ICard> listOfCards, ICard currCart)
        {
            foreach (var card in listOfCards)
            {
                bool haveSameFaces = card.Face == currCart.Face;
                bool haveSameSuits = card.Suit == currCart.Suit;

                if (haveSameFaces && haveSameSuits)
                {
                    return true;
                }
            }

            return false;
        }

        private void SortHand(IHand hand)
        {
            (hand.Cards as List<ICard>).Sort((firstCard, secondCard) => firstCard.Face.CompareTo(secondCard.Face));
        }
    }
}
