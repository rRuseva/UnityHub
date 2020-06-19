using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour {
    [SerializeField] private Score playerScore;
    private TextMeshProUGUI playerScoreTextMesh = null;

    private void Start() {
        playerScore.OnScoreChanged += UpdateScoreInUI;
        playerScoreTextMesh = GetComponent<TextMeshProUGUI>();
    }
    private void OnDisable() {
        playerScore.OnScoreChanged -= UpdateScoreInUI;
    }
    private void UpdateScoreInUI(int newScore) {
        playerScoreTextMesh.SetText(newScore.ToString());
    }
}
