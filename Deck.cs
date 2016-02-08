using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgSimulat
{
    public class Deck
    {
        public List<Card> cards = new List<Card>();

        public void printDeck()
        {
            foreach (Card card in cards)
            {
                card.printCard();
            }
        }
    }
}
