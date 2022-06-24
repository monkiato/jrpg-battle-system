using System;
using JRPGBattleSystem;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class BattleStateMachineTests
    {
        private TestBattleStateMachine stateMachine;

        private enum TestBattleStates
        {
            Initial,
            Second,
            Third
        }

        private class TestBattleStateMachine : BattleStateMachine<TestBattleStates>
        {
            public IBattleState CreateState(TestBattleStates state)
            {
                IBattleState newState = null;
                switch (state)
                {
                    case TestBattleStates.Initial:
                        newState = new FirstState();
                        break;
                    case TestBattleStates.Second:
                        newState = new SecondState();
                        break;
                    case TestBattleStates.Third:
                        newState = new ThirdState();
                        break;
                }
                return newState;
            }
        }

        private class WrongState : IBattleState
        {
            public enum WrongEnumState
            {
                Wrong,
                Enum
            }

            public Enum GetEnum()
            {
                return WrongEnumState.Wrong;
            }

            public void Start()
            {
            }

            public void Stop()
            {
            }
        }

        private class BaseState : IBattleState
        {
            private Enum state;

            public BaseState(Enum state)
            {
                this.state = state;
            }

            public Enum GetEnum()
            {
                return state;
            }

            public void Start()
            {
            }

            public void Stop()
            {
            }
        }

        private class FirstState : BaseState
        {
            public FirstState() : base(TestBattleStates.Initial)
            {
            }
        }

        private class SecondState : BaseState
        {
            public SecondState() : base(TestBattleStates.Second)
            {
            }
        }

        private class ThirdState : BaseState
        {
            public ThirdState() : base(TestBattleStates.Third)
            {
            }
        }

        [SetUp]
        public void SetUp()
        {
            stateMachine = new TestBattleStateMachine();
        }

        [Test]
        public void ShouldInitializeWithNullState()
        {
            Assert.IsNull(stateMachine.CurrentState);
        }

        [Test]
        public void ShouldCreateNewState()
        {
            var state = stateMachine.CreateState(TestBattleStates.Second);
            Assert.NotNull(state);
            Assert.IsInstanceOf<SecondState>(state);
        }

        [Test]
        public void ShouldChangeState()
        {
            var state = stateMachine.CreateState(TestBattleStates.Second);
            stateMachine.ChangeState(state);
            stateMachine.Update();
            Assert.AreEqual(TestBattleStates.Second, stateMachine.CurrentState.GetEnum());
        }

        [Test]
        public void ShouldFailIfStateIsNull()
        {
            Assert.Throws<Exception>(() =>
            {
                stateMachine.ChangeState(null);
                stateMachine.Update();
            });
        }

        [Test]
        public void ShouldFailIfWrongState()
        {
            Assert.Throws<Exception>(() =>
            {
                stateMachine.ChangeState(new WrongState());
                stateMachine.Update();
            });
        }
    }
}
