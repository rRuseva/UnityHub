using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour {
    [SerializeField] private Score playerScore;
    //private Text playerScoreText;
    private TextMeshProUGUI playerScoreTextMesh = null;

    private void Start() {
        playerScore.OnScoreChanged += UpdateScoreInUI;
        //playerScoreText = GetComponent<Text>();
        playerScoreTextMesh = GetComponent<TextMeshProUGUI>();
    }
    private void OnDisable() {
        playerScore.OnScoreChanged -= UpdateScoreInUI;
    }
    private void UpdateScoreInUI(int newScore) {
        //playerScoreText.text = newScore.ToString();
        playerScoreTextMesh.SetText(newScore.ToString());
    }
}
