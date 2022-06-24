using System;
namespace JRPGBattleSystem
{
    public interface IModifier
    {
        Enum ModifierType { get; }
        ModifierTrigger ApplyTrigger { get; }
        ModifierTrigger RemoveTrigger { get; }
        ModifierTarget Target { get; }
        // Instead of being removed from the attached target, its effect is repeated more cycles
        int Repeat { get; set; }
        // Chance to apply the modifier, it must be evaluated before adding it to the cycle
        float ChanceToApply { get; set; }
        // Some modifiers can make use of a cooldown period to avoid its usage multiple time, also must be evaluated before adding it to the cycle
        bool InCooldown { get; set; }
    }
}
