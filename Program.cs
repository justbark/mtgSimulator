﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgSimulat
{
    public static class Shared
    {
        public static Game game;
        public static Random rand;
        public static int debugLevel = 1; //0, 1, 2, 3
        public static System.IO.StreamWriter file;
        public static string logFileNameString = "C:\\Users\\Owner\\Desktop\\gamelog5.txt";

        static Shared()
        {
            debugLevel = 4;
            AppDomain.CurrentDomain.ProcessExit += StaticClass_Dtor; //adds a destructor to a static class
            System.IO.File.WriteAllText(logFileNameString, "");
            Shared.file = new System.IO.StreamWriter(logFileNameString);
            Shared.file.WriteLine("BEGIN MTG GAME");
            dwr(0, "Static constructor");
        }
        static void StaticClass_Dtor(object sender, EventArgs e)
        {
            // clean it up
            Shared.file.WriteLine("shutting down");
            Shared.file.Close();
        }

        public static string dwr(int severity, string msg)
        {
            if (severity > Shared.debugLevel)
            {
                return msg;
            }
            Console.WriteLine(msg);
            Shared.file.WriteLine(msg);
            return msg;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //=======================================================================================
            //gets user input
            //=======================================================================================
            Shared.rand = new Random();
            string line = "";
            while (line != "exit" && line != "quit" && line != "q")
            {
                line = Console.ReadLine(); //wait for text to generate all sentences file
                if (line == "start")
                {
                    /*//System.IO.File.WriteAllText(Shared.logFileNameString, "");
                    Shared.file = new System.IO.StreamWriter(Shared.logFileNameString);
                    Shared.file.WriteLine("Decolatage");
                    Shared.file.Close();

                    System.Environment.Exit(1);*/

                    Shared.game = new Game();

                    Player p1 = makeDummyPlayer();
                    p1.teamId = 0;

                    Player p2 = makeDummyPlayer();
                    p2.teamId = 1;

                    Deck d1 = makeDummyDeck();
                    Deck d2 = makeDummyDeck();

                    d1.printDeck();
                    d2.printDeck();

                    // Stitch them together
                    p1.deck = d1;
                    p2.deck = d2;

                    Shared.game.AddPlayer(p1);
                    Shared.game.AddPlayer(p2);

                    Shared.game.Start();
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
            player.health = 20;
            player.infect = 0;

            return player;
        }

        public static Card makeDummyCard()
        {
            //for debugging purposes we make VERY basic cards
            
            int randAtk = Shared.rand.Next(1, 5);
            int randDef = Shared.rand.Next(1, 5);
            int randTotalMana = Shared.rand.Next(1, 4);
            int randColorCost = Shared.rand.Next(1, 3);

            Card card = new Card();
            card.cardName = "dummy card";
            card.Type = CardType.Creature;
            card.manaType = ManaType.green;
            card.atk = randAtk;
            card.def = randDef;
            card.convertedManaCost = randTotalMana;   //converted mana cost is the total number of mana
            card.colorManaCost = randColorCost;       //this can be a random number
            if (card.colorManaCost > card.convertedManaCost)
            {
                card.colorlessManaCost = 0;
                card.convertedManaCost = card.colorManaCost;
                return card;
            }
            card.colorlessManaCost = card.convertedManaCost - card.colorManaCost;   //to figure out the colorless mana cost we need to subtract converted mana cost from color cost

            return card;
            
        }
        public static Card makeDummyLands()
        {
            Card card = new Card();
            card.cardName = "Land";
            card.manaType = ManaType.green;
            card.Type = CardType.Mana;

            return card;
        }
        public static Deck makeDummyDeck()
        {
            Deck newDeck = new Deck();
            int n = Shared.rand.Next(50, 60);

            for (int i = 0; i < n; i++)
            {
               newDeck.cards.Add(makeDummyCard());
            }

            int n_mana = Shared.rand.Next(10, 15);
            for (int i = 0; i < n_mana; i++)
            {
                newDeck.cards.Add(makeDummyLands());
            }

            return newDeck;
        }
        
    }
}
