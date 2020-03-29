

using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform targetPlayer; 
    public float smoothSpeed = 0.775f;

    private Vector3 cameraOffset = new Vector3(0, 3, -9);

    void LateUpdate() {
        Vector3 desiredPosition = targetPlayer.position + cameraOffset; // + 3*Vector3.up ;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition; 
    }
}
