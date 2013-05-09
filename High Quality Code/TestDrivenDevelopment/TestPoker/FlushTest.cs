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
    public class FlushTest
    {
        [TestMethod]
        public void IsFlushTest()
        {
            Card twoOfHearts = new Card(CardFace.Two, CardSuit.Hearts);
            Card aceOfHearts = new Card(CardFace.Ace, CardSuit.Hearts);
            Card threeOfHearts = new Card(CardFace.Three, CardSuit.Hearts);
            Card kingOfHearts = new Card(CardFace.King, CardSuit.Hearts);
            Card tenOfHearts = new Card(CardFace.Ten, CardSuit.Hearts);

            List<ICard> cardsInHand = new List<ICard>();

            cardsInHand.Add(twoOfHearts);
            cardsInHand.Add(aceOfHearts);
            cardsInHand.Add(aceOfHearts);
            cardsInHand.Add(kingOfHearts);
            cardsInHand.Add(tenOfHearts);

            IHand hand = new Hand(cardsInHand);

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsFlush(hand));
        }

        [TestMethod]
        public void IsNotFlushTest()
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

            Assert.IsFalse(handsChecker.IsFlush(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsFlushNullTest()
        {
            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsFlush(null));
        }
    }
}
