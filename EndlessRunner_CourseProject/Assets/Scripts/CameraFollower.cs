using UnityEngine;

public class CameraFollower : MonoBehaviour {
    private Transform playerTransform;
    private float offset; // the offset in the scene before 'Play'

    private void Start() {
        playerTransform = GameObject.FindWithTag("Player").transform;
        offset = playerTransform.position.x - transform.position.x;
    }

    private void Update() {
        Vector3 newCameraPosition = new Vector3(playerTransform.position.x - offset, transform.position.y, playerTransform.position.z);
        transform.position = Vector3.Lerp(transform.position, newCameraPosition, 0.1f);
    }
}
