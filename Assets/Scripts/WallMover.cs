using UnityEngine;
using static TLC.DebugControls;
using static TLC.LevelStats;

namespace TLC {
    public class WallMover : MonoBehaviour {
        private bool isMoving = false;
        private BoxCollider boxColl;
        private Vector3 movePos;
        private Vector3 curPos;
        private float moveMag;
        public Transform destElem;
        public Vector3 destPos;
        public AudioSource movingSound;
        public AudioSource secretSound;

        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, destElem.position);
            Gizmos.color = new Color(1f, 1f, 0f, .5f);
            Gizmos.DrawCube(destElem.position, new Vector3(2f, 2f, 2f));
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position, new Vector3(2f, 2f, 2f));
        }

        private void Start() {
            boxColl = gameObject.AddComponent<BoxCollider>();
            boxColl.center = new Vector3(0, 0, 0);
            boxColl.size = new Vector3(3, 3, 3);
            boxColl.isTrigger = true;
            destPos = destElem.position;
        }

        private void FixedUpdate() {
            float step = 1.5f * Time.deltaTime;

            if (isMoving && moveMag > 0.00001f) {
                transform.position = Vector3.MoveTowards(transform.position, destPos, step);
                curPos = transform.position;
            } else if (isMoving && moveMag <= 0.00001f) {
                movingSound.Pause();
                movingSound.Stop();
                if (!movingSound.isPlaying)
                    secretSound.Play();
                isMoving = false;
            }

            moveMag = (destPos - curPos).sqrMagnitude;
        }

        private void OnTriggerStay(Collider coll) {
            if (Input.GetKeyDown(KeyCode.E) && !isMoving) {
                isMoving = true;
                movingSound.Play();
                Destroy(boxColl, 0);
                currentSecretCount++;
                AddStatusText("Secret Discovered!");
            }
        }
    }
}
