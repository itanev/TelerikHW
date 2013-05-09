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
    public class StraightTest
    {
        [TestMethod]
        public void IsStraightTest()
        {
            Card aceClubs = new Card(CardFace.Ace, CardSuit.Clubs);
            Card queenClubs = new Card(CardFace.Queen, CardSuit.Clubs);
            Card kingHearts = new Card(CardFace.King, CardSuit.Hearts);
            Card jackClubs = new Card(CardFace.Jack, CardSuit.Clubs);
            Card tenOfClubs = new Card(CardFace.Ten, CardSuit.Clubs);

            List<ICard> cardsInHand = new List<ICard>();

            cardsInHand.Add(tenOfClubs);
            cardsInHand.Add(aceClubs);
            cardsInHand.Add(jackClubs);
            cardsInHand.Add(queenClubs);
            cardsInHand.Add(kingHearts);

            IHand hand = new Hand(cardsInHand);

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsStraight(hand));
        }

        [TestMethod]
        public void IsNotStraightTest()
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

            Assert.IsFalse(handsChecker.IsStraight(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsStraightNullTest()
        {
            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsStraight(null));
        }
    }
}
