using System;
using System.Collections.Generic;

namespace JRPGBattleSystem
{
    public class ModifierCycleManager
    {
        private readonly List<ModifierData> modifierDataList = new List<ModifierData>();

        public ModifierCycleManager()
        {
        }

        public List<IModifier> AllModifiers => modifierDataList.ConvertAll<IModifier>(data => data.Modifier);

        public void Register(IModifier modifier, Character character)
        {
            modifierDataList.Add(new ModifierData(modifier, character));
            if (modifier.ApplyTrigger == ModifierTrigger.None)
            {
                //apply immediately
                ApplyModifier(modifier, character);
            }
        }

        private void ApplyModifier(ModifierData data)
        {
            ApplyModifier(data.Modifier, data.Character);
        }

        private void ApplyModifier(IModifier modifier, Character character)
        {
            if (modifier is StateModifier)
            {
                character.ApplyModifier(modifier as StateModifier);
            }
            else if (modifier is StatsModifier)
            {
                character.Stats.ApplyModifier(modifier as StatsModifier);
            }
            else
            {
                throw new Exception("Invalid modifier type: " + modifier.GetType());
            }
        }

        private void RemoveModifier(ModifierData data)
        {
            RemoveModifier(data.Modifier, data.Character);
        }

        private void RemoveModifier(IModifier modifier, Character character)
        {
            if (modifier is StateModifier)
            {
                character.RemoveModifier(modifier as StateModifier);
            }
            else if (modifier is StatsModifier)
            {
                character.Stats.RemoveModifier(modifier as StatsModifier);
            }
            else
            {
                throw new Exception("Invalid modifier type: " + modifier.GetType());
            }
        }

        public TriggerResult Trigger(ModifierTrigger trigger)
        {
            return Trigger(trigger, null);
        }

        public TriggerResult Trigger(ModifierTrigger trigger, Character targetCharacter)
        {
            var toApply = modifierDataList.FindAll(data => data.Modifier.ApplyTrigger == trigger && (targetCharacter == null || targetCharacter == data.Character));
            toApply.ForEach(data => ApplyModifier(data));
            var toRemove = modifierDataList.FindAll(data => data.Modifier.RemoveTrigger == trigger && (targetCharacter == null || targetCharacter == data.Character));
            toRemove.ForEach(data => RemoveModifier(data));
            return new TriggerResult(toApply, toRemove);
        }

        public class ModifierData
        {
            public IModifier Modifier { get; }

            public Character Character { get; }

            public ModifierData(IModifier modifier, Character character)
            {
                Modifier = modifier;
                Character = character;
            }
        }

        public class TriggerResult
        {
            public TriggerResult(List<ModifierData> toApply, List<ModifierData> toRemove)
            {
                Applied = toApply;
                Removed = toRemove;
            }

            public List<ModifierData> Applied { get; }
            public List<ModifierData> Removed { get; }
        }
    }
}
