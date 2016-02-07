using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgSimulat
{
    class Card
    {
        public string cardName;       //stores the name of the card
        public string manaColor;      //stores the color of mana needed to play card
        public string cardType;       //stores the type of card (creature, sorcery,etc)
        public int colorManaCost;     //stores the number of colored mana needed to cast card
        public int convertedManaCost; //stores the total number of mana needed to play card
        public int atk;               //stores creature attack
        public int def;               //stores the creature def.

        public void printCard()
        {
            Console.WriteLine(cardName);
            Console.WriteLine(cardType);
            Console.WriteLine(manaColor);
            Console.WriteLine("color of mana: " + colorManaCost);
            Console.WriteLine("Converted mana cost: " + convertedManaCost);
            Console.WriteLine("atk: " + atk);
            Console.WriteLine("def: " + def);
        }

    }
}
