using System;
using JRPGBattleSystem;
using NUnit.Framework;

namespace Tests
{
    public class ModifierCycleManagerTests
    {
        private ModifierCycleManager manager;
        private Character character;
        private StateModifier stateModifier;
        private StatsModifier statsModifier;

        [SetUp]
        public void SetUp()
        {
            character = new Character(new CharacterStats(100, 10, 20, 30));
            stateModifier = new StateModifier(CharacterStates.Bleeding, ModifierTarget.Opponent, ModifierTrigger.TurnStarts, ModifierTrigger.TurnEnds);
            statsModifier = new IncreaseSTRModifier(5);
            manager = new ModifierCycleManager();
        }

        [Test]
        public void ShouldRegisterStateModifier()
        {
            Assert.AreEqual(0, manager.AllModifiers.Count);
            manager.Register(stateModifier, character);
            Assert.AreEqual(1, manager.AllModifiers.Count);
            Assert.AreSame(stateModifier, manager.AllModifiers[0]);
        }

        [Test]
        public void ShouldApplyStateDirectlyIfTriggerNone()
        {
            stateModifier = new StateModifier(CharacterStates.Bleeding, ModifierTarget.Opponent, ModifierTrigger.None, ModifierTrigger.TurnEnds);
            Assert.False(character.HasState(CharacterStates.Bleeding));
            manager.Register(stateModifier, character);
            Assert.True(character.HasState(CharacterStates.Bleeding));
        }

        [Test]
        public void ShouldUseApplyTriggerForState()
        {
            Assert.False(character.HasState(CharacterStates.Bleeding));
            manager.Register(stateModifier, character);
            Assert.False(character.HasState(CharacterStates.Bleeding)); //confirm still false
            manager.Trigger(ModifierTrigger.TurnStarts);
            Assert.True(character.HasState(CharacterStates.Bleeding));
        }

        [Test]
        public void ShouldUseEndTriggerForState()
        {
            stateModifier = new StateModifier(CharacterStates.Bleeding, ModifierTarget.Opponent, ModifierTrigger.None, ModifierTrigger.TurnEnds);
            manager.Register(stateModifier, character);
            Assert.True(character.HasState(CharacterStates.Bleeding));
            manager.Trigger(ModifierTrigger.TurnEnds);
            Assert.False(character.HasState(CharacterStates.Bleeding));
        }

        [Test]
        public void ShouldRegisterStatsModifier()
        {
            Assert.AreEqual(0, manager.AllModifiers.Count);
            manager.Register(statsModifier, character);
            Assert.AreEqual(1, manager.AllModifiers.Count);
            Assert.AreSame(statsModifier, manager.AllModifiers[0]);
        }

        [Test]
        public void ShouldApplyStatsDirectlyIfTriggerNone()
        {
            Assert.AreEqual(10, character.Stats.STR.Value);
            manager.Register(statsModifier, character);
            Assert.AreEqual(15, character.Stats.STR.Value);
        }

        [Test]
        public void ShouldUseApplyTriggerForStats()
        {
            statsModifier = new DecreaseRESNextTurnModifier(5);
            Assert.AreEqual(20, character.Stats.RES.Value);
            manager.Register(statsModifier, character);
            Assert.AreEqual(20, character.Stats.RES.Value); //confirm still false
            manager.Trigger(ModifierTrigger.TurnStarts);
            Assert.AreEqual(15, character.Stats.RES.Value);
        }

        [Test]
        public void ShouldUseEndTriggerForStats()
        {
            manager.Register(statsModifier, character);
            Assert.AreEqual(15, character.Stats.STR.Value);
            manager.Trigger(ModifierTrigger.CharacterAttackEnds);
            Assert.AreEqual(10, character.Stats.STR.Value);
        }

        [Test]
        public void ShouldReturnTriggerResult()
        {
            manager.Register(stateModifier, character);
            var result = manager.Trigger(ModifierTrigger.TurnStarts);
            Assert.AreEqual(1, result.Applied.Count);
            Assert.AreSame(stateModifier, result.Applied[0].Modifier);
            Assert.AreSame(character, result.Applied[0].Character);
            result = manager.Trigger(ModifierTrigger.TurnEnds);
            Assert.AreEqual(0, result.Applied.Count);
        }
    }
}
