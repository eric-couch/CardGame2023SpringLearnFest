using CardGame2023SpringLearnFest;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CardGame2023SpringLearnFestTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestHandForPair()
        {
            Deck myDeck = new Deck();
            myDeck.Cards = new List<Card>()
            {
                new Card("10", "♦", 10),
                new Card("5", "♠", 5),
                new Card("4", "♥", 4),
                new Card("10", "♥", 10),
                new Card("A", "♠", 14)
            };
            bool? pairInHand = myDeck.CheckForPairs();
            Assert.IsTrue(pairInHand);
        }

        [Test]
        public void TestHandForNoPair()
        {
            Deck myDeck = new Deck();
            myDeck.Cards = new List<Card>()
            {
                new Card("10", "♦", 10),
                new Card("5", "♠", 5),
                new Card("4", "♥", 4),
                new Card("9", "♥", 9),
                new Card("A", "♠", 14)
            };
            bool? pairInHand = myDeck.CheckForPairs();
            Assert.IsFalse(pairInHand);
        }

        [Test]
        public void TestHandForThreeOfAKind()
        {
            Deck myDeck = new Deck();
            myDeck.Cards = new List<Card>()
            {
                new Card("10", "♦", 10),
                new Card("10", "♠", 10),
                new Card("4", "♥", 4),
                new Card("10", "♥", 10),
                new Card("A", "♠", 14)
            };
            bool? threeOfAKindInHand = myDeck.HasThreeOfAKind();
            Assert.IsTrue(threeOfAKindInHand);
        }

        [Test]
        public void TestHandForNoThreeOfAKind()
        {
            Deck myDeck = new Deck();
            myDeck.Cards = new List<Card>()
            {
                new Card("10", "♦", 10),
                new Card("10", "♠", 10),
                new Card("4", "♥", 4),
                new Card("9", "♥", 9),
                new Card("A", "♠", 14)
            };
            bool? threeOfAKindInHand = myDeck.HasThreeOfAKind();
            Assert.IsFalse(threeOfAKindInHand);
        }

        [Test]
        public void TestHandForFourOfAKind()
        {
            Deck myDeck = new Deck();
            myDeck.Cards = new List<Card>()
            {
                new Card("10", "♦", 10),
                new Card("10", "♠", 10),
                new Card("10", "♣", 10),
                new Card("10", "♥", 10),
                new Card("A", "♠", 14)
            };
            bool? fourOfAKindInHand = myDeck.HasFourOfAKind();
            Assert.IsTrue(fourOfAKindInHand);
        }

        [Test]
        public void TestHandForNoFourOfAKind()
        {
            Deck myDeck = new Deck();
            myDeck.Cards = new List<Card>()
            {
                new Card("10", "♦", 10),
                new Card("10", "♠", 10),
                new Card("4", "♥", 4),
                new Card("9", "♥", 9),
                new Card("A", "♠", 14)
            };
            bool? fourOfAKindInHand = myDeck.HasFourOfAKind();
            Assert.IsFalse(fourOfAKindInHand);
        }

        [Test]
        public void TestGetPairs()
        {
            Deck myDeck = new Deck();
            myDeck.Cards = new List<Card>()
            {
                new Card("10", "♦", 10),
                new Card("5", "♠", 5),
                new Card("4", "♥", 4),
                new Card("10", "♥", 10),
                new Card("A", "♠", 14)
            };
            List<string>? pairsInHand = myDeck.ReturnPairRanks();
            if (pairsInHand?.Any() == true) {
                Assert.AreEqual("10", pairsInHand.FirstOrDefault()!);
             } else
            {
                Assert.Fail();
            }
            
        }

        [Test]
        public void TestGetNoPairs()
        {
            Deck myDeck = new Deck();
            myDeck.Cards = new List<Card>()
            {
                new Card("10", "♦", 10),
                new Card("5", "♠", 5),
                new Card("4", "♥", 4),
                new Card("9", "♥", 9),
                new Card("A", "♠", 14)
            };
            List<string>? pairsInHand = myDeck.ReturnPairRanks();
            if (!pairsInHand?.Any() == true)
            {
                Assert.IsEmpty(pairsInHand);
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestGetTwoPairs()
        {
            Deck myDeck = new Deck();
            myDeck.Cards = new List<Card>()
            {
                new Card("10", "♦", 10),
                new Card("5", "♠", 5),
                new Card("5", "♥", 5),
                new Card("10", "♥", 10),
                new Card("A", "♠", 14)
            };
            List<string>? pairsInHand = myDeck.ReturnPairRanks();
            if (!pairsInHand?.Any() == true)
            {
                Assert.AreEqual(2, pairsInHand.Count);
                Assert.AreEqual("10", pairsInHand[0]);
                Assert.AreEqual("5", pairsInHand[1]);
            } else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestForStraight()
        {
            Deck myDeck = new Deck();
            myDeck.Cards = new List<Card>()
            {
                new Card("5", "♦", 5),
                new Card("6", "♠", 6),
                new Card("7", "♥", 7),
                new Card("8", "♥", 8),
                new Card("9", "♠", 9)
            };
            bool? isStraightInHand = myDeck.IsStraight();
            Assert.IsTrue(isStraightInHand);
        }

        [Test]
        public void TestForNotStraight()
        {
            Deck myDeck = new Deck();
            myDeck.Cards = new List<Card>()
            {
                new Card("5", "♦", 5),
                new Card("6", "♠", 6),
                new Card("3", "♥", 3),
                new Card("8", "♥", 8),
                new Card("9", "♠", 9)
            };
            Assert.IsFalse(myDeck.IsStraight());
        }
    }
}