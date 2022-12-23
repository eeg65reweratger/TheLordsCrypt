using UnityEngine;
using static TLC.LevelStats;

namespace TLC {
    [RequireComponent(typeof(CharacterController))]
    [AddComponentMenu("Custom/Player/Player Controller")]
    public class PlayerController : MonoBehaviour {
        [Header("Required Components")]
        public CharacterController charController;

        [Header("Movement Settings")]
        public float playerSpeed = 4f;
        public float sprintModifier = 2f;
        public float mouseSpeed = 1f;
        public float keyboardSpeed = 2f;
        public bool alwaysRun = false;

        private void Start() {
            //automatically lock our cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void FireShot() {
            int layerMask = 1 << 3;
            layerMask = ~layerMask;

            Vector3 shotOrigin = transform.position;
            Vector3 shotDirection = transform.TransformDirection(Vector3.forward);

            RaycastHit hit;
            if (Physics.Raycast(shotOrigin, shotDirection, out hit, 50f, layerMask)) {
                totalShotsFired++;
                //Debug.DrawRay(shotOrigin + new Vector3(0, .5f, 0), shotDirection * 50f, Color.red, 4f);
            }
        }

        private void FixedUpdate() {
            //*very* basic movement
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || alwaysRun)
                charController.Move(transform.TransformDirection(move) * Time.deltaTime * (playerSpeed * sprintModifier));
            else
                charController.Move(transform.TransformDirection(move) * Time.deltaTime * playerSpeed);

            //mouse rotation
            transform.Rotate(0, (Input.GetAxis("Mouse X") * mouseSpeed), 0);
            //or...
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Rotate(0, -keyboardSpeed, 0);
            else if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(0, keyboardSpeed, 0);

            //lock our y pos so we never go up or down
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);

            //fire controls
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl))
                FireShot();
        }
    }
}
