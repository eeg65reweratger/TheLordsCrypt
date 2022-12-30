using UnityEngine;
using UnityEngine.UI;

namespace TLC {
    public class StatsManager : MonoBehaviour {
        public enum StatType {
            Health,
            Ammo,
            Life,
            Score
        }

        public static int currentHealth = 100;
        public static int currentAmmo = 10;
        public static int currentScore = 0;
        public static int currentLives = 3;

        public static int maxHealth = 200;
        public static int maxAmmo = 300;
        public static int maxScore = 9999999;
        public static int maxLives = 10;

        private static Text healthUI;
        private static Text ammoUI;
        private static Text scoreUI;
        private static Text lifeUI;

        private void Start() {
            string path = "/Entities/PlayerEntity/PlayerCam/GUI/StatusBar/Stats/Aligner/StatsContainer";
            healthUI = GameObject.Find($"{path}/HealthCount").GetComponent<Text>();
            scoreUI = GameObject.Find($"{path}/ScoreCount").GetComponent<Text>();
            ammoUI = GameObject.Find($"{path}/AmmoCount").GetComponent<Text>();
            lifeUI = GameObject.Find($"{path}/LivesCount").GetComponent<Text>();

            healthUI.text = $"{currentHealth}";
            scoreUI.text = $"{currentScore}";
            ammoUI.text = $"{currentAmmo}";
            lifeUI.text = $"{currentLives}";
        }

        public static void SetStat(int stat, int value) {
            switch(stat) {
                case 0: //health
                    currentHealth = value;
                    bool isDamaged = value < currentHealth ? true : false;
                    healthUI.text = $"{currentHealth}";
                    break;
                case 1: //ammo
                    currentAmmo = value;
                    ammoUI.text = $"{currentAmmo}";
                    break;
                case 2: //lives
                    currentLives = value;
                    lifeUI.text = $"{currentLives}";
                    break;
                case 3: //score
                    currentScore = value;
                    scoreUI.text = $"{currentScore}";
                    break;
                default:
                    throw new System.ArgumentException("Incorrect parameter value.", nameof(stat));
            }
        }
    }
}
