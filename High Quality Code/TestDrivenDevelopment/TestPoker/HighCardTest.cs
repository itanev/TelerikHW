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
    public class HighCardTest
    {
        [TestMethod]
        public void IsHighCardTest()
        {
            Card aceClubs = new Card(CardFace.Ace, CardSuit.Clubs);
            Card kingClubs = new Card(CardFace.King, CardSuit.Clubs);
            Card twoHearts = new Card(CardFace.Two, CardSuit.Hearts);
            Card jackClubs = new Card(CardFace.Jack, CardSuit.Clubs);
            Card tenOfClubs = new Card(CardFace.Ten, CardSuit.Clubs);

            List<ICard> cardsInHand = new List<ICard>();

            cardsInHand.Add(tenOfClubs);
            cardsInHand.Add(aceClubs);
            cardsInHand.Add(jackClubs);
            cardsInHand.Add(kingClubs);
            cardsInHand.Add(twoHearts);

            IHand hand = new Hand(cardsInHand);

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsHighCard(hand));
        }

        [TestMethod]
        public void IsNotHighCardTest()
        {
            Card twoOfHearts = new Card(CardFace.Two, CardSuit.Hearts);
            Card aceOfSpades = new Card(CardFace.Ace, CardSuit.Spades);
            Card fourOfHearts = new Card(CardFace.Four, CardSuit.Hearts);
            Card aceOfClubs = new Card(CardFace.Ace, CardSuit.Clubs);
            Card tenOfHearts = new Card(CardFace.Ten, CardSuit.Hearts);

            List<ICard> cardsInHand = new List<ICard>();

            cardsInHand.Add(twoOfHearts);
            cardsInHand.Add(aceOfSpades);
            cardsInHand.Add(fourOfHearts);
            cardsInHand.Add(aceOfClubs);
            cardsInHand.Add(tenOfHearts);

            IHand hand = new Hand(cardsInHand);

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsHighCard(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsHighCardNullTest()
        {
            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsHighCard(null));
        }
    }
}
