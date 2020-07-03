using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System.Collections;

public class MainMenu : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI maxScoreTMP = null;
    [SerializeField] private InputField playerName = null;
    [SerializeField] private Button playButton = null;
    [SerializeField] private Button exitButton = null;
    [SerializeField] private UnityEvent playButtonEvent = null;
    [SerializeField] private UnityEvent exitButtonEvent = null;
    private void Start() {
        InitializeMaxScore();
        InitializePlayerName();
        InitializeButtons();
    }

    private void InitializeMaxScore() {
        int maxScoreValue = PlayerPrefs.GetInt(Constants.MAX_SCORE_PLAYER_PREFS);
        maxScoreTMP.SetText(Constants.MAX_SCORE_PREFIX + maxScoreValue.ToString());
    }

    private void InitializePlayerName() {
        string playerNameValue = PlayerPrefs.GetString(Constants.PLAYER_NAME_PLAYER_PREFS);
        playerName.text = playerNameValue;
        playerName.onValidateInput +=
                delegate (string input, int charIndex, char addedChar) { return ValidateLetterOfUsername(addedChar); };
    }

    private void InitializeButtons() {
        InitButton(playButton, playButtonEvent);
        InitButton(exitButton, exitButtonEvent);
    }

    private void InitButton(Button button, UnityEvent unityEvent) {
        button.onClick.AddListener(() => {
            AudioManager.PlayClickButtonSound();
            StartCoroutine(ExecuteEventAfterSound(unityEvent));
        });
    }

    private IEnumerator ExecuteEventAfterSound(UnityEvent unityEvent) {
        yield return new WaitForSeconds(0.3f);
        unityEvent?.Invoke();
    }

    private IEnumerator QuitApplicationAfterSound() {
        yield return new WaitForSeconds(0.3f);
        exitButtonEvent?.Invoke();
    }

    private char ValidateLetterOfUsername(char charToValidate) {
        return System.Char.IsLetterOrDigit(charToValidate) ? charToValidate : '\0';
    }

    private void OnDisable() {
        PlayerPrefs.SetString(Constants.PLAYER_NAME_PLAYER_PREFS, playerName.text);
    }
}
