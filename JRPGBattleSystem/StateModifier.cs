using System;
namespace JRPGBattleSystem
{
    public class StateModifier : BaseModifier
    {
        public StateModifier(Enum type, ModifierTarget target, ModifierTrigger applyTrigger, ModifierTrigger removeTrigger) :
            base(type, target, applyTrigger, removeTrigger)
        {
        }
    }
}
