using UnityEngine;

public class CameraFollower : MonoBehaviour {
    private Transform playerTransform;

    // the offset between the camera and the player before 'Play'
    private float offset;
    private void Start() {
        playerTransform = GameObject.FindWithTag(GameObjectsTags.PlayerTag).transform;
        offset = playerTransform.position.x - transform.position.x;
    }

    private void Update() {
        if (playerTransform != null) {
            Vector3 newCameraPosition = new Vector3(playerTransform.position.x - offset, transform.position.y, playerTransform.position.z);
            transform.position = Vector3.Lerp(transform.position, newCameraPosition, Time.deltaTime * 10.0f);
        }
    }
}
