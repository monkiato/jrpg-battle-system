namespace JRPGBattleSystem.Modifier
{
    public enum ModifierTrigger
    {
        None, //used when there's not an specific trigger, the modifier affects the character all time (for instanace, RES increase during one turn)
        CharacterAttackStarts,
        CharacterAttackEnds,
        CharacterDeffenseStarts,
        CharacterDeffenseEnds,
        CharacterTurnEnds,
        TurnStarts,
        TurnEnds,
        FightEnds,
        CharacterWins,
        CharacterLoses
    }
}
