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

# How to create custom modifiers



# How to use the Modifier Cycle Manager

# How to create and use the battle logs

# How to use the State Machine