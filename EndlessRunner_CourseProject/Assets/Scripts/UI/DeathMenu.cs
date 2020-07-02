using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DeathMenu : MonoBehaviour {
    [SerializeField] private Health playerHealth = null;
    [SerializeField] private TextMeshProUGUI endScore = null;
    private GameObject panel = null;
    private Button playButton;
    private Button menuButton;
    private Button exitButton;

    void Start() {
        panel = gameObject.transform.Find(GameObjectsNames.DeathMenuPanelName).gameObject;
        playerHealth.OnDieWithScore += ActivatePanel;
        DeactivatePanel();
        InitButtons();
    }

    private void OnDisable() {
        playerHealth.OnDieWithScore -= ActivatePanel;
    }

    private void ActivatePanel(int score) {
        panel.SetActive(true);
        endScore.SetText("Score: " + score.ToString());
    }

    private void DeactivatePanel() {
        panel.SetActive(false);
    }

    private void InitButtons() {
        playButton = panel.transform.Find(GameObjectsNames.DeathMenuPlayButtonName).GetComponent<Button>();
        AddSoundToClickListener(playButton);
        menuButton = panel.transform.Find(GameObjectsNames.DeathMenuMenuButtonName).GetComponent<Button>();
        AddSoundToClickListener(menuButton);
        exitButton = panel.transform.Find(GameObjectsNames.DeathMenuExitButtonlName).GetComponent<Button>();
        AddSoundToClickListener(exitButton);
    }

    private void AddSoundToClickListener(Button button) {
        button.onClick.AddListener(() => {
            AudioManager.PlayClickButtonSound();
        });
    }
}