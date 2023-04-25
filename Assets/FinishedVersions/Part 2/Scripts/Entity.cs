using UnityEngine;
using UnityEngine.UI;

namespace PartTwo
{
    public class Entity : MonoBehaviour
    {
        public int level;
        public int experience;
        public int requireExperience;

        public LevelConfig levelConfig;

        public Image experienceBar;
        public Text experienceText;
        public Text LevelText;

        public CharacterClass characterClass;

        [HideInInspector]
        public StatsContainer statsContainer;

        // Start is called before the first frame update
        void Awake()
        {
            CalculateRequiredExp();
            SetStats();
        }

        //Increase EXP of an Entity
        public void IncreaseExp(int value)
        {
            experience += value;
            UpdateUI();

            if (experience >= requireExperience)
            {
                while (experience >= requireExperience)
                {
                    experience -= requireExperience;
                    LevelUp();
                }
            }
        }

        //Level Up an Entity
        public void LevelUp()
        {
            level++;
            LevelUpStats();
            CalculateRequiredExp();
        }

        //Get new RequiredEXP
        public void CalculateRequiredExp()
        {
            requireExperience = levelConfig.GetRequiredExp(level);
            UpdateUI();
        }

        //Update the exp UI
        private void UpdateUI()
        {
            experienceBar.fillAmount = ((float)experience / (float)requireExperience);
            LevelText.text = "Level: " + level;
            experienceText.text = experience + " / " + requireExperience + " Exp";
        }

        public void SetStats()
        {
            if (statsContainer == null)
            {
                statsContainer = new StatsContainer(characterClass);
            }

            for (int i = 0; i < level; i++)
            {
                LevelUpStats();
            }
        }

        public void LevelUpStats()
        {
            int maxIncrease = 10;
            float v = Random.Range(0f, 1f);
            statsContainer.Health.statValue += Mathf.RoundToInt(characterClass.Health.baseStatModifier.Evaluate(v) * maxIncrease);
            v = Random.Range(0f, 1f);
            statsContainer.Mana.statValue += Mathf.RoundToInt(characterClass.Mana.baseStatModifier.Evaluate(v) * maxIncrease);
            v = Random.Range(0f, 1f);
            statsContainer.Strenght.statValue += Mathf.RoundToInt(characterClass.Strenght.baseStatModifier.Evaluate(v) * maxIncrease);
            v = Random.Range(0f, 1f);
            statsContainer.Speed.statValue += Mathf.RoundToInt(characterClass.Speed.baseStatModifier.Evaluate(v) * maxIncrease);
            v = Random.Range(0f, 1f);
            statsContainer.Intelligence.statValue += Mathf.RoundToInt(characterClass.Intelligence.baseStatModifier.Evaluate(v) * maxIncrease);


            statsContainer.CurrentHealth.statValue = statsContainer.Health.statValue;
            statsContainer.CurrentMana.statValue = statsContainer.Mana.statValue;
        }

        public Stat GetStat(StatKeys statName)
        {
            switch (statName)
            {
                case StatKeys.Health:
                    return statsContainer.Health;
                case StatKeys.Mana:
                    return statsContainer.Mana;
                case StatKeys.Strenght:
                    return statsContainer.Strenght;
                case StatKeys.Speed:
                    return statsContainer.Speed;
                case StatKeys.Intelligence:
                    return statsContainer.Intelligence;
                default:
                    return statsContainer.Health;
            }
        }
    }
}

