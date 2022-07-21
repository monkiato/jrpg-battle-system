using System;
using System.Collections.Generic;

namespace JRPGBattleSystem.Log
{
    public class BattleLog<T> where T : Enum
    {
        private readonly Queue<BattleLogEntry<T>> entries = new Queue<BattleLogEntry<T>>();

        public BattleLog()
        {
        }

        public Queue<BattleLogEntry<T>> GetLogs()
        {
            //return a copy
            return new Queue<BattleLogEntry<T>>(entries.ToArray());
        }

        public void Push(BattleLogEntry<T> entry)
        {
            entries.Enqueue(entry);
        }

        public void Clean()
        {
            entries.Clear();
        }
    }
}
