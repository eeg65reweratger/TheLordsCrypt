using UnityEngine;

namespace TLC {
    public class MinimapController : MonoBehaviour {
        public KeyCode minimapToggle = KeyCode.Tab;
        public GameObject minimapObject;

        private bool isToggled = false;

        public void ToggleMinimap() {
            if (isToggled)
                isToggled = false;
            else if (!isToggled)
                isToggled = true;

            //TODO: Stop rendering the minimap to its render texture when disabled
            minimapObject.SetActive(isToggled);
        }

        private void Update() {
            if (Input.GetKeyDown(minimapToggle))
                ToggleMinimap();
        }
    }
}
