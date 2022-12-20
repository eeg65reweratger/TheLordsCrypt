using UnityEngine;

namespace TLC {
    public class WallMover : MonoBehaviour {
        private bool isMoving = false;
        private BoxCollider boxColl;
        private Vector3 movePos;
        private Vector3 curPos;
        private float moveMag;

        private void Start() {
            boxColl = gameObject.AddComponent<BoxCollider>();
            boxColl.center = new Vector3(1.5f, 0, 0);
            boxColl.size = new Vector3(1, 2, 2);
            boxColl.isTrigger = true;
            movePos = new Vector3(transform.position.x - 4, transform.position.y, transform.position.z);
        }

        private void Update() {
            if (isMoving && moveMag > 0.0001f) {
                transform.Translate(-transform.right * Time.deltaTime);
                curPos = transform.position;
            } else if (moveMag <= 0.0001f)
                isMoving = false;

            moveMag = (movePos - curPos).sqrMagnitude;
        }

        private void OnTriggerStay(Collider coll) {
            if (Input.GetKeyDown(KeyCode.E) && !isMoving) {
                isMoving = true;
                Destroy(boxColl, 0);
            }
        }
    }
}
