using System;
using UnityEngine;
using static UnityEngine.Mathf;

public class Health : MonoBehaviour {
    public event Action<int> OnHealthChanged;
    public event Action OnDie;
    private static readonly int maxHealth = 100;
    private int health;

    // Two temp fields to test Health UI:
    private float nextActionTime = 0.0f;
    public float interval = 4f;

    private void Start() {
        ChangeHealth(maxHealth);
    }

    private void Update() {
        // Simulate take damage for test purposes
        if (Time.time > nextActionTime) {
            nextActionTime += interval;
            TakeDamage(10);
        }
    }

    private void TakeDamage(int damage) {
        int newHealth = health - damage;
        if (newHealth < 0) {
            Die();
        } else {
            ChangeHealth(newHealth);
        }
    }

    private void Die() {
        OnDie?.Invoke();
        Destroy(gameObject);
        // Spawn some dialog here with button OK and the button will call GameManager.LoadMainMenu()
    }

    private void ChangeHealth(int newHealth) {
        health = Clamp(newHealth, 0, maxHealth);
        OnHealthChanged?.Invoke(health);
    }
}
