using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MainMenu : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI maxScoreTMP = null;
    [SerializeField] private InputField playerName;
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;

    private void Start() {
        InitializeMaxScore();
        InitializePlayerName();
        InitializeButtons();
    }

    private void InitializeMaxScore() {
        int maxScoreValue = PlayerPrefs.GetInt(Constants.MAX_SCORE_PLAYER_PREFS);
        maxScoreTMP.SetText("Max score: " + maxScoreValue.ToString());
    }

    private void InitializePlayerName() {
        string playerNameValue = PlayerPrefs.GetString(Constants.PLAYER_NAME_PLAYER_PREFS);
        playerName.text = playerNameValue;
        playerName.onValidateInput +=
                delegate (string input, int charIndex, char addedChar) { return ValidateLetterOfUsername(addedChar); };
    }

    private void InitializeButtons() {
        playButton.onClick.AddListener(() => {
            AudioManager.PlayClickButtonSound();
        });

        exitButton.onClick.AddListener(() => {
            AudioManager.PlayClickButtonSound();
        });
    }

    private char ValidateLetterOfUsername(char charToValidate) {
        return System.Char.IsLetterOrDigit(charToValidate) ? charToValidate : '\0';
    }

    private void OnDisable() {
        PlayerPrefs.SetString(Constants.PLAYER_NAME_PLAYER_PREFS, playerName.text);
    }
}
