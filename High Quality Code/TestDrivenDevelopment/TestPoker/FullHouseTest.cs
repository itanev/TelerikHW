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
    public class FullHouseTest
    {
        [TestMethod]
        public void IsFullHouseTest()
        {
            Card aceClubs = new Card(CardFace.Ace, CardSuit.Clubs);
            Card aceHearts = new Card(CardFace.Ace, CardSuit.Hearts);
            Card jackHearts = new Card(CardFace.Jack, CardSuit.Hearts);
            Card jackClubs = new Card(CardFace.Jack, CardSuit.Clubs);
            Card aceDiamonds = new Card(CardFace.Ace, CardSuit.Diamonds);

            List<ICard> cardsInHand = new List<ICard>();

            cardsInHand.Add(aceDiamonds);
            cardsInHand.Add(aceClubs);
            cardsInHand.Add(jackClubs);
            cardsInHand.Add(aceHearts);
            cardsInHand.Add(jackHearts);

            IHand hand = new Hand(cardsInHand);

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsFullHouse(hand));
        }

        [TestMethod]
        public void IsNotFullHouseTest()
        {
            Card twoOfHearts = new Card(CardFace.Two, CardSuit.Hearts);
            Card aceOfSpades = new Card(CardFace.Ace, CardSuit.Spades);
            Card aceOfHearts = new Card(CardFace.Ace, CardSuit.Hearts);
            Card aceOfClubs = new Card(CardFace.Ace, CardSuit.Clubs);
            Card tenOfHearts = new Card(CardFace.Ten, CardSuit.Hearts);

            List<ICard> cardsInHand = new List<ICard>();

            cardsInHand.Add(twoOfHearts);
            cardsInHand.Add(aceOfSpades);
            cardsInHand.Add(aceOfHearts);
            cardsInHand.Add(aceOfClubs);
            cardsInHand.Add(tenOfHearts);

            IHand hand = new Hand(cardsInHand);

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsFullHouse(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsFullHouseNullTest()
        {
            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsFullHouse(null));
        }
    }
}
