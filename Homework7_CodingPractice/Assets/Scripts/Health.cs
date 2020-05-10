using UnityEngine;
using System;
using static UnityEngine.Mathf;
public class Health : MonoBehaviour
{

    public static readonly int maxHealth = 100;
    [SerializeField] private int health = maxHealth;
    public static readonly int maxArmor = 100;
    [SerializeField] private int armor = maxHealth;
    public event Action<int, int> OnDamageTaken;

    //for debug purposes
    private float sendRate = 0.9f;
    float tempTime;

    // Update is called once per frame
    void Update() { 

        //take damege over time
        tempTime += Time.deltaTime;
        if (tempTime > sendRate) {
            TakeDamage();
            tempTime -= sendRate;
            Debug.LogError("health " + health + "; armor -" + armor);
        }
       // if(health == 0) { Die();  }
    }
    public int getHealth() {
        return health;
    }
    public int getArmor() {
        return armor;
    }
    public void Die() {
        Destroy(gameObject);
    }
    public void TakeDamage() {
        int damageHealth = 10;
        int damageArmor = 5;
        health = Max(health - damageHealth, 0);
        armor = Max(armor - damageArmor, 0);
        OnDamageTaken?.Invoke(health, armor);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // do something with rayCast
            TakeDamage();
    }
}
