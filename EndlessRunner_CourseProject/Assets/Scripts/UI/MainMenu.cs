using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour {
    [SerializeField] private Text maxScore;
    [SerializeField] private InputField playerName;

    private void Start() {
        InitializeMaxScore();
        InitializePlayerName();
    }

    private void InitializeMaxScore() {
        int maxScoreValue = PlayerPrefs.GetInt(Constants.MAX_SCORE_PLAYER_PREFS);
        maxScore.text = "Max score: " + maxScoreValue;
    }

    private void InitializePlayerName() {
        string playerNameValue = PlayerPrefs.GetString(Constants.PLAYER_NAME_PLAYER_PREFS);
        playerName.text = playerNameValue;
        playerName.onValidateInput +=
                delegate (string input, int charIndex, char addedChar) { return ValidateLetterOfUsername(addedChar); };
    }

    private char ValidateLetterOfUsername(char charToValidate) {
        return System.Char.IsLetterOrDigit(charToValidate) ? charToValidate : '\0';
    }

    private void OnDisable() {
        PlayerPrefs.SetString(Constants.PLAYER_NAME_PLAYER_PREFS, playerName.text);
    }
}
