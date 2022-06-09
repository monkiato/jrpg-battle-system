using System;
namespace JRPGBattleSystem
{
    public interface IModifier
    {
        Enum ModifierType { get; }
        ModifierTrigger ApplyTrigger { get; }
        ModifierTrigger RemoveTrigger { get; }
    }
}
