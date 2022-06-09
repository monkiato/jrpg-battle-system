# JRPG Battle System

.Net (Unity3d) tools to create JRPG battles

It's designed for Unity3d games, but it's not using any of the Unity components, and it doesn't provide any UI related logic, the tools are exclusively created for the battle system logic.

## Available components

* Character
* Character Stats
* Character Modifiers (character temporary states)
* Character Stats Modifiers (customizable stats modifiers to apply as side effects during attacks or different actions during the combat)
* Modifiers Cycle Manager (logic to automatically update modifiers based on custom game events like turn ends, player turn starts, player turn ends, etc)
* Battle Log
* Basic State Machine


## TODOs

* More interfaces to be able to customize more components
* Battle manager, to encapsulate all the different components (characters, modifier cycle manager, battle log, etc) and create an easier integration process
* Review state machine as this is a very simple implementation
