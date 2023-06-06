using CardGame2023SpringLearnFest;

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
            bool pairInHand = myDeck.CheckForPairs();
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
            bool pairInHand = myDeck.CheckForPairs();
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
            bool threeOfAKindInHand = myDeck.HasThreeOfAKind();
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
            bool threeOfAKindInHand = myDeck.HasThreeOfAKind();
            Assert.IsFalse(threeOfAKindInHand);
        }
    }
}