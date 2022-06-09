﻿using System;
namespace JRPGBattleSystem
{
    public abstract class StatsModifier : BaseModifier
    {
        protected CharacterStats Stats { get; private set; }

        public StatsModifier(Enum type, ModifierTrigger applyTrigger, ModifierTrigger removeTrigger) :
            base(type, applyTrigger, removeTrigger)
        {
        }

        public void SetOwner(CharacterStats stats)
        {
            Stats = stats;
        }

        public abstract bool CanModifyStatType(CharacterStatType statType);
        public abstract int GetModifierValue(CharacterStatType statType);

        public void Remove()
        {
            if (Stats == null) throw new Exception("Stats owner wasn't assigned");
            Stats.RemoveModifier(this);
        }
    }
}
