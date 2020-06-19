using UnityEngine;

public class HUDController : MonoBehaviour {
    private Health playerHealth = null;

    private void Start() {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
        playerHealth.OnDie += Deactivate;
    }
    private void OnDisable() {
        playerHealth.OnDie -= Deactivate;
    }
    private void Activate() {
        gameObject.SetActive(true);
    }
    private void Deactivate() {
        gameObject.SetActive(false);
    }
}
