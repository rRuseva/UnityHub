using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour {
    [SerializeField] private Health playerHealth;
    //private Text playerHealthText;
    private TextMeshProUGUI playerHealthTextMesh = null;
    private void Start() {
        playerHealth.OnHealthChanged += UpdateHealthInUI;
        //playerHealthText = GetComponent<Text>();
        playerHealthTextMesh = GetComponent<TextMeshProUGUI>();
        playerHealthTextMesh.SetText("100");
    }
    private void OnDisable() {
        playerHealth.OnHealthChanged -= UpdateHealthInUI;
    }
    private void UpdateHealthInUI(int newHealth) {
        //playerHealthText.text = newHealth.ToString();
        playerHealthTextMesh.SetText(newHealth.ToString());
    }
}
