using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour {
    [SerializeField] private Score playerScore;
    private Text playerScoreText;

    private void Start() {
        playerScore.OnScoreChanged += UpdateScoreInUI;
        playerScoreText = GetComponent<Text>();
    }
    private void OnDisable() {
        playerScore.OnScoreChanged -= UpdateScoreInUI;
    }
    private void UpdateScoreInUI(int newScore) {
        playerScoreText.text = newScore.ToString();
    }
}
