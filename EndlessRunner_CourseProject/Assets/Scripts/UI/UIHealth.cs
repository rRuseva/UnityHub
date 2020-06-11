using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour {
    [SerializeField] private Health playerHealth;
    private Text playerHealthText;
    private void Start() {
        playerHealth.OnHealthChanged += UpdateHealthInUI;
        playerHealthText = GetComponent<Text>();
    }
    private void OnDisable() {
        playerHealth.OnHealthChanged -= UpdateHealthInUI;
    }
    private void UpdateHealthInUI(int newHealth) {
        playerHealthText.text = newHealth.ToString();
    }
}
