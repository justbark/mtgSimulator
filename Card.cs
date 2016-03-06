using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgSimulat
{
    public enum CardType
    {
        Mana,
        Creature,
        Instant,
        Sorcery,
        Enchantment
    };
    public enum ManaType
    {
        black,
        red,
        green,
        blue,
        white  
    };
    public class Card
    {
        public string cardName;       //stores the name of the card
        public ManaType manaType;
        public CardType Type;
        public string type;       //stores the type of card (creature, sorcery,etc)
        public int colorManaCost;     //stores the number of colored mana needed to cast card
        public int convertedManaCost; //stores the total number of mana needed to play card
        public int colorlessManaCost;     // total number of mana needed to play the card
        public int atk;               //stores creature attack
        public int def;               //stores the creature def.
        public bool isTapped = false;
        public bool hasHaste = false;
       

        //make an enum for card type.

        public void printCard()
        {
            Console.WriteLine(cardName);
            Console.WriteLine(Type);
            Console.WriteLine(manaType);
            Console.WriteLine("color of mana: " + colorManaCost);
            Console.WriteLine("Converted mana cost: " + convertedManaCost);
            Console.WriteLine("atk: " + atk);
            Console.WriteLine("def: " + def);
        }
        
        public String ToString()
        {
            return "name: " + cardName + "," + " type: " + Type + "," + " mC: " + manaType + "," + " Colorcost: " + colorManaCost + "," + " colorless: " + colorlessManaCost + "," + " converted: " + convertedManaCost + "," + " atk: " + atk + "," + " def " + def;
        }
    }
}
