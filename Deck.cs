using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgSimulat
{
    public class Deck
    {
        List<Card> deck = new List<Card>();

        public void printDeck()
        {
            foreach (Card card in deck)
            {
                card.printCard();
            }
        }
    }
}
