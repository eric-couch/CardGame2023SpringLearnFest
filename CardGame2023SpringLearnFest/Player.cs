using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame2023SpringLearnFest
{
    internal class Player
    {
        public string Name { get; set; } = String.Empty;
        public Deck Hand { get; set; } = new Deck();
        public Player() { }
    }
}
