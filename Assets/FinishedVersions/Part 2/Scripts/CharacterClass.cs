using UnityEngine;

namespace PartTwo
{
    [CreateAssetMenu(fileName = "CharacterClassNew", menuName = "PartTwo/CharacterClassNew")]
    public class CharacterClass : ScriptableObject
    {
        public BaseStat Health;
        public BaseStat Mana;
        public BaseStat Speed;
        public BaseStat Strenght;
        public BaseStat Intelligence;
    }
}
