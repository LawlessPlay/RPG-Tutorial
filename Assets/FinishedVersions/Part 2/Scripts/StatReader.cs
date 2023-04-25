using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PartTwo
{
    public class StatReader : MonoBehaviour
    {
        public Entity character;
        public StatKeys statKey;

        private Text statText;
        public Text differenceText;

        private int currentValue;
        private int currentLevel;



        // Start is called before the first frame update
        void Start()
        {
            statText = gameObject.GetComponent<Text>();
            Stat stat = character.GetStat(statKey);
            currentValue = stat.statValue;
            currentLevel = character.level;
            statText.text = statKey.ToString() + ": " + stat.statValue;
        }

        // Update is called once per frame
        void Update()
        {
            UpdateText();
        }

        public void UpdateText()
        {
            if (currentLevel != character.level)
            {
                currentLevel = character.level;
                Stat stat = character.GetStat(statKey);
                int difference = stat.statValue - currentValue;

                StopAllCoroutines();
                if (difference > 0)
                {
                    differenceText.text = "+" + difference;
                    differenceText.color = new Color(0, 255, 0, 255);
                    //StartCoroutine
                    StartCoroutine(TickTextUp(difference));
                }
                else if (difference < 0)
                {
                    differenceText.text = "-" + difference;
                    differenceText.color = new Color(255, 0, 0, 255);
                    //StartCoroutine
                    StartCoroutine(TickTextDown(difference));
                }
                else
                {
                    differenceText.text = difference.ToString();
                    differenceText.color = new Color(255, 0, 0, 255);
                    StartCoroutine(TickTextUp(difference));
                }
            }
        }

        public IEnumerator TickTextUp(int difference)
        {
            yield return new WaitForSeconds(1f);
            while (difference > 0)
            {
                difference--;
                currentValue++;
                differenceText.text = "+" + difference.ToString();
                statText.text = statKey.ToString() + ": " + currentValue;

                yield return new WaitForSeconds(0.1f);
            }

            differenceText.text = "";
        }

        public IEnumerator TickTextDown(int difference)
        {
            yield return new WaitForSeconds(1f);
            while (difference < 0)
            {
                difference++;
                currentValue--;
                differenceText.text = "-" + difference.ToString();
                statText.text = statKey.ToString() + ": " + currentValue;

                yield return new WaitForSeconds(0.1f);
            }

            differenceText.text = "";
        }
    }
}
