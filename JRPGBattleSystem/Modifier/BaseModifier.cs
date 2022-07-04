using System;
namespace JRPGBattleSystem.Modifier
{
    public class BaseModifier : IModifier
    {
        public BaseModifier(Enum type, ModifierTarget target, ModifierTrigger applyTrigger, ModifierTrigger removeTrigger)
        {
            ModifierType = type;
            ApplyTrigger = applyTrigger;
            RemoveTrigger = removeTrigger;
            Target = target;
        }

        public Enum ModifierType { get; }
        public ModifierTrigger ApplyTrigger { get; }
        public ModifierTrigger RemoveTrigger { get; }
        public ModifierTarget Target { get; }
        // Instead of being removed from the attached target, its effect is repeated more cycles
        public int Repeat { get; set; }
        // Chance to apply the modifier, it must be evaluated before adding it to the cycle
        public float ChanceToApply { get; set; }
        // Some modifiers can make use of a cooldown period to avoid its usage multiple time, also must be evaluated before adding it to the cycle
        public bool InCooldown { get; set; }
    }

    public enum ModifierTarget
    {
        None,
        Own,
        Opponent,
        OwnGroup,
        OwnOpponent,
        Custom
    }
}
