using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgSimulat
{
    public static class Shared
    {
        public static Game newGame;
    }

    class Program
    {
        static void Main(string[] args)
        {
        }

        public void makeDummyPlayer()
        {
            //for debugging purposes we make a character like this
            Player player = new Player();
            player.aggresive = 0.7F;
            player.conservative = 0.1F;
            player.deffensive = 0.2F;
        }

        public Card makeDummyCard()
        {
            //for debugging purposes we make VERY basic cards
            Random rand = new Random();
            int randAtk = rand.Next(0, 5);
            int randDef = rand.Next(0, 5);
            int randConvertedMana = rand.Next(0, 4);
            int randColorCost = rand.Next(0, 4);

            Card card = new Card();
            card.cardName = "dummy card";
            card.cardType = "creature";
            card.manaColor = "green";
            card.atk = randAtk;
            card.def = randDef;
            card.convertedManaCost = randConvertedMana;
            card.colorManaCost = randColorCost;

            return card;
            
        }
        public void makeDummyDeck()
        {
            Deck newDeck = new Deck();
            Random rand = new Random();
            int n = rand.Next(60, 70);

            for (int i = 0; i < n; i++)
            {
               newDeck.deck.Add(makeDummyCard());
            }
        }
    }
}
