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
        

        public void Start()
        {
            if (!isValidGame())
            {
                Console.WriteLine("not a valid number of players");
                return;
            }
            Console.WriteLine("cvalid number of players. Beginning game");


            //need to draw a hand 
            int handSize = 7;
            foreach (Player p in players)
            {
                Deck currentDeck = p.playerDeck;
                for (int i = 0; i < handSize; i++)
                {
                    Card currentCard = currentDeck[0];
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

        public void AddPlayer(Player currentPlayer)
        {
            players.Add(currentPlayer);
            // add a player to list of players
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
        List<Decision> generatePhaseDecisions(Player p)
        {
            // (1) Look at all of our cards, and whatever and
            // find out what we can do for whatever phase we're in

            // (2) Take all possible actions and "encode" them into Decision objects

            // (3) Add all Decision objects to local list and return the list

            // (4) The list of Decision objects will be used later to select from
        }
    }
}
