using System;
using UnityEngine;

namespace PartTwo
{
    [Serializable]
    public class BaseStat
    {
        [SerializeField]
        public int baseStatValue;

        [SerializeField]
        public AnimationCurve baseStatModifier;
    }
}
