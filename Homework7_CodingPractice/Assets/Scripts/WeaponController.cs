using System;
using UnityEngine;
using static UnityEngine.Mathf;


public class WeaponController : MonoBehaviour
{
    public static readonly int maxAmmo = 100;
    
    [SerializeField]
    private int heroAmmo = maxAmmo;
    private Animator weaponAnimator;
    private Animator headAnimator;
    private void Awake() {
        heroAmmo = maxAmmo;
    }

    public event Action<int> OnAmmoCountChange;
    public event Action OnStartShooting;
    public int getAmmo() {
        return heroAmmo;
    }
    public bool TakeAmmo() {
        if (heroAmmo >= 1f) {
            heroAmmo -= 1;
            OnAmmoCountChange?.Invoke(heroAmmo);
            return true;
        }
        else return false;
    }
    // Start is called before the first frame update
    void Start() {
        weaponAnimator = WeaponController.FindObjectOfType<Animator>();
       // headAnimator = HeadController.FindObjectOfType<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(1)) {
            TryShoot();
        }
        

    }

    void TryShoot() {
        if (TakeAmmo()) {
            weaponAnimator.SetTrigger("firing");
            OnStartShooting?.Invoke();
          //  Debug.LogError("TryShoot - isFiring " );
        }
    }


}
