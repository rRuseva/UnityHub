using UnityEngine;

public class HUDController : MonoBehaviour {
    [SerializeField] private Health playerHealth;

    private void Start() {
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
