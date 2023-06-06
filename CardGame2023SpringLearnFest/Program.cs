﻿using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Linq;
using System.Collections.Generic;


namespace CardGame2023SpringLearnFest
{
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
            //ThisPlayer.Hand = FiveCardDrawDeck.DealCards(5);
            ThisPlayer.Hand.Cards = FiveCardDrawDeck.DealCards(5);

            ShowHand(ThisPlayer.Hand.Cards);

            Console.WriteLine($"The player {(ThisPlayer.Hand.CheckForPairs() ? "has" : "does not have")} a pair.");

            //bool aceInHand = ThisPlayer.Hand.Exists(d => d.Rank == "A");
            //int numOfAces = (from c in ThisPlayer.Hand
            //                 where c.Rank == "A"
            //                 select c).Count();
            //Console.WriteLine($"The player {(numOfAces > 0 ? "has" : "does not have")} an Ace.");




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
            ShowHand(ThisPlayer.Hand.Cards);

        }



        public static void ShowHand(List<Card> cardsToShow)
        {
            int cardNum = 1;
            string cardPos = string.Empty;
            foreach (Card card in cardsToShow)
            {
                Console.Write($"{card.ToString()}\t");
                cardPos += $"({cardNum++})\t";
            }
            Console.WriteLine($"\n{cardPos}\n");
            return;
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