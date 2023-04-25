using PartTwo;
using UnityEngine;
using UnityEngine.UI;

namespace PartOne
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

        // Start is called before the first frame update
        void Start()
        {
            CalculateRequiredExp();
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
    }
}
