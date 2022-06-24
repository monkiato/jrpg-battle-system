using System;
using JRPGBattleSystem;

namespace Tests
{
    internal class IncreaseSTRModifier : StatsModifier
    {
        private int increaseValue;

        public IncreaseSTRModifier(int increaseValue) : base(CharacterStatModifierType.IncreaseSTR, ModifierTarget.Own, ModifierTrigger.None, ModifierTrigger.CharacterAttackEnds)
        {
            this.increaseValue = increaseValue;
        }

        public override int GetModifierValue(CharacterStatType statType)
        {
            if (statType == CharacterStatType.STR) return increaseValue;
            return 0;
        }

        public override bool CanModifyStatType(CharacterStatType statType)
        {
            return statType == CharacterStatType.STR;
        }
    }
    internal class DecreaseRESNextTurnModifier : StatsModifier
    {
        private int decreaseValue;

        public DecreaseRESNextTurnModifier(int decreaseValue) : base(CharacterStatModifierType.DecreaseRES, ModifierTarget.Opponent, ModifierTrigger.TurnStarts, ModifierTrigger.TurnEnds)
        {
            this.decreaseValue = decreaseValue;
        }

        public override int GetModifierValue(CharacterStatType statType)
        {
            if (statType == CharacterStatType.RES) return -decreaseValue;
            return 0;
        }

        public override bool CanModifyStatType(CharacterStatType statType)
        {
            return statType == CharacterStatType.RES;
        }
    }

    internal enum CharacterStatModifierType
    {
        IncreaseSTR,
        DecreaseRES
    }

    internal enum CharacterStates
    {
        Stun,
        Bleeding
    }
}
