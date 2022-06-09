using System;
namespace JRPGBattleSystem
{
    /// <summary>
    /// Expected Enum with the different states
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BattleStateMachine<T> where T : Enum
    {
        public IBattleState CurrentState { get; private set; }

        public BattleStateMachine(bool autoInitialize = true)
        {
            if (autoInitialize) ChangeState(CreateState(default));
        }

        public abstract IBattleState CreateState(T state);

        public void ChangeState(IBattleState newState)
        {
            if (newState == null) throw new Exception("Received null state");
            if (newState.GetEnum().GetType() != typeof(T)) throw new Exception("Invalid state received, using a wrong enum type");

            if (CurrentState != null)
            {
                CurrentState.Stop();
            }
            CurrentState = newState;
            CurrentState.Start();
        }
    }

    public interface IBattleState
    {
        void Start();

        void Stop();

        Enum GetEnum();
    }
}
