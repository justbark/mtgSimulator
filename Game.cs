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
            //check and see if this game is started.
        }
        public bool isValidGame()
        {
            return players.Count() % 2 == 0;
            //check if there is an even number of players.
            //if number of players is divisible by 2 return a 1 for true.
        }

        public void AddPlayer(Player currentPlayer)
        {
            players.Add(currentPlayer);
            // add a player to list of players
        }
    }
}
