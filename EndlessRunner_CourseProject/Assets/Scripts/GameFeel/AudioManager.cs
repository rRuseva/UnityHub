using UnityEngine;
public class AudioManager : MonoBehaviour {
    [SerializeField] private AudioSource backgroundMusic = null;
    [SerializeField] private AudioSource clickButtonSound = null;
    [SerializeField] private AudioSource crashTreeSound = null;
    [SerializeField] private AudioSource earnCoinSound = null;
    [SerializeField] private AudioSource eatCheeseSound = null;
    [SerializeField] private AudioSource jumpSound = null;
    [SerializeField] private AudioSource fallSound = null;

    private static AudioManager instance;
    private static bool SoundOn;

    private void Start() {
        instance = this;
        SoundOn = Prefs.IsSoundOn();
        InitBackgroundMusic(SoundOn);
    }

    private void OnEnable() {
        MuteButtonHandler.OnSoundStateChanged += SwitchBackgroundMusicOnOrOff;
        PauseButtonHandler.OnPauseStateChanged += ToggleBackgroundMusicOnPause;
    }

    private void OnDisable() {
        MuteButtonHandler.OnSoundStateChanged -= SwitchBackgroundMusicOnOrOff;
        PauseButtonHandler.OnPauseStateChanged -= ToggleBackgroundMusicOnPause;
    }

    public static void PlayBackgroundMusic() {
        if (SoundOn) { instance.backgroundMusic.Play(); }
    }

    public static void PlayClickButtonSound() {
        if (SoundOn) { instance.clickButtonSound.Play(); }
    }

    public static void PlayCrashTreeSound() {
        if (SoundOn) { instance.crashTreeSound.Play(); }
    }

    public static void PlayEarnCoinSound() {
        if (SoundOn) { instance.earnCoinSound.Play(); }
    }

    public static void PlayEatCheeseSound() {
        if (SoundOn) { instance.eatCheeseSound.Play(); }
    }

    public static void PlayJumpSound() {
        if (SoundOn) { instance.jumpSound.Play(); }
    }

    public static void PlayFallSound() {
        if (SoundOn) { instance.fallSound.Play(); }
    }

    private static void SwitchBackgroundMusicOnOrOff(bool newSoundOn) {
        Prefs.SetSoundOn(newSoundOn);
        SoundOn = newSoundOn;
        ToggleBackgroundMusic(newSoundOn);
    }

    private static void InitBackgroundMusic(bool newSoundOn) {
        SwitchBackgroundMusicOnOrOff(newSoundOn);
    }

    private static void ToggleBackgroundMusicOnPause(bool isPaused) {
        bool shouldSwitchOn = !isPaused;
        if ((shouldSwitchOn && SoundOn) || !shouldSwitchOn) {
            ToggleBackgroundMusic(shouldSwitchOn);
        }
    }

    public static void ToggleBackgroundMusic(bool shouldSwitchOn) {
        if (shouldSwitchOn) {
            instance.backgroundMusic.Play();
        } else {
            instance.backgroundMusic.Stop();
        }
    }
}
