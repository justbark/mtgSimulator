using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtgSimulat
{
    public enum SuperDecisionType
    {
        Summon, //summon a creature
        Attack, //attack with an existing creature
        CastInstant,
        CastSorcerie,
        CastEnchantment,
        Defend
    };
    public class Decision
    {
        public SuperDecisionType Type;
        private List<Card> RelevantCards;
        private Player targetPlayer;

        public void EncodeSummon(Card card)
        {
            RelevantCards.Add(card);
            this.Type = SuperDecisionType.Summon;
        }
        public void EncodeSummon(List<Card> cards) //overloaded function!
        {
            RelevantCards.AddRange(cards);
            this.Type = SuperDecisionType.Summon;
        }
        public void EncodeAttack(Card card)
        {
            RelevantCards.Add(card);
            this.Type = SuperDecisionType.Attack;
        }
        public void EncodeAttack(List<Card> cards) //overloaded function!
        {
            RelevantCards.AddRange(cards);
            this.Type = SuperDecisionType.Attack;
        }
    }
}
