using System;
namespace JRPGBattleSystem
{
    public class StateModifier : BaseModifier
    {
        public StateModifier(Enum type, ModifierTrigger applyTrigger, ModifierTrigger removeTrigger) :
            base(type, applyTrigger, removeTrigger)
        {
        }
    }
}
