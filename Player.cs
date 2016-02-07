using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgSimulat
{
    public class Player
    {
        public int aggresive;
        public int deffensive;
        public int conservative;

        // agressive players are constantly on the offense. Once an aggressive player gets a card, they play it.
        // deffensive players constantly respond to what an opponent is doind (couter decks for example).
        // conservative players play the least amount of cards until they get their win condition.
    }
}
