using System;
using UnityEngine;
using static UnityEngine.Mathf;

public class Ammo : MonoBehaviour
{

    public static readonly int maxAmmo = 9;

    [SerializeField]
    private int ammo = maxAmmo;

    public int AmmoCount {
        get { return ammo; }
        set {
            ammo = Clamp(value, 0, maxAmmo);
        }
    }

    public event Action<int> OnAmmoCountChange;
    public int getAmmo() {
        return ammo;
    }
    public void TakeAmmo() {
        if (ammo >= 1f) {
            ammo -= 1;
            OnAmmoCountChange?.Invoke(ammo);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void  Ammo_OnAmmoCountChange(object sender, EventArgs e) {
    //    Debug.Log("ammo_changed");
    //}

}
