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
    public class StraightFlushTest
    {
        [TestMethod]
        public void IsStraightFlushTest()
        {
            Card aceClubs = new Card(CardFace.Ace, CardSuit.Clubs);
            Card queenClubs = new Card(CardFace.Queen, CardSuit.Clubs);
            Card kingClubs = new Card(CardFace.King, CardSuit.Clubs);
            Card jackClubs = new Card(CardFace.Jack, CardSuit.Clubs);
            Card tenOfClubs = new Card(CardFace.Ten, CardSuit.Clubs);

            List<ICard> cardsInHand = new List<ICard>();

            cardsInHand.Add(tenOfClubs);
            cardsInHand.Add(aceClubs);
            cardsInHand.Add(jackClubs);
            cardsInHand.Add(queenClubs);
            cardsInHand.Add(kingClubs);

            IHand hand = new Hand(cardsInHand);

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void IsNotStraightFlushTest()
        {
            Card twoOfHearts = new Card(CardFace.Two, CardSuit.Hearts);
            Card aceOfSpades = new Card(CardFace.Ace, CardSuit.Spades);
            Card threeOfHearts = new Card(CardFace.Three, CardSuit.Hearts);
            Card kingOfHearts = new Card(CardFace.King, CardSuit.Hearts);
            Card tenOfHearts = new Card(CardFace.Ten, CardSuit.Hearts);

            List<ICard> cardsInHand = new List<ICard>();

            cardsInHand.Add(twoOfHearts);
            cardsInHand.Add(aceOfSpades);
            cardsInHand.Add(threeOfHearts);
            cardsInHand.Add(kingOfHearts);
            cardsInHand.Add(tenOfHearts);

            IHand hand = new Hand(cardsInHand);

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsStraightFlush(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsStraightFlushNullTest()
        {
            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsStraightFlush(null));
        }
    }
}
