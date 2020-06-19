using UnityEngine;

public class CameraFollower : MonoBehaviour {
    private Transform playerTransform;

    // the offset between the camera and the player before 'Play'
    private float offset;
    private void Start() {
        playerTransform = GameObject.FindWithTag("Player").transform;
        offset = playerTransform.position.x - transform.position.x;
    }

    private void Update() {
        if (playerTransform != null) {
            float newX = playerTransform.position.x - offset;
            float newY = transform.position.y;

            // Move forward fast
            transform.position = new Vector3(newX, newY, transform.position.z);

            // Move left/right smoothly after the player
            Vector3 newCameraPosition = new Vector3(newX, newY, playerTransform.position.z);
            transform.position = Vector3.Lerp(transform.position, newCameraPosition, 0.1f);
        }
    }
}
