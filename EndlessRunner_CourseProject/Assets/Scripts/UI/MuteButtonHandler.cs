using System;
using UnityEngine;
using UnityEngine.UI;

public class MuteButtonHandler : MonoBehaviour {
    public static Action<bool> OnSoundStateChanged;
    [SerializeField] Sprite soundOnIcon;
    [SerializeField] Sprite soundOffIcon;
    private Button muteButton;
    private Image muteImage;
    private readonly Color buttonColor = new Color(0.2039216f, 0.5843138f, 0.2745098f, 1f);

    void Start() {
        muteButton = GetComponent<Button>();
        muteImage = GetComponent<Image>();
        InitMuteButton();
    }

    void ToggleMute() {
        AudioManager.PlayClickButtonSound();
        bool newSoundOn = !Prefs.IsSoundOn();
        ChangeMuteButtonIcon(newSoundOn);
        OnSoundStateChanged?.Invoke(newSoundOn);
    }

    private void InitMuteButton() {
        muteButton.onClick.AddListener(ToggleMute);
        bool soundOn = Prefs.IsSoundOn();
        ChangeMuteButtonIcon(soundOn);
    }

    private void ChangeMuteButtonIcon(bool soundOn) {
        if (soundOn) {
            muteImage.sprite = soundOnIcon;
            muteImage.color = buttonColor;
        } else {
            muteImage.sprite = soundOffIcon;
            muteImage.color = buttonColor;
        }
    }
}
