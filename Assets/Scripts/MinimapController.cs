using UnityEngine;

namespace TLC {
    public class MinimapController : MonoBehaviour {
        public KeyCode minimapToggle = KeyCode.Tab;
        public GameObject minimapObject;
        public RenderTexture minimapTex;

        private bool isToggled = false;

        public void ToggleMinimap() {
            if (isToggled) {
                isToggled = false;
                minimapTex.Release(); //unity rec's releasing render tex's when not used
            } else if (!isToggled)
                isToggled = true;

            minimapObject.SetActive(isToggled);
        }

        private void Update() {
            if (Input.GetKeyDown(minimapToggle))
                ToggleMinimap();
        }
    }
}
