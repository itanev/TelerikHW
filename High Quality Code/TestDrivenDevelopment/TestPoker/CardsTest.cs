using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace TestPoker
{
    [TestClass]
    public class CardsTest
    {
        [TestMethod]
        public void ToStringForOneCardTest()
        {
            Card twoOfHearts = new Card(CardFace.Two, CardSuit.Hearts);

            Assert.IsTrue(twoOfHearts.ToString() == "2♥");
        }

        [TestMethod]
        public void ToStringForSetOfCardsTest()
        {
            Card twoOfHearts = new Card(CardFace.Two, CardSuit.Hearts);
            Card aceOfDiamonds = new Card(CardFace.Ace, CardSuit.Diamonds);
            Card aceOfSpades = new Card(CardFace.Ace, CardSuit.Spades);
            Card kingOfClubs = new Card(CardFace.King, CardSuit.Clubs);
            Card tenOfHearts = new Card(CardFace.Ten, CardSuit.Hearts);

            StringBuilder hand = new StringBuilder();
            hand.Append(twoOfHearts.ToString());
            hand.Append(aceOfDiamonds.ToString());
            hand.Append(aceOfSpades.ToString());
            hand.Append(kingOfClubs.ToString());
            hand.Append(tenOfHearts.ToString());

            Assert.IsTrue(hand.ToString() == "2♥A♦A♠K♣10♥");
        }

        [TestMethod]
        public void ToStringForEntireHandTest()
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

            Hand hand = new Hand(cardsInHand);

            Assert.IsTrue(hand.ToString() == "2♥A♦A♠K♣10♥");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToStringForNullHandTest()
        {
            Hand hand = new Hand(null);
        }
    }
}
