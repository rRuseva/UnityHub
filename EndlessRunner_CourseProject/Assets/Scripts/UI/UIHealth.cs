using TMPro;
using UnityEngine;

public class UIHealth : MonoBehaviour {
    [SerializeField] private Health playerHealth;
    private TextMeshProUGUI playerHealthTextMesh = null;

    private Animator animator;

    private void Start() {
        playerHealth.OnHealthChanged += UpdateHealthInUI;
        playerHealthTextMesh = GetComponent<TextMeshProUGUI>();
        playerHealthTextMesh.SetText(Constants.MAX_HEALTH.ToString());

        animator=GetComponentInParent<Animator>();
    }
    private void OnDisable() {
        playerHealth.OnHealthChanged -= UpdateHealthInUI;
    }
    private void UpdateHealthInUI(int newHealth) {
        playerHealthTextMesh.SetText(newHealth.ToString());
        animator.SetTrigger("start");
    }
}
