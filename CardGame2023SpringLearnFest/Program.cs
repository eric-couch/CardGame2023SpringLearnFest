using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Linq;
using System.Collections.Generic;


namespace CardGame2023SpringLearnFest
{
    enum Hands
    {
        HighCard,
        Pair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Five Card Draw Game.
            // Using the Card class that we created, let's create
            // a program that deals a player 5 cards.  The user then
            // can discard up to three cards and get replacement cards
            // to attempt to make the best hand.
            
            Deck FiveCardDrawDeck = new Deck();
            Player ThisPlayer = new Player();

            Console.Write("Please enter your name: ");
            ThisPlayer.Name = Console.ReadLine();
            ThisPlayer.Hand.Cards = FiveCardDrawDeck.DealCards(5);

            ThisPlayer.Hand.ShowHand();


            // check for various poker hands
            string playerHand = TestHand(ThisPlayer.Hand);
            Console.WriteLine($"The player has a {playerHand}");






            bool quitGame = false;
            do
            {
                Console.Write("How many cards would you like to replace (Q to quit game)?");
                string replaceCard = Console.ReadLine();

                if (replaceCard == "Q")
                {
                    quitGame = true;
                    break;
                }

                if (Int32.TryParse(replaceCard, out int replaceCardNum))
                {
                    if (replaceCardNum < 0 || replaceCardNum > 3)
                    {
                        Console.WriteLine("Not Allowed.");
                        continue;
                    } else
                    {
                        ReplaceCards(replaceCardNum, ThisPlayer.Hand.Cards, FiveCardDrawDeck);
                    }
                } else
                {
                    Console.WriteLine("Invalid Input");
                    continue;
                }
                quitGame= true;
            } while (!quitGame);

            Console.Clear();
            ThisPlayer.Hand.ShowHand();
            playerHand = TestHand(ThisPlayer.Hand);
            Console.WriteLine($"The player has a {playerHand}");

        }

        public static string TestHand(Deck playerHand)
        {
            string PlayerHand = "high card";
            bool? isFlushInHand = playerHand.IsFlush();
            bool? isStraightInHand = playerHand.IsStraight();
            bool? isFourOfAKind = playerHand.HasFourOfAKind();
            bool? isThreeOfAKind = playerHand.HasThreeOfAKind();
            bool? isPair = playerHand.HasPairs();

            if (isFlushInHand is not null && isStraightInHand is not null && (bool)isFlushInHand && (bool)isStraightInHand)
            {
                PlayerHand = "Straight-Flush";
            }
            else if (isFourOfAKind is not null && (bool)isFourOfAKind)
            {
                PlayerHand = "Four of a kind";
            }
            else if (isThreeOfAKind is not null && isPair is not null && (bool)isThreeOfAKind && (bool)isPair)
            {
                PlayerHand = "Fullhouse";
            }
            else if (isFlushInHand is not null && (bool)isFlushInHand)
            {
                PlayerHand = "Flush";
            }
            else if (isThreeOfAKind is not null && (bool)isThreeOfAKind)
            {
                PlayerHand = "Three of a Kind";
            }
            else if (isPair is not null && (bool)isPair)
            {
                PlayerHand = "Pair";
            }
            return PlayerHand;
        }
        public static void ReplaceCards(int numOfCardsToReplace, List<Card> CardsInHand, Deck DeckToDealFrom)
        {
            for (int replaceCardCounter = 0; replaceCardCounter < numOfCardsToReplace; replaceCardCounter++ )
            {
                Console.WriteLine("Which card to replace? (1-5)");
                string replacement = Console.ReadLine();
                if (Int32.TryParse(replacement, out int replacementNum))
                {
                    CardsInHand[replacementNum - 1] = DeckToDealFrom.DealCards(1).FirstOrDefault()!;
                }
            }
            return;
        }
    }
}