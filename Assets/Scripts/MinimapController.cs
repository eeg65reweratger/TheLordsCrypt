using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TLC.GUI {
    public class MinimapController : MonoBehaviour {
        public KeyCode minimapToggle = KeyCode.Tab;
        public GameObject minimapObject;

        private bool isToggled = false;

        public void ToggleMinimap() {
            if (isToggled)
                isToggled = false;
            else if (!isToggled)
                isToggled = true;

			minimapObject.SetActive(isToggled);
		}

        private void Update() {
            if (Input.GetKeyDown(minimapToggle))
                ToggleMinimap();
        }
    }
}
