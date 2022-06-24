using System;
using System.Collections.Generic;

namespace JRPGBattleSystem
{
    /// <summary>
    /// Expected Enum with the different states
    /// </summary>
    /// <typeparam name="T">Enum with the different battle states</typeparam>
    public class BattleStateMachine<T> where T : Enum
    {
        public IBattleState CurrentState { get; private set; }

        public event Action<IBattleState> OnStateChange;

        private Queue<ChangeStateRequest> pendingStateChanges = new Queue<ChangeStateRequest>();

        public void ChangeState(IBattleState newState)
        {
            pendingStateChanges.Enqueue(new ChangeStateRequest(newState));
        }

        public void Update()
        {
            CheckPendingStateChanges();
        }

        private void CheckPendingStateChanges()
        {
            if (pendingStateChanges.Count > 0)
            {
                var request = pendingStateChanges.Dequeue();
                ExecuteChangeState(request.NewState);
            }
        }

        public void ExecuteChangeState(IBattleState newState)
        {
            if (newState == null) throw new Exception("Received null state");
            if (newState.GetEnum().GetType() != typeof(T)) throw new Exception("Invalid state received, using a wrong enum type");

            if (CurrentState != null)
            {
                CurrentState.Stop();
            }
            CurrentState = newState;
            CurrentState.Start();
            OnStateChange?.Invoke(newState);
        }

        private class ChangeStateRequest
        {
            internal readonly IBattleState NewState;

            public ChangeStateRequest(IBattleState newState)
            {
                this.NewState = newState;
            }
        }
    }
}
