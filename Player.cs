using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgSimulat
{
    public class Player
    {
        public float aggressiveness;
        public float deffensive;
        public float conservative;
        public float desperation;

        public int rollRes;
        public int handSize;
        public int health;
        public int infect;

        public int teamId;

        // agressive players are constantly on the offense. Once an aggressive player gets a card, they play it.
        // deffensive players constantly respond to what an opponent is doind (couter decks for example).
        // conservative players play the least amount of cards until they get their win condition.

        public List<Card> battleField = new List<Card>();
        public List<Card> graveYard = new List<Card>();
        public Deck deck;
        public Hand hand;

        public bool hasPlayedManaThisTurn = false;

        public Player()
        {
            deck = new Deck();
            hand = new Hand();
        }

        public string ToString()
        {
            return "agr: " + aggressiveness + "," + " def: " + deffensive + "," + " conserv: " + conservative + "," + " desperate: " + desperation + "," + " handSz: " + handSize + "," +
                " health: " + health + "," + " infect: " + infect + "," + " team: " + teamId;
        }

    }
}
