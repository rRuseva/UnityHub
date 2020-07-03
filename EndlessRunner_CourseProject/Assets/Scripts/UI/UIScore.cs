using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour {
    [SerializeField] private Score playerScore = null;
    private TextMeshProUGUI playerScoreTextMesh = null;
    private Animator animator = null;

    private void Start() {
        playerScore.OnScoreChanged += UpdateScoreInUI;
        playerScoreTextMesh = GetComponent<TextMeshProUGUI>();
        animator = GetComponentInParent<Animator>();
    }
    private void OnDisable() {
        playerScore.OnScoreChanged -= UpdateScoreInUI;
    }
    private void UpdateScoreInUI(int newScore) {
        playerScoreTextMesh.SetText(newScore.ToString());
        animator.SetTrigger("start");
    }
}
