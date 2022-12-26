using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using static TLC.LevelStats;

namespace TLC {
    public class DebugControls : MonoBehaviour {
        [Header("Debug Keys")]
        public KeyCode toggleGhostMode = KeyCode.F1;
        public KeyCode toggleGUI = KeyCode.F2;
        public KeyCode toggleStats = KeyCode.F3;

        [Header("Required Game Objects")]
        public Canvas guiCanvas;
        public Text debugText;
        public GameObject playerObject;

        //private state variables
        [Header("Debug States")]
        [SerializeField]
        private bool isGUIHidden = false;
        [SerializeField]
        private bool isGhostModeToggled = false;
        [SerializeField]
        private bool isStatsToggled = false;

        public static GameObject statusGUI;
        public static GameObject statusTextPrefab;

        public static async void AddStatusText(string str, int fadeTime = 4) {
            GameObject statusText = Instantiate(statusTextPrefab, statusGUI.transform, false);
            Text txt = statusText.GetComponent<Text>();
            Animation ani = statusText.GetComponent<Animation>();
            txt.text = str;

            await Task.Delay(fadeTime * 1000);

            //i could do this in code but oh well
            ani.wrapMode = WrapMode.Once;
            ani.Play();

            Destroy(statusText, 1);
        }

        private void UpdateDebugText() {
            debugText.text = $"<color=#7fbfff>S</color>: {currentSecretCount} / {totalSecretCount}\r\n" +
                             $"<color=#ff0000>E</color>: {currentEnemyCount} / {totalEnemyCount}\r\n" +
                             $"<color=#fff31b>I</color>: {currentItemCount} / {totalItemCount}\r\n\r\n" +
                             $"FPS: {Mathf.Round(1f / Time.unscaledDeltaTime)}\r\n" +
                             $"FT: {(1f / Time.unscaledDeltaTime / 1000f).ToString("f2")}ms\r\n\r\n" +
                             $"Pos (X, Z): {playerObject.transform.position.x} / {playerObject.transform.position.z}\r\n" +
                             $"Rot: {playerObject.transform.rotation.y}";
        }

        private void Start() {
            statusGUI = GameObject.Find("StatusText");
            statusTextPrefab = Resources.Load<GameObject>("Prefabs/StatusAlert");
        }

        private void FixedUpdate() {
            Physics.IgnoreLayerCollision(3, 7, isGhostModeToggled);  //World
            Physics.IgnoreLayerCollision(3, 8, isGhostModeToggled);  //Secret
            Physics.IgnoreLayerCollision(3, 9, isGhostModeToggled);  //Enemy
            Physics.IgnoreLayerCollision(3, 10, isGhostModeToggled); //Deco
        }

        private void Update() {
            //toggle in-game UI
            if (Input.GetKeyDown(toggleGUI) && !isGUIHidden) {
                isGUIHidden = true;
                guiCanvas.enabled = false;
            } else if (Input.GetKeyDown(toggleGUI) && isGUIHidden) {
                isGUIHidden = false;
                guiCanvas.enabled = true;
            }

            //toggle noclip
            if (Input.GetKeyDown(toggleGhostMode) && isGhostModeToggled) {
                isGhostModeToggled = false;
                AddStatusText("Ghost Mode Disabled");
            } else if (Input.GetKeyDown(toggleGhostMode) && !isGhostModeToggled) {
                isGhostModeToggled = true;
                AddStatusText("Ghost Mode Enabled");
            }

            //toggle level stats
            if (Input.GetKeyDown(toggleStats) && !isStatsToggled) {
                isStatsToggled = true;
                InvokeRepeating("UpdateDebugText", 0f, .2f);
            } else if (Input.GetKeyDown(toggleStats) && isStatsToggled) {
                isStatsToggled = false;
                debugText.text = "";
                CancelInvoke();
            }
        }
    }
}
