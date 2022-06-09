using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ModifiersManagerTests
    {
        private ModifiersManager manager;

        [SetUp]
        public void SetUp()
        {
            manager = new ModifiersManager();
        }

        /*
         * Stun:
         *  - added during a fighting action like deffending
         *  - duration X turns for that player
         *  - remove after the player has passed those turns.
         *  
         * Bleeding:
         *  - added during a deffending action
         *  - duration x turns for that player
         *  - remove after player has passed those turns
         *  
         * Shield effect:
         *  - added during player action execution
         *  - duration 1 turn generally, or after the player is attacked
         *  - remove during next player turn or when the player is attacked before that happens
         *  
         * Taunt:
         *  - added during player action execution or as an effect of a friendly character
         *  - duration 1 turn generally
         *  - remove during next player turn
         *  - all enemy characters can target taunted players only 
         * 
         * Others:
         * Increase stat (HP, STR, DEX, etc) x % during one turn
         * % chance to ignore target RES stat
         * 
         * CharacterStatModifier (increase, decrease, during attack or deffense, shield, etc)
         * CharacterStateModifier  (bleeding, stun, taunt)
         */
    }

    internal class ModifiersManager
    {
        public ModifiersManager()
        {
        }
    }
}
