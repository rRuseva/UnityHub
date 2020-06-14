using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CameraEffects : MonoBehaviour
{
    //[SerializeField] private WeaponController weaponController = null;
    [SerializeField] private Health playerHealth = null;
    [SerializeField] private Material sunDownMaterial = null;
    private bool isDead = false;

    private void OnRenderImage(RenderTexture source, RenderTexture destination) {
        playerHealth.OnDie += PlayerHealth_OnDie;

        if (!isDead) {
            Graphics.Blit(source, destination);
            return;
        }
        Graphics.Blit(source, destination, sunDownMaterial);
    }

    private void PlayerHealth_OnDie() {
        isDead = true;
    }
}
