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

        public bool CheckForPairs()
        {
            var cardGroups = from c in Cards
                             group c by new { c.Rank } into g
                             select new { rank = g.Key, count = g.Count() };

            // using Linq how do we determine if we have a group where count = 2?
            return cardGroups.Where(c => c.count == 2).Any();
        }

        public bool HasThreeOfAKind()
        {
            return Cards.GroupBy(card => card.Val).Any(group => group.Count() == 3);
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
