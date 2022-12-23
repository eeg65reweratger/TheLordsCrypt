using UnityEngine;

namespace TLC {
    public class FramerateController : MonoBehaviour {
        public int maxFramerate;
        public bool vSyncEnabled = false;

        private void Awake() {
            //set the default max framerate to the monitor refresh rate
            maxFramerate = Screen.currentResolution.refreshRate;
        }

        private void Update() {
            if (maxFramerate > 0 && !vSyncEnabled) //0 or -1 means no frame cap
                Application.targetFrameRate = maxFramerate;
            else if (vSyncEnabled) //cant do both so if vsync is enabled, enable that over the frame cap
                QualitySettings.vSyncCount = 1;
            else if (maxFramerate < 0 && !vSyncEnabled) //if both are disabled, unlimit the framerate
                Application.targetFrameRate = 9999;
        }
    }
}
