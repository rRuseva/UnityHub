using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour {
    [SerializeField] private Health playerHealth;
    private Text playerHealthText;
    //private TextMeshPro playerHealthTextMesh;
    private void Start() {
        playerHealth.OnHealthChanged += UpdateHealthInUI;
        playerHealthText = GetComponent<Text>();
        //playerHealthTextMesh = GetComponent<TextMeshPro>();
        //playerHealthTextMesh.text = "100";
    }
    private void OnDisable() {
        playerHealth.OnHealthChanged -= UpdateHealthInUI;
    }
    private void UpdateHealthInUI(int newHealth) {
        playerHealthText.text = newHealth.ToString();
        //playerHealthTextMesh.text = newHealth.ToString();
    }
}
