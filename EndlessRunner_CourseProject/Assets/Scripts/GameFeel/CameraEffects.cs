using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CameraEffects : MonoBehaviour {
    //[SerializeField] private WeaponController weaponController = null;
    [SerializeField] private Health playerHealth = null;
    [SerializeField] private Material sunDownMaterial = null;
    private bool isEnabledSunDownEffect = false;

    private void Start() {
        playerHealth.OnDie += EnableSunDownEffect;
        PauseButtonHandler.OnPauseStateChanged += ToggleSunDownEffect;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination) {
        if (!isEnabledSunDownEffect) {
            Graphics.Blit(source, destination);
            return;
        }
        Graphics.Blit(source, destination, sunDownMaterial);
    }

    private void OnDisable() {
        playerHealth.OnDie -= EnableSunDownEffect;
        PauseButtonHandler.OnPauseStateChanged -= ToggleSunDownEffect;
    }

    private void ToggleSunDownEffect(bool isEnabled) {
        isEnabledSunDownEffect = isEnabled;
    }

    private void EnableSunDownEffect() {
        isEnabledSunDownEffect = true;
    }
}
