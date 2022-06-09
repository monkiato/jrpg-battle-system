using System;

namespace JRPGBattleSystem
{
    public class CharacterSingleStat
    {
        public int MaxValue { get; private set; }
        public int Value
        {
            get
            {
                return Math.Min(MaxValue, NetValue + Modifier);
            }
        }
        public int NetValue { get; private set; }
        public int Modifier { get; set; }

        public CharacterSingleStat Clone()
        {
            return new CharacterSingleStat(NetValue, MaxValue)
            {
                Modifier = Modifier
            };
        }

        public CharacterSingleStat(int value)
        {
            NetValue = value;
            MaxValue = int.MaxValue;
        }

        public CharacterSingleStat(int value, int maxValue) : this(value)
        {
            MaxValue = maxValue;
        }

        public void AddValue(int value)
        {
            //can't be < 0 or > MaxValue
            NetValue = Math.Min(MaxValue, Math.Max(0, NetValue + value));
        }
    }
}