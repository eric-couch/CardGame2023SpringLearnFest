namespace CardGame2023SpringLearnFest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck fullDeck = new Deck();

            foreach (Card thisCard in fullDeck.Cards)
            {
                Console.WriteLine(thisCard.ToString());
            }
        }
    }
}