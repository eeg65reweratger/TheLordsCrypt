/* PlayerController.cs - Controls player movement and stats
 * Zachary Fetters <zachfett@protonmail.com> - Dec 15 2022
 * Copyright © 2022, LowPolySeagull (Zachary Fetters)
 */

using UnityEngine;

namespace TLC.Player {
    [RequireComponent(typeof(CharacterController))]
    [AddComponentMenu("Custom/Player/Player Controller")]
    public class PlayerController : MonoBehaviour {
        [Header("Required Components")]
        public CharacterController charController;

        [Header("Movement Settings")]
        public float playerSpeed = 4f;
        public float mouseSpeed = 1f;

        private void Update() {
            //*very* basic movement
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            charController.Move(transform.TransformDirection(move) * Time.deltaTime * playerSpeed);

            //mouse rotation
            transform.Rotate(0, (Input.GetAxis("Mouse X") * mouseSpeed), 0);
        }
    }
}
