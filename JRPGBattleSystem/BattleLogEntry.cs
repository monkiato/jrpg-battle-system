using System;

namespace JRPGBattleSystem
{

    /*
     * Represents a single battle log report, it's expected to use a specific
     * Enum to identify the different log types.
     * 
     * Usage examples:
     * 
     * class MyBattleLogEntry : BattleLogEntry<BattleLogType> { ... }
     * 
     * var entry = new MyBattleLogEntry(BattleLogType.Attack)
     * entry.SetAttacker(attacker)
     * entry.SetDeffender(deffender)
     * entry.SetAction(action)
     * 
     * new MyBattleLogEntry(BattleLogType.Deffend);
     * new MyBattleLogEntry(BattleLogType.ModifierRemoved);
     */
    public class BattleLogEntry<T> where T : Enum
    {
        public BattleLogEntry(T type)
        {
            this.BattleLoGType = type;
        }

        public T BattleLoGType { get; }
    }
}