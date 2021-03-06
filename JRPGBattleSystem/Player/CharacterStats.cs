using System.Collections.Generic;
using System.Linq;
using JRPGBattleSystem.Modifier;

namespace JRPGBattleSystem.Player
{
    public class CharacterStats
    {
        private readonly CharacterSingleStat hp;
        private readonly CharacterSingleStat str;
        private readonly CharacterSingleStat res;
        private readonly CharacterSingleStat dex;

        public CharacterSingleStat HP => UpdateSingleStatModifiers(hp, CharacterStatType.HP);
        public CharacterSingleStat STR => UpdateSingleStatModifiers(str, CharacterStatType.STR);
        public CharacterSingleStat RES => UpdateSingleStatModifiers(res, CharacterStatType.RES);
        public CharacterSingleStat DEX => UpdateSingleStatModifiers(dex, CharacterStatType.DEX);

        public List<StatsModifier> Modifiers { get; } = new List<StatsModifier>();
        public Character Character { get; set; }

        public CharacterStats(int hp, int str, int res, int dex)
        {
            this.hp = new CharacterSingleStat(hp, hp);
            this.str = new CharacterSingleStat(str);
            this.res = new CharacterSingleStat(res);
            this.dex = new CharacterSingleStat(dex);
        }

        public void ApplyModifier(StatsModifier modifier)
        {
            modifier.SetOwner(this);
            Modifiers.Add(modifier);
        }

        public void RemoveModifier(StatsModifier modifier)
        {
            Modifiers.Remove(modifier);
        }

        private CharacterSingleStat UpdateSingleStatModifiers(CharacterSingleStat stat, CharacterStatType type)
        {
            int modifiersValue = Modifiers
                            .FindAll(modifier => modifier.CanModifyStatType(type))
                            .Sum(modifier => modifier.GetModifierValue(type));
            stat.Modifier = modifiersValue;
            return stat;
        }
    }
}
