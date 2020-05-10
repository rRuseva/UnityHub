using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class RedPulsingEffect : MonoBehaviour
{
    [SerializeField] private WeaponController weaponController = null;
    [SerializeField] private Material redPulsingEffectMaterial = null;

    private void OnRenderImage(RenderTexture source, RenderTexture destination) {
        //_ScreenParams
        if (weaponController.getAmmo() > 2) {
            Graphics.Blit(source, destination);
            return;
        }

        Graphics.Blit(source, destination, redPulsingEffectMaterial);
    }
}
