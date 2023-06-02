using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame2023SpringLearnFest
{
    internal class Card
    {
        
        public string Suit { get; set; }
        public string Rank { get; set; }
        public int Val { get; set; }

        /// <summary>
        /// this is a playing card class
        /// the suits are Spades, Hearts, Clubs, Diamonds
        /// the ranks are Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
        /// </summary>
        /// <param name="suit">Spades, Hearts, Clubs, Diamonds</param>
        /// <param name="rank">Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King</param>
        public Card(string suit, string rank, int val)
        {
            Suit = suit;
            Rank = rank;
            Val = val;
        }

        public override string? ToString()
        {
            return $"{Rank}{Suit}";
        }
    }
}
