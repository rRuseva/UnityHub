using UnityEngine;
using TMPro;
public class DeathMenu : MonoBehaviour {
    [SerializeField] private Score playerScore = null;
    [SerializeField] private TextMeshProUGUI endScore = null;
    private GameObject panel = null;

    void Start() {
        //playerScore = GameObject.FindWithTag("Player").GetComponent<Score>();
        //endScore = GetComponent<TextMeshProUGUI>();
        panel = gameObject.transform.Find("Panel").gameObject;
        playerScore.OnGameOverWithScore += ActivatePanel;
        DeactivatePanel();
    }

    private void OnDisable() {
        playerScore.OnGameOverWithScore -= ActivatePanel;
    }

    private void ActivatePanel(int score) {
        panel.SetActive(true);
        endScore.SetText("Score: " + score.ToString());
    }

    private void DeactivatePanel() {
        panel.SetActive(false);
    }
}