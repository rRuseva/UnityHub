using UnityEngine;

public class Coin : MonoBehaviour, IPooledObject {
    public void OnObjectSpawn() {
        Quaternion rotation = Quaternion.Euler(1, 5, 1);
        transform.rotation = rotation;
    }

    private void Update() {
        transform.Rotate(Vector3.up * (100 * Time.deltaTime));
    }
}
