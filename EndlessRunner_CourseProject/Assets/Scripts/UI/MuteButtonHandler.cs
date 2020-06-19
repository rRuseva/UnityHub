using System;
using UnityEngine;
using UnityEngine.UI;

public class MuteButtonHandler : MonoBehaviour {
    public static Action<bool> OnSoundStateChanged;
    [SerializeField] Sprite soundOnIcon;
    [SerializeField] Sprite soundOffIcon;
    private Button muteButton;
    private Image muteImage;

    void Start() {
        muteButton = GetComponent<Button>();
        muteImage = GetComponent<Image>();
        InitMuteButton();
    }

    void ToggleMute() {
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
        } else {
            muteImage.sprite = soundOffIcon;
        }
    }
}
