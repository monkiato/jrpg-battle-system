using System;
using System.Collections.Generic;
using System.Linq;

namespace JRPGBattleSystem
{
    public class Character
    {
        public CharacterStats Stats { get; private set; }

        public List<StateModifier> Modifiers { get; } = new List<StateModifier>();

        public Character(CharacterStats stats)
        {
            Stats = stats;
        }

        public void ApplyModifier(StateModifier modifier)
        {
            Modifiers.Add(modifier);
        }

        public void RemoveModifier(StateModifier modifier)
        {
            Modifiers.Remove(modifier);
        }

        public bool HasState(Enum state)
        {
            return Modifiers.Any(modifier => state.CompareTo(modifier.ModifierType) == 0);
        }

        public void UpdateStats(CharacterStats newStats)
        {
            Stats = newStats;
        }
    }
}
