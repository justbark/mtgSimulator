using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgSimulat
{
    public static class Shared
    {
        public static Game game;
    }

    class Program
    {
        static void Main(string[] args)
        {
            //=======================================================================================
            //gets user input
            //=======================================================================================
            string line = "";
            while (line != "exit" && line != "quit" && line != "q")
            {
                line = Console.ReadLine(); //wait for text to generate all sentences file
                if (line == "start")
                {
                    Shared.game = new Game();

                    Player p1 = makeDummyPlayer();
                    Player p2 = makeDummyPlayer();

                    Deck d1 = makeDummyDeck();
                    Deck d2 = makeDummyDeck();

                    d1.printDeck();
                    d2.printDeck();

                    // Stitch them together
                    p1.playerDeck = d1;
                    p2.playerDeck = d2;

                    Shared.game.AddPlayer(p1);
                    Shared.game.AddPlayer(p2);
                }
                
                line = "";
            }
        }

        public static Player makeDummyPlayer()
        {
            //for debugging purposes we make a character like this
            Player player = new Player();
            player.aggressiveness = 0.7F;
            player.conservative = 0.1F;
            player.deffensive = 0.2F;

            return player;
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
        public static Deck makeDummyDeck()
        {
            Deck newDeck = new Deck();
            Random rand = new Random();
            int n = rand.Next(60, 70);

            for (int i = 0; i < n; i++)
            {
               newDeck.deck.Add(makeDummyCard());
            }

            return newDeck;
        }
        
    }
}
