using System;
using UnityEngine;
using static UnityEngine.Mathf;

public class Health : MonoBehaviour {
    public event Action<int> OnHealthChanged;
    public event Action OnDie;
    private int health;
    private void Start() {
        ChangeHealth(Constants.MAX_HEALTH);
    }

    private void Update() {
        if (IsFallingAndIsNotDead()) {
            TakeDamage(health);
        }
    }

    private void TakeDamage(int damage) {
        int newHealth = health - damage;
        if (newHealth <= 0) {
            Die();
        } else {
            ChangeHealth(newHealth);
        }
    }

    private void Die() {
        OnDie?.Invoke();
        Destroy(gameObject);
    }

    private void ChangeHealth(int newHealth) {
        health = Clamp(newHealth, 0, Constants.MAX_HEALTH);
        OnHealthChanged?.Invoke(health);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Obsticle")) {
            TakeDamage(5);
        }
    }

    private bool IsFallingAndIsNotDead() {
        return transform.position.y < -5 && health > 0;
    }

}
