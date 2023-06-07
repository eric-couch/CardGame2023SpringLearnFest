using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame2023SpringLearnFest
{
    public class Deck
    {
        //public List<Card> Cards = new List<Card>();
        public List<Card> Cards { get; set; } = new List<Card>();

        public bool? CheckForPairs()
        {
            try
            {
                var cardGroups = from c in Cards
                                 group c by new { c.Rank } into g
                                 select new { rank = g.Key, count = g.Count() };
                return cardGroups.Where(c => c.count == 2).Any();
            } catch (Exception Ex)
            {
                Console.WriteLine($"An error occured.  Error message: {Ex.Message}");
                return null;
            }
        }

        public bool? HasThreeOfAKind()
        {
            try
            {
                bool? result = Cards.GroupBy(card => card.Val).Any(group => group.Count() == 3);
                return result;
            } catch (Exception Ex)
            {
                Console.WriteLine($"An error occured.  Error message: {Ex.Message}");
                return null;
            }
            
        }

        // build a method to test for four of a kind
        public bool? HasFourOfAKind()
        {
            try
            {
                bool? result = Cards.GroupBy(card => card.Val).Any(group => group.Count() == 4);
                return result;
            } catch (Exception Ex)
            {
                Console.WriteLine($"An error occured.  Error message: {Ex.Message}");
                return null;
            }
        }

        // build a method to find the values of the pairs
        public List<string>? ReturnPairRanks()
        {
            try
            {
                var cardGroups = from c in Cards
                                 group c by new { c.Rank } into g
                                 select new { rank = g.Key, count = g.Count() };

                // using Linq how do we determine if we have a group where count = 2?
                var result = cardGroups.Where(c => c.count == 2).Select(c => c.rank).ToList();
                return result.Select(result => result.Rank.ToString()).Order().ToList();
            } catch (Exception Ex)
            {
                Console.WriteLine($"An error occured.  Error message: {Ex.Message}");
                return null;
            }
        }
        // build a method to find the values of the three of a kind
        // build a method to test for full house (one pair and three of a kind)
        // build a method to test for a straight (five cards in a row.  five cards with ascending values)
        // e.g. 4, 5, 6, 7, 8 or 10, J, Q, K, A or A, 2, 3, 4, 5
        public bool? IsStraight()
        {
            try
            {
                if (Cards.Count != 5)
                {
                    throw new ArgumentException("Hand must contain 5 cards.");
                }

                var sortedHand = Cards.OrderBy(card => card.Val).Select(c => c.Val).ToList();
                for (int i = 0; i < sortedHand.Count - 1; i++)
                {
                    if (sortedHand[i + 1] - sortedHand[i] != 1)
                    {
                        return false;
                    }
                }
                return true;
            } catch (Exception Ex)
            {
                Console.WriteLine($"An error occured.  Error message: {Ex.Message}");
                return null;
            }
        }

        public List<Card> DealCards(int numOfCards)
        {
            List<Card> cardsDealt = new List<Card>();
            Random rnd = new Random();
            for (int cardsToDeal = 0; cardsToDeal < numOfCards; cardsToDeal++)
            {
                int cardToDeal = rnd.Next(Cards.Count);
                Card dealtCard = Cards[cardToDeal];
                cardsDealt.Add(dealtCard);
                Cards.RemoveAt(cardToDeal);
            }
            return cardsDealt;
        }

        public Deck()
        {
            ResetDeck();
        }
        
        public void ResetDeck()
        {
            Cards.Clear();
            List<string> suits = new List<string>() { "♠", "♣", "♥", "♦" };
            List<string> ranks = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            List<int> values = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    Card card = new Card(rank, suit, values[ranks.IndexOf(rank)]);
                    Cards.Add(card);
                }
            }
        }
    }
}
