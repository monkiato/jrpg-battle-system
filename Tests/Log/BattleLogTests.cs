using JRPGBattleSystem.Log;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class BattleLogTests
    {
        private TestBattleLog battleLog;

        [SetUp]
        public void SetUp()
        {
            battleLog = new TestBattleLog();
        }

        [Test]
        public void ShouldStartWithNoLogs()
        {
            Assert.AreEqual(0, battleLog.GetLogs().Count);
        }

        [Test]
        public void ShouldRegisterLog()
        {
            var singleLog = new TestBattleLogEntry(TestBattleLogType.Attack);
            battleLog.Push(singleLog);
            Assert.AreEqual(1, battleLog.GetLogs().Count);
        }

        [Test]
        public void ShouldRegisterMultipleLogs()
        {
            battleLog.Push(new TestBattleLogEntry(TestBattleLogType.Attack));
            battleLog.Push(new TestBattleLogEntry(TestBattleLogType.Deffend));
            battleLog.Push(new TestBattleLogEntry(TestBattleLogType.AppliedModifier));
            Assert.AreEqual(3, battleLog.GetLogs().Count);
        }

        [Test]
        public void ShouldReturnLog()
        {
            var singleLog = new TestBattleLogEntry(TestBattleLogType.Attack);
            battleLog.Push(singleLog);
            Assert.AreSame(singleLog, battleLog.GetLogs().Dequeue());
        }

        [Test]
        public void ShouldReturnSameOrder()
        {
            battleLog.Push(new TestBattleLogEntry(TestBattleLogType.Attack));
            battleLog.Push(new TestBattleLogEntry(TestBattleLogType.Deffend));
            battleLog.Push(new TestBattleLogEntry(TestBattleLogType.AppliedModifier));
            var logs = battleLog.GetLogs();
            Assert.AreEqual(TestBattleLogType.Attack, logs.Dequeue().BattleLoGType);
            Assert.AreEqual(TestBattleLogType.Deffend, logs.Dequeue().BattleLoGType);
            Assert.AreEqual(TestBattleLogType.AppliedModifier, logs.Dequeue().BattleLoGType);
        }

        [Test]
        public void ShouldCleanLogs()
        {
            var singleLog = new TestBattleLogEntry(TestBattleLogType.Attack);
            battleLog.Push(singleLog);
            Assert.AreEqual(1, battleLog.GetLogs().Count);
            battleLog.Clean();
            Assert.AreEqual(0, battleLog.GetLogs().Count);
        }

        [Test]
        public void ShouldReturnACopyOfQueue()
        {
            battleLog.Push(new TestBattleLogEntry(TestBattleLogType.Attack));
            var logs = battleLog.GetLogs();
            logs.Clear();
            Assert.AreEqual(1, battleLog.GetLogs().Count);
        }
    }

    internal class TestBattleLog : BattleLog<TestBattleLogType>
    {
    }

    internal class TestBattleLogEntry : BattleLogEntry<TestBattleLogType>
    {
        public TestBattleLogEntry(TestBattleLogType type) : base(type)
        {
        }
    }

    internal enum TestBattleLogType
    {
        Attack,
        Deffend,
        EndTurn,
        AppliedModifier
    }
}
