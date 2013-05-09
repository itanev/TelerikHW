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
    public class CompareHandsTest
    {
        [TestMethod]
        public void FirstHandStrongerTest()
        {
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

            Assert.IsTrue(handsChecker.CompareHands(firstHand, secondHand) == 1);
        }

        [TestMethod]
        public void SecondHandStrongerTest()
        {
            IHand firstHand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs)
            });

            IHand secondHand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds)
            });

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.CompareHands(firstHand, secondHand) == -1);
        }

        [TestMethod]
        public void EqaulHandsTest()
        {
            IHand firstHand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Diamonds)
            });

            IHand secondHand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds)
            });

            PokerHandsChecker handsChecker = new PokerHandsChecker();

            Assert.IsTrue(handsChecker.CompareHands(firstHand, secondHand) == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullTest()
        {
            PokerHandsChecker handsChecker = new PokerHandsChecker();

            handsChecker.CompareHands(null, null);
        }
    }
}
