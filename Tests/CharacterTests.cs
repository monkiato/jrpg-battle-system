using System;
using JRPGBattleSystem;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CharacterTests
    {
        private CharacterStats stats;
        private Character character;

        [SetUp]
        public void SetUp()
        {
            this.stats = new CharacterStats(50, 10, 20, 30);
            this.character = new Character(stats);
        }

        [Test]
        public void ShoudReturnValidStats()
        {
            var stats = character.Stats;
            Assert.NotNull(stats);
            Assert.AreSame(this.stats, stats);
        }

        [Test]
        public void ShouldReturnEmptyModifiers()
        {
            var modifiers = character.Modifiers;
            Assert.AreEqual(0, modifiers.Count);
        }

        [Test]
        public void ShouldApplyValidStateModifier()
        {
            StateModifier modifier = new StateModifier(CharacterStates.Stun, ModifierTrigger.None, ModifierTrigger.TurnEnds);
            character.ApplyModifier(modifier);
            var modifiers = character.Modifiers;
            Assert.AreEqual(1, modifiers.Count);
            Assert.AreSame(modifier, modifiers[0]);
        }

        [Test]
        public void ShouldCleanModifier()
        {
            StateModifier modifier = new StateModifier(CharacterStates.Stun, ModifierTrigger.None, ModifierTrigger.TurnEnds);
            character.ApplyModifier(modifier);
            var modifiers = character.Modifiers;
            Assert.AreEqual(1, modifiers.Count);
            character.RemoveModifier(modifier);
            Assert.AreEqual(0, character.Modifiers.Count);
        }

        [Test]
        public void ShouldHaveSpecialState()
        {
            StateModifier modifier = new StateModifier(CharacterStates.Stun, ModifierTrigger.None, ModifierTrigger.TurnEnds);
            Assert.False(character.HasState(CharacterStates.Stun));
            character.ApplyModifier(modifier);
            Assert.True(character.HasState(CharacterStates.Stun));
        }

        [Test]
        public void ShouldApplyValidStatModifier()
        {
            StatsModifier modifier = new IncreaseSTRModifier(5);
            character.Stats.ApplyModifier(modifier);
            var modifiers = character.Stats.Modifiers;
            Assert.AreEqual(1, modifiers.Count);
        }

        [Test]
        public void ShouldGetStatsWithModifierInfo()
        {
            StatsModifier modifier = new IncreaseSTRModifier(5);
            character.Stats.ApplyModifier(modifier);
            var str = character.Stats.STR;
            Assert.AreEqual(15, str.Value);
            Assert.AreEqual(10, str.NetValue);
            Assert.AreEqual(5, str.Modifier);
        }

        [Test]
        public void ShouldCleanStatsWithModifierInfo()
        {
            StatsModifier modifier = new IncreaseSTRModifier(5);
            character.Stats.ApplyModifier(modifier);
            var str = character.Stats.STR;
            Assert.AreEqual(15, str.Value);
            Assert.AreEqual(10, str.NetValue);
            Assert.AreEqual(5, str.Modifier);
            character.Stats.RemoveModifier(modifier);
            str = character.Stats.STR;
            Assert.AreEqual(10, str.Value);
            Assert.AreEqual(10, str.NetValue);
            Assert.AreEqual(0, str.Modifier);
        }
    }
}
