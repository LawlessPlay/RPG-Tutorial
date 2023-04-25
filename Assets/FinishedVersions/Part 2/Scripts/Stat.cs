using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartTwo
{
    public class Stat
    {
        public StatKeys statKey;
        public int statValue;

        public Stat(StatKeys statKey, int statValue)
        {
            this.statKey = statKey;
            this.statValue = statValue;
        }


    }

    public enum StatKeys
    {
        Health,
        Mana,
        Speed,
        Strenght,
        Intelligence,
        CurrentHealth,
        CurrentMana
    }
}