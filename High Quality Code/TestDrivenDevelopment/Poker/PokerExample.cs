using System;
using System.Collections.Generic;

namespace Poker
{
    class PokerExample
    {
        static void Main()
        {
            //ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
            //Console.WriteLine(card);

            //IHand hand = new Hand(new List<ICard>() { 
            //    new Card(CardFace.Ace, CardSuit.Clubs),
            //    new Card(CardFace.Ace, CardSuit.Diamonds),
            //    new Card(CardFace.King, CardSuit.Hearts),
            //    new Card(CardFace.King, CardSuit.Spades),
            //    new Card(CardFace.Seven, CardSuit.Diamonds),
            //});
            //Console.WriteLine(hand);

            IHand firstHand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            });

            IHand secondHand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            });

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Console.WriteLine(handsChecker.CompareHands(firstHand, secondHand) == 1);

         //   Console.WriteLine(checker.IsOnePair(hand));
          //  Console.WriteLine(checker.IsTwoPair(hand));
        }
    }
}
