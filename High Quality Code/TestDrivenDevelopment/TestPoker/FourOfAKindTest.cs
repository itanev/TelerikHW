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
    public class FourOfAKindTest
    {
        [TestMethod]
        public void AreFourOfAKindTest()
        {
            Card aceClubs = new Card(CardFace.Ace, CardSuit.Clubs);
            Card aceDiamonds = new Card(CardFace.Ace, CardSuit.Diamonds);
            Card aceSpades = new Card(CardFace.Ace, CardSuit.Spades);
            Card aceHearts = new Card(CardFace.Ace, CardSuit.Hearts);
            Card tenOfHearts = new Card(CardFace.Ten, CardSuit.Hearts);

            List<ICard> cardsInHand = new List<ICard>();

            cardsInHand.Add(aceClubs);
            cardsInHand.Add(aceDiamonds);
            cardsInHand.Add(aceSpades);
            cardsInHand.Add(aceHearts);
            cardsInHand.Add(tenOfHearts);

            IHand hand = new Hand(cardsInHand);

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void AreNotFourOfAKindTest()
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

            Assert.IsFalse(handsChecker.IsFourOfAKind(hand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AreFourOfAKindNullTest()
        {
            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsFalse(handsChecker.IsFourOfAKind(null));
        }
    }
}
