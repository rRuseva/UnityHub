using UnityEngine;

public class Prefs {
    public static bool IsSoundOn() {
        int isSoundOnIntValue =
        !PlayerPrefs.HasKey(Constants.SOUND_ON_PLAYER_PREFS) ?
             Constants.SOUND_ON_DEFAULT_VALUE :
           PlayerPrefs.GetInt(Constants.SOUND_ON_PLAYER_PREFS);

        return isSoundOnIntValue == 1;
    }

    public static void SetSoundOn(bool newSoundOn) {
        int newSoundOnIntValue = newSoundOn ? 1 : 0;
        PlayerPrefs.SetInt(Constants.SOUND_ON_PLAYER_PREFS, newSoundOnIntValue);
    }
}