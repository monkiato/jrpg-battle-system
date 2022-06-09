﻿namespace JRPGBattleSystem
{
    public enum ModifierTrigger
    {
        None, //used when there's not an specific trigger, the modifier affects the character all time (for instanace, RES increase during one turn)
        CharacterAttackStarts,
        CharacterAttackEnds,
        CharacterEndOfAttackStarts,
        CharacterEndOfAttackEnds,
        TurnStarts,
        TurnEnds,
        FightEnds,
        CharacterWins,
        CharacterLoses
    }
}