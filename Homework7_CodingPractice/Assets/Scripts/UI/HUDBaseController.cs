using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDBaseController : MonoBehaviour
{
    [SerializeField] private WeaponController weaponController = null;
    [SerializeField] private Text ammoText = null;

    private void Awake() {
    }
    void Start() {
        ammoText.text = weaponController.getAmmo().ToString();
        weaponController.OnAmmoCountChange += WeaponController_OnAmmoCountChange;
    }
    private void OnEnable() {

    }

    private void WeaponController_OnAmmoCountChange(int ammo) {
        ammoText.text = ammo.ToString();
        //Debug.Log("OnAmmoChange " + ammo);
    }

    private void OnDisable() {
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
