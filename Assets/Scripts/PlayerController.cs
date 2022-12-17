/* PlayerController.cs - Controls player movement and stats
 * Zachary Fetters <zachfett@protonmail.com> - Dec 15 2022
 * Copyright (c) 2022, LowPolySeagull (Zachary Fetters)
 */

using UnityEngine;

namespace TLC.Player
{
    [RequireComponent(typeof(CharacterController))]
    [AddComponentMenu("Custom/Player/Player Controller")]
    public class PlayerController : MonoBehaviour
    {
        [Header("Required Components")]
        public CharacterController charController;

        [Header("Movement Settings")]
        public float playerSpeed = 4f;
        public float sprintModifier = 2f;
        public float mouseSpeed = 1f;

        public static bool isGhostModeToggled = false;

        private void Update()
        {
            //*very* basic movement
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                charController.Move(transform.TransformDirection(move) * Time.deltaTime * (playerSpeed * sprintModifier));
            else
                charController.Move(transform.TransformDirection(move) * Time.deltaTime * playerSpeed);

            //mouse rotation
            transform.Rotate(0, (Input.GetAxis("Mouse X") * mouseSpeed), 0);
            //or...
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Rotate(0, -mouseSpeed, 0);
            else if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(0, mouseSpeed, 0);

            //debug key actions
            if (Input.GetKeyDown(KeyCode.F1) && isGhostModeToggled)
            {
                isGhostModeToggled = false;
                Physics.IgnoreLayerCollision(0, 3, false);
            } else if (Input.GetKeyDown(KeyCode.F1) && !isGhostModeToggled)
            {
                isGhostModeToggled = true;
                Physics.IgnoreLayerCollision(0, 3, true);
            }
        }
    }
}
