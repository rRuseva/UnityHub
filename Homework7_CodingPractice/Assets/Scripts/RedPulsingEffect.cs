using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class RedPulsingEffect : MonoBehaviour
{
    [SerializeField] private WeaponController weaponController = null;
    [SerializeField] private Health health = null;
    [SerializeField] private Material redPulsingEffectMaterial = null;


    private void OnRenderImage(RenderTexture source, RenderTexture destination) {

        //health.OnDamageTaken += Health_OnDamageTaken;
        if (health.getHealth() > 20 ) {
            //Debug.Log("onR - h - " + health.getHealth());
            Graphics.Blit(source, destination);
            return;
        }
        //if (weaponController.getAmmo() > 5) {
        //    Graphics.Blit(source, destination);
        //    return;
        //}

        Graphics.Blit(source, destination, redPulsingEffectMaterial);
    }

    private void Health_OnDamageTaken(int h, int a) {
        //if(h > health.Crit)
    }
}
