using UnityEngine;

namespace TLC {
    public class LevelStats : MonoBehaviour {
        public static int totalEnemyCount = 0;
        public static int totalSecretCount = 0;
        public static int totalItemCount = 0;
        public static int totalShotsFired = 0;
        public static int totalShotsHit = 0;

        public static int currentEnemyCount = 0;
        public static int currentSecretCount = 0;
        public static int currentItemCount = 0;

        public void GetCounts(bool debug = false) {
            GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject[] allSecrets = GameObject.FindGameObjectsWithTag("Secret");
            GameObject[] allItems = GameObject.FindGameObjectsWithTag("Item");

            totalEnemyCount = allEnemies.Length;
            totalSecretCount = allSecrets.Length;
            totalItemCount = allItems.Length;

            if (debug)
                Debug.Log($"Total Enemies: {totalEnemyCount}, " +
                          $"Total Secrets: {totalSecretCount}, " +
                          $"Total Items: {totalItemCount}");
		}

        private void Start() {
            GetCounts(true);
        }
    }
}
