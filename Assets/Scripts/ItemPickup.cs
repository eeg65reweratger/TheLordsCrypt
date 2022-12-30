using UnityEngine;
using TLC;

namespace TLC {
    public class ItemPickup : MonoBehaviour {
        public enum ItemType {
            SmallHealth,  //Health +10
            LargeHealth,  //Health +25
            BulletClip,   //Ammo +10
            AmmoBox,      //Ammo +50
            Note,         //Score +100
            Notebook,     //Score +500
            Artifact,     //Score +1000
            LifePotion,   //Life +1, Health =200
            Backpack,     //Full Ammo, Health, Score +5000
        }

        public ItemType currentItemType = ItemType.SmallHealth;

        private void OnTriggerEnter(Collider coll) {
            if (coll.CompareTag("Player")) {
                switch (currentItemType) {
                    case ItemType.SmallHealth:
                        if (StatsManager.currentHealth + 10 <= StatsManager.maxHealth) {
                            StatsManager.SetStat(0, StatsManager.currentHealth + 10);
                            LevelStats.currentItemCount++;
                            DebugControls.AddStatusText("Found Bandages! +10 Health");
                            gameObject.SetActive(false);
                        }
                        break;
                    case ItemType.LargeHealth:
                        if (StatsManager.currentHealth + 25 <= StatsManager.maxHealth) {
                            StatsManager.SetStat(0, StatsManager.currentHealth + 25);
                            LevelStats.currentItemCount++;
                            DebugControls.AddStatusText("Found Medikit! +25 Health");
                            gameObject.SetActive(false);
                        }
                        break;
                    case ItemType.BulletClip:
                        if (StatsManager.currentAmmo + 10 <= StatsManager.maxAmmo) {
                            StatsManager.SetStat(1, StatsManager.currentAmmo + 10);
                            LevelStats.currentItemCount++;
                            DebugControls.AddStatusText("Found Clip! +10 Ammo");
                            gameObject.SetActive(false);
                        }
                        break;
                    case ItemType.AmmoBox:
                        if (StatsManager.currentAmmo + 50 <= StatsManager.maxAmmo) {
                            StatsManager.SetStat(1, StatsManager.currentAmmo + 50);
                            LevelStats.currentItemCount++;
                            DebugControls.AddStatusText("Found Ammo Box! +50 Ammo");
                            gameObject.SetActive(false);
                        }
                        break;
                    case ItemType.Note:
                        if (StatsManager.currentScore + 100 <= StatsManager.maxScore) {
                            StatsManager.SetStat(3, StatsManager.currentScore + 100);
                            LevelStats.currentItemCount++;
                            DebugControls.AddStatusText("Found Note! +100 Points");
                            gameObject.SetActive(false);
                        }
                        break;
                    case ItemType.Notebook:
                        if (StatsManager.currentScore + 500 <= StatsManager.maxScore) {
                            StatsManager.SetStat(3, StatsManager.currentScore + 500);
                            LevelStats.currentItemCount++;
                            DebugControls.AddStatusText("Found Notebook! +500 Points");
                            gameObject.SetActive(false);
                        }
                        break;
                    case ItemType.Artifact:
                        if (StatsManager.currentScore + 1000 <= StatsManager.maxScore) {
                            StatsManager.SetStat(3, StatsManager.currentScore + 1000);
                            LevelStats.currentItemCount++;
                            DebugControls.AddStatusText("Found Artifact! +1000 Points");
                            gameObject.SetActive(false);
                        }
                        break;
                    case ItemType.LifePotion:
                        if (StatsManager.currentLives + 1 <= StatsManager.maxLives) {
                            StatsManager.SetStat(2, StatsManager.currentLives + 1);
                            StatsManager.SetStat(0, StatsManager.maxHealth);
                            LevelStats.currentItemCount++;
                            DebugControls.AddStatusText("Found Life Potion! Full Health, +1 Life");
                            gameObject.SetActive(false);
                        }
                        break;
                    case ItemType.Backpack:
                        if (StatsManager.currentScore + 5000 <= StatsManager.maxScore) {
                            StatsManager.SetStat(3, StatsManager.currentScore + 5000);
                            StatsManager.SetStat(0, StatsManager.maxHealth);
                            StatsManager.SetStat(1, StatsManager.maxAmmo);
                            LevelStats.currentItemCount++;
                            DebugControls.AddStatusText("Found Backpack! Max Health, Ammo, +5000 Points");
                            gameObject.SetActive(false);
                        }
                        break;
                    //just add more items here
                    //don't forget to add a new enum for your item
                }
            }
        }
    }
}
