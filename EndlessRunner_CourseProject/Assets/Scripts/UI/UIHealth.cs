using TMPro;
using UnityEngine;

public class UIHealth : MonoBehaviour {
    [SerializeField] private Health playerHealth;
    private TextMeshProUGUI playerHealthTextMesh = null;
    private void Start() {
        playerHealth.OnHealthChanged += UpdateHealthInUI;
        playerHealthTextMesh = GetComponent<TextMeshProUGUI>();
        playerHealthTextMesh.SetText(Constants.MAX_HEALTH.ToString());
    }
    private void OnDisable() {
        playerHealth.OnHealthChanged -= UpdateHealthInUI;
    }
    private void UpdateHealthInUI(int newHealth) {
        playerHealthTextMesh.SetText(newHealth.ToString());
    }
}
