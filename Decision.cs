using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgSimulat
{
    public enum ActionDecisionType
    {
        Summon, //summon a creature
        Attack, //attack with an existing creature
        CastInstant,
        CastSorcerie,
        CastEnchantment,
        Defend
    };
    public enum DecisionType
    {
        Sub,
        Super
    };
    public class Decision
    {
        public ActionDecisionType actionType;
        public List<Card> RelevantCards;
        public Player targetPlayer;
        public Card targetCard; //for enchantments or instants
        public DecisionType Type;
        public int turn;

        public void EncodeSummon(Card card)
        {
            RelevantCards.Add(card);
            this.actionType = ActionDecisionType.Summon;
        }
        public void EncodeSummon(List<Card> cards) //overloaded function!
        {
            RelevantCards.AddRange(cards);
            this.actionType = ActionDecisionType.Summon;
        }
        public void EncodeAttack(Card card)
        {
            RelevantCards.Add(card);
            this.actionType = ActionDecisionType.Attack;
        }
        public void EncodeAttack(List<Card> cards) //overloaded function!
        {
            RelevantCards.AddRange(cards);
            this.actionType = ActionDecisionType.Attack;
        }
        public void EncodeEnchant(Card card)
        {
            RelevantCards.Add(card);
            this.actionType = ActionDecisionType.CastEnchantment;
        }
        public void EncodeEnchant(List<Card> cards)
        {
            RelevantCards.AddRange(cards);
            this.actionType = ActionDecisionType.CastEnchantment;
        }
    }
}
