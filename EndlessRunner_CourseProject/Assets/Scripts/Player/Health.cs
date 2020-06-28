using System;
using UnityEngine;
using static UnityEngine.Mathf;

public class Health : MonoBehaviour {
    public event Action<int> OnHealthChanged;
    public event Action OnDie;
    private int health;
    public CameraShake camShake;
    private void Start() {
        ChangeHealth(Constants.MAX_HEALTH);
    }

    private void Update() {
        if (IsFallingAndIsNotDead()) {
            AudioManager.PlayFallSound();
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

    private void Heal(int amount) {
        int newHealth = health + amount;
        if (newHealth < Constants.MAX_HEALTH) {
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
        if (collision.gameObject.CompareTag("Obstacle")) {
            AudioManager.PlayCrashTreeSound();
            TakeDamage(5);
			Handheld.Vibrate();
            StartCoroutine(camShake.Shake());
        } 
        if (collision.gameObject.CompareTag("Cheese")) {
            Heal(5);
            //call an action to disable the cheese
            collision.gameObject.SetActive(false);
        }
    }
    private bool IsFallingAndIsNotDead() {
        return transform.position.y < -3 && health > 0;
    }
}