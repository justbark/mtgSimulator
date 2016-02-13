using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgSimulat
{
    public class Game
    {
        public List<Player> players = new List<Player>();
        Random rand;

        public Game()
        {
            rand = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        }
        public void Start()
        {
            //make sure the game is valid
            if (!isValidGame())
            {
                Console.WriteLine("not a valid number of players");
                return;
            }
            Console.WriteLine("valid number of players. Beginning game");


            //need to figure out who goes first. (first player draws 7, the rest draw 8)
            foreach (Player p in players)   //each player needs to roll
            {
                roll(p);
            }
            int highestRes = 0;            // setting a standard number for each player to check and see if their roll result was higher
            foreach (Player p in players)     // each player compares their roll result
            {
                if (p.rollRes > highestRes)    // if current player has the highest roll result
                {
                    highestRes += p.rollRes;     // set the highest result to the player with the highest result
                }
            }
            
            foreach (Player p in players)    //each player now needs to draw a hand
            {
                if (p.rollRes == highestRes)     //if this player has the highest roll result
                {
                    //this player goes first because their roll result was higher
                    // this player draws 7
                    p.handSize = 7;
                    Console.WriteLine("player " + players.IndexOf(p) + " has first turn, drawing 7");
                }
                else                  // this player does not have the highest roll amount
                {
                    p.handSize = 8;      // so this player does not draw seven, they draw 8
                    Console.WriteLine("player " + players.IndexOf(p) + " did not win the roll, drawing 8");
                }
                Console.WriteLine("shuffeling deck for player " + players.IndexOf(p));
                shuffleDeck<Card>(p.deck.cards);//need to shuffle deck so the hand is not creature heavy

                Console.WriteLine("drawing hand for " + players.IndexOf(p));   //trying to display what player is getting a hand. This might be wrong
                drawHand(p, false); 

                //need to make sure that the hand is not lacking mana. If it is, draw again...
                int lands = checkLands(p.hand);
                if (lands >= 2)
                {
                    Console.WriteLine("player " + players.IndexOf(p) + " has sufficient land: " + lands);
                }
                int redrawCount = 1;
                while (lands < 2)
                {
                    Console.WriteLine("player " + players.IndexOf(p) + " did not have enough mana. redrawing");
                    drawHand(p, true);
                    Console.WriteLine("player " + players.IndexOf(p) + " handsize is: " + p.handSize);
                    lands = checkLands(p.hand);
                    redrawCount++;
                    if (redrawCount >= 4)
                    {
                        if (lands != 2)
                        {
                            Console.WriteLine("player " + players.IndexOf(p) + " redrew too many times. Sticking with current hand");
                        }
                        break;
                    }
                }
            }
            


            //check and see if this game is started.
            bool won = false;
            while (won == false)
            {
                foreach (Player p in players)
                {
                    if (this.isGameEnded())
                    {
                        won = true;
                        break;
                    }
                    //this is beginning a players turn

                }
            }
        }

        public bool isValidGame()
        {
            return players.Count() % 2 == 0;
            //check if there is an even number of players.
            //if number of players is divisible by 2 return a 1 for true.
        }

        public bool isGameEnded()
        {
            foreach (Player p in players)
            {
                if (p.health < 1 || p.infect >= 10)
                {
                    return true;
                }
            }
            return false;
        }

        //add a player object generated in program.cs to list of players
        public void AddPlayer(Player currentPlayer)
        {
            players.Add(currentPlayer);
            // add a player to list of players
        }

        //probably need to roll to figure out what player goes first...
        public void roll(Player p)
        {
            int rollD20 = rand.Next(1, 20);
            p.rollRes = rollD20;
        }

        public string ToString()
        {
            string output = "";
            foreach (Player p in players)
                output += p.ToString();
            return output;
        }

        public void shuffleDeck<T>(List<T> list)
        {
            int n = list.Count();
            while (n > 1)
            {
                int k = (Shared.rand.Next(0, n) % n);
                n--;
                T temp = list[k];
                list[k] = list[n];
                list[n] = temp;
            }
        }

        public int checkLands(Hand hand)
        {
            int manaCount = 0;
            foreach (Card card in hand.cards)
            {
                if (card.cardType == "mana")
                {
                    manaCount++;
                }
            }
            return manaCount;
        }

        public void drawHand(Player p, bool secondAttempt)
        {
            if (secondAttempt == false)
            {
                for (int i = 0; i < p.handSize; i++)     //draw x cards from players deck
                {
                    Card currentCard = p.deck.cards[i];   //grab a card from deck
                    p.hand.cards.Add(currentCard);        // put this card in hand
                    p.deck.cards.Remove(currentCard);   // remove this card from player deck
                }
            }
            else
            {
                
                p.deck.cards.AddRange(p.hand.cards); //add cards from hand to deck
                p.hand.cards.Clear(); //remove cards from hand

                shuffleDeck<Card>(p.deck.cards); //shuffle
                p.handSize--; //decrease hand size
                for (int i = 0; i < p.handSize; i++)     //draw x cards from players deck
                {
                    Card currentCard = p.deck.cards[i];   //grab a card from deck
                    p.hand.cards.Add(currentCard);        // put this card in hand
                    p.deck.cards.Remove(currentCard);   // remove this card from player deck
                }

            }
        }

        //=======================================================================
        //Phase stuff
        //=======================================================================
        public void doPhaseStuff(Player p)
        {

        }

        //=======================================================================
        //Decision stuff
        //=======================================================================
        //List<Decision> generatePhaseDecisions(Player p)
        //{
            // (1) Look at all of our cards, and whatever and
            // find out what we can do for whatever phase we're in

            // (2) Take all possible actions and "encode" them into Decision objects

            // (3) Add all Decision objects to local list and return the list

            // (4) The list of Decision objects will be used later to select from
        //}
    }
}
