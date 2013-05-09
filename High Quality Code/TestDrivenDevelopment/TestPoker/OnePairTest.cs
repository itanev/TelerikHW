using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPoker
{
    [TestClass]
    public class OnePairTest
    {
        [TestMethod]
        public void IsOnePairTest()
        {
            Card aceClubs = new Card(CardFace.Ace, CardSuit.Clubs);
            Card kingClubs = new Card(CardFace.King, CardSuit.Clubs);
            Card kingHearts = new Card(CardFace.King, CardSuit.Hearts);
            Card jackClubs = new Card(CardFace.Jack, CardSuit.Clubs);
            Card tenOfClubs = new Card(CardFace.Ten, CardSuit.Clubs);

            List<ICard> cardsInHand = new List<ICard>();

            cardsInHand.Add(tenOfClubs);
            cardsInHand.Add(aceClubs);
            cardsInHand.Add(jackClubs);
            cardsInHand.Add(kingClubs);
            cardsInHand.Add(kingHearts);

            IHand hand = new Hand(cardsInHand);

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsOnePair(hand));
        }

        [TestMethod]
        public void IsNotOnePairTest()
        {
            Card twoOfHearts = new Card(CardFace.Two, CardSuit.Hearts);
            Card aceOfSpades = new Card(CardFace.Ace, CardSuit.Spades);
            Card fourOfHearts = new Card(CardFace.Four, CardSuit.Hearts);
            Card fiveOfClubs = new Card(CardFace.Five, CardSuit.Clubs);
            Card tenOfHearts = new Card(CardFace.Ten, CardSuit.Hearts);

            List<ICard> cardsInHand = new List<ICard>();

            cardsInHand.Add(twoOfHearts);
            cardsInHand.Add(aceOfSpades);
            cardsInHand.Add(fourOfHearts);
            cardsInHand.Add(fiveOfClubs);
            cardsInHand.Add(tenOfHearts);

            IHand hand = new Hand(cardsInHand);

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsOnePair(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsOnePairNullTest()
        {
            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsOnePair(null));
        }
    }
}
