using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame2023SpringLearnFest
{
    internal class Deck
    {
        public List<Card> Cards = new List<Card>();
        
        public Deck()
        {
            for (int rank = 2; rank <= 14; rank++)
            {
                for (int suit=0;suit<4;suit++)
                {
                    string convertedRank = String.Empty;
                    string convertedSuit = String.Empty;

                    switch (rank)
                    {
                        case 11:
                            convertedRank = "J";
                            break;
                        case 12:
                            convertedRank = "Q";
                            break;
                        case 13:
                            convertedRank = "K";
                            break;
                        case 14:
                            convertedRank = "A";
                            break;
                        default:
                            convertedRank = rank.ToString();
                            break;
                    }
                    switch (suit)
                    {
                        case 0:
                            convertedSuit = "♠";
                            break;
                        case 1:
                            convertedSuit = "♣";
                            break;
                        case 2:
                            convertedSuit = "♥";
                            break;
                        default:
                            convertedSuit = "♦";
                            break;
                    }
                    Card currentCard = new Card(convertedSuit, convertedRank, rank);
                    Cards.Add(currentCard);
                }
            }
        }
    }
}
