using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDBaseController : MonoBehaviour
{
    [SerializeField] private WeaponController weaponController = null;
    [SerializeField] private Text ammoText = null;
    [SerializeField] private Health health = null;
    [SerializeField] private Text healthText = null;
    [SerializeField] private Text armorText = null;
    // [SerializeField] private RawImage ammoDigits = null;
    [SerializeField] private GameObject head = null;

    private Animator headAnimator;


    private void Awake() {
    }
    void Start() {
        ammoText.text = weaponController.getAmmo().ToString();
        healthText.text = health.getHealth().ToString();
        armorText.text = health.getArmor().ToString();

        weaponController.OnAmmoCountChange += WeaponController_OnAmmoCountChange;
        weaponController.OnStartShooting += WeaponController_OnStartShooting;
        headAnimator = head.GetComponent<Animator>();

        health.OnDamageTaken += Health_OnDamageTaken;
    }

    private void Health_OnDamageTaken(int health, int armor) {
        healthText.text = health.ToString();
        armorText.text = armor.ToString();
        headAnimator.SetTrigger("TakeDamage");
        if(health == 0) {
            headAnimator.SetTrigger("Daying");
        }
    }

    private void WeaponController_OnStartShooting() {
        headAnimator.SetTrigger("Shooting");
    }

    private void WeaponController_OnAmmoCountChange(int ammo) {
        ammoText.text = ammo.ToString();
        //Debug.Log("OnAmmoChange " + ammo);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
