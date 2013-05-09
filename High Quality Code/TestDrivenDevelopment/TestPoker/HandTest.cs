using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace TestPoker
{
    [TestClass]
    public class HandTest
    {
        [TestMethod]
        public void IsValidHandTest()
        {
            Card twoOfHearts = new Card(CardFace.Two, CardSuit.Hearts);
            Card aceOfDiamonds = new Card(CardFace.Ace, CardSuit.Diamonds);
            Card aceOfSpades = new Card(CardFace.Ace, CardSuit.Spades);
            Card kingOfClubs = new Card(CardFace.King, CardSuit.Clubs);
            Card tenOfHearts = new Card(CardFace.Ten, CardSuit.Hearts);

            List<ICard> cardsInHand = new List<ICard>();

            cardsInHand.Add(twoOfHearts);
            cardsInHand.Add(aceOfDiamonds);
            cardsInHand.Add(aceOfSpades);
            cardsInHand.Add(kingOfClubs);
            cardsInHand.Add(tenOfHearts);

            IHand hand = new Hand(cardsInHand);

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void IsInvalidHandTest()
        {
            Card twoOfHearts = new Card(CardFace.Two, CardSuit.Hearts);
            Card aceOfDiamonds = new Card(CardFace.Ace, CardSuit.Spades);
            Card aceOfSpades = new Card(CardFace.Ace, CardSuit.Spades);
            Card kingOfClubs = new Card(CardFace.King, CardSuit.Clubs);
            Card tenOfHearts = new Card(CardFace.Ten, CardSuit.Hearts);

            List<ICard> cardsInHand = new List<ICard>();

            cardsInHand.Add(twoOfHearts);
            cardsInHand.Add(aceOfDiamonds);
            cardsInHand.Add(aceOfSpades);
            cardsInHand.Add(kingOfClubs);
            cardsInHand.Add(tenOfHearts);

            IHand hand = new Hand(cardsInHand);

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsValidHand(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FewerCardsTest()
        {
            Card twoOfHearts = new Card(CardFace.Two, CardSuit.Hearts);
            Card aceOfDiamonds = new Card(CardFace.Ace, CardSuit.Spades);
            Card kingOfClubs = new Card(CardFace.King, CardSuit.Clubs);
            Card tenOfHearts = new Card(CardFace.Ten, CardSuit.Hearts);

            List<ICard> cardsInHand = new List<ICard>();

            cardsInHand.Add(twoOfHearts);
            cardsInHand.Add(aceOfDiamonds);
            cardsInHand.Add(kingOfClubs);
            cardsInHand.Add(tenOfHearts);

            IHand hand = new Hand(cardsInHand);

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsValidHand(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MoreCardsTest()
        {
            Card twoOfHearts = new Card(CardFace.Two, CardSuit.Hearts);
            Card aceOfDiamonds = new Card(CardFace.Ace, CardSuit.Spades);
            Card kingOfClubs = new Card(CardFace.King, CardSuit.Clubs);
            Card tenOfHearts = new Card(CardFace.Ten, CardSuit.Hearts);
            Card queenOfHearts = new Card(CardFace.Queen, CardSuit.Hearts);
            Card fourOfHearts = new Card(CardFace.Four, CardSuit.Hearts);

            List<ICard> cardsInHand = new List<ICard>();

            cardsInHand.Add(twoOfHearts);
            cardsInHand.Add(aceOfDiamonds);
            cardsInHand.Add(kingOfClubs);
            cardsInHand.Add(tenOfHearts);
            cardsInHand.Add(queenOfHearts);
            cardsInHand.Add(fourOfHearts);

            IHand hand = new Hand(cardsInHand);

            PokerHandsChecker handsChecker = new PokerHandsChecker();
            handsChecker.IsValidHand(hand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsValidNullTest()
        {
            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsValidHand(null));
        }
    }
}
