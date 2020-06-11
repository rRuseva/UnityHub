using UnityEngine;

public class CameraFollower : MonoBehaviour {
    private Transform playerTransform;
    private float offset; // the offset in the scene before 'Play'

    private void Start() {
        playerTransform = GameObject.FindWithTag("Player").transform;
        offset = playerTransform.position.x - transform.position.x;
    }

    private void Update() {
        float newX = playerTransform.position.x - offset;
        float newY = transform.position.y;

        // Move forward fast
        transform.position = new Vector3(newX, newY, transform.position.z);

        // Move left/right smoothly after the player
        Vector3 newCameraPosition = new Vector3(newX, newY, playerTransform.position.z);
        transform.position = Vector3.Lerp(transform.position, newCameraPosition, 0.1f);
    }
}
