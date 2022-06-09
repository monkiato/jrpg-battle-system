using System;
using JRPGBattleSystem;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CharacterSingleStatTests
    {
        private CharacterSingleStat stat;

        [SetUp]
        public void SetUp()
        {
            stat = new CharacterSingleStat(20, 30);
        }

        [Test]
        public void ShouldCopyStat()
        {
            stat.Modifier = 5;
            var other = stat.Clone();
            Assert.AreNotSame(stat, other);
            Assert.AreEqual(stat.Value, other.Value);
            Assert.AreEqual(stat.NetValue, other.NetValue);
            Assert.AreEqual(stat.Modifier, other.Modifier);
        }
    }
}
