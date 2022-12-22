using UnityEngine;

namespace TLC {
    public class WallMover : MonoBehaviour {
        private bool isMoving = false;
        private BoxCollider boxColl;
        private Vector3 movePos;
        private Vector3 curPos;
        private float moveMag;
        public Transform destElem;
        public AudioSource audioSource;

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
            boxColl.center = new Vector3(1.5f, 0, 0);
            boxColl.size = new Vector3(1, 2, 2);
            boxColl.isTrigger = true;
        }

        private void Update() {
            float step = 1.5f * Time.deltaTime;

            if (isMoving && moveMag > 0.00001f) {
                transform.position = Vector3.MoveTowards(transform.position, destElem.position, step);
                curPos = transform.position;
            } else if (moveMag <= 0.00001f) {
                isMoving = false;
                audioSource.Stop();
            }

            moveMag = (destElem.position - curPos).sqrMagnitude;
		}

        private void OnTriggerStay(Collider coll) {
            if (Input.GetKeyDown(KeyCode.E) && !isMoving) {
                isMoving = true;
				audioSource.Play();
				Destroy(boxColl, 0);
                LevelStats.currentSecretCount++;
                Debug.Log($"Found Secret! {LevelStats.currentSecretCount} out of {LevelStats.totalSecretCount}");
            }
        }
    }
}
