# How to create battle characters

Create a based character using core components:

```
int HP = 50;
int STR = 15;
int RES = 10;
int DEX = 5;

//create stats object
var stats = new CharacterStats(HP, STR, RES, DEX);

var character = new Character(stats);

//basic checks
character.Stats.HP.MaxValue; // max HP
character.Stats.HP.Value;    // current HP (including modifiers)
character.Stats.HP.NetValue; // current HP (without modifiers)

//for level up, update stats
character.UpdateStats(new CharacterStats(...));
```

Character class can be easily extended to provide customized features.

# Modifiers

Modifiers are applied to the character or their stats, to indicate they have some additional changes to the base state.

The framework provides two basic modifiers:

- `StateModifier` applicable to the character only

- `StatsModifier` applicable to a single stat.

Both `StateModifier` and `StatsModifier` are concrete classes that can be instantiated directly if no extra functionality is required.

For example:

```
    var stateModifier = new StateModifier(
        CharacterState.Confused,
        ModifierTarget.Opponent,
        ModifierTrigger.None //immediately
        ModifierTrigger.CharacterAttackEnds //removed at the end of the character turn
    );
```

# How to create custom modifiers

This is an example of a custom "bleeding" modifier making use of the base StateModifier
```
    public class BleedModifier : StateModifier
    {
        public float BleedPercentage { get; }

        public BleedModifier(float bleedPercentage) :
            base(CharacterState.Bleed, ModifierTarget.Opponent, ModifierTrigger.None, ModifierTrigger.CharacterAttackEnds)
        {
            this.BleedPercentage = bleedPercentage;
        }
    }
}
```

# How to use the Modifier Cycle Manager

All modifiers must be applied through the modifier cycle manager, required to keep track of the battle state changes and update character and stats automatically across the different turns.

```
var modifierCycleManager = new ModifierCycleManager();
```

```
//Register a modifier
var stateModifier = new StateModifier(
        CharacterState.Confused,
        ModifierTarget.Opponent,
        ModifierTrigger.None //immediately
        ModifierTrigger.CharacterAttackEnds //removed at the end of the character turn
    );

modifierCycleManager.Register(stateModifier, opponent);
```

```
//add triggers on the different battle states
modifierCycleManager.Trigger(ModifierTrigger.TurnEnds);
```

# How to create and use the battle logs

First declare your log types:

```
public enum BattleLogTypes
{
    CharacterUsesOffensiveAction,
    CharacterUsesDeffensiveAction,
    CharacterReceivesDamage,
    ModifierApplied,
    ModifierRemoved,
    CharacterBleeding,
    ...
}
```

Then, create the BattleLog instance:

```
var battleLog = ew BattleLog<BattleLogTypes>();
```

And start adding logs based on events ocurring during the battle:

```
//it's recommended to create custom classes to enrich logs
public class BattleLogEntryCharacterReceivesDamage : BattleLogEntry<BattleLogTypes>
{
    public BattleLogEntryCharacterReceivesDamage(Character character, int damage) : base(BattleLogTypes.CharacterReceivesDamage)
    {
        Character = character;
        Damage = damage;
    }

    public Character Character { get; }
    public int Damage { get; }
}
```

```
//push new log
battleLog.Push(
    new BattleLogEntryCharacterReceivesDamage(opponent, damage));
```
