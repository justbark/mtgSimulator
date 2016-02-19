using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgSimulat
{
    public class Hand
    {
        public List<Card> cards = new List<Card>();

        public string ToString()
        {
            return "mana: " + this.cards.Where(x => x.Type == CardType.Mana).Count() + "," + " regular: " + this.cards.Where(x => x.Type == CardType.Creature).Count();
        }

        public int findLowestManaCost()
        {
            int lowestMana = 10;
            foreach(Card card in cards)
            {
                if (card.convertedManaCost < lowestMana)
                {
                    lowestMana--;
                }
            }
            return lowestMana;
        }
    }
}
