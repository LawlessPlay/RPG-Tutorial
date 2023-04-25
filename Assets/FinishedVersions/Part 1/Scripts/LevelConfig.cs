using UnityEngine;

namespace PartOne
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "PartOne/LevelConfig", order = 1)]
    public class LevelConfig : ScriptableObject
    {
        [Header("Animation Curve")]
        public AnimationCurve animationCurve;
        public int MaxLevel;
        public int MaxRequiredExp;


        //To be called when a entity levels up
        public int GetRequiredExp(int level)
        {
            int requiredExperience = Mathf.RoundToInt(animationCurve.Evaluate(Mathf.InverseLerp(0, MaxLevel, level)) * MaxRequiredExp);
            return requiredExperience;
        }
    }
}
