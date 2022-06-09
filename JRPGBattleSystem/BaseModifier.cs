using System;
namespace JRPGBattleSystem
{
    public class BaseModifier : IModifier
    {
        public BaseModifier(Enum type, ModifierTrigger applyTrigger, ModifierTrigger removeTrigger)
        {
            ModifierType = type;
            ApplyTrigger = applyTrigger;
            RemoveTrigger = removeTrigger;
        }

        public Enum ModifierType { get; }
        public ModifierTrigger ApplyTrigger { get; }
        public ModifierTrigger RemoveTrigger { get; }
    }
}
