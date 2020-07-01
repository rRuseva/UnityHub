using System;
using UnityEngine;
using static UnityEngine.Mathf;

public class Health : MonoBehaviour {
    public event Action<int> OnHealthChanged;
    public event Action<int> OnDieWithScore;
    public event Action OnDie;
    private int health;
    public CameraShake camShake;
    [SerializeField] private Score playerScore;
    private void Start() {
        ChangeHealth(Constants.MAX_HEALTH);
    }


    private void TakeDamage(int damage) {
        int newHealth = health - damage;

        ChangeHealth(newHealth);
        if (newHealth <= 0) {
            Die();
        } 
    }

    private void Heal(int amount) {
        int newHealth = health + amount;
        if (newHealth < Constants.MAX_HEALTH) {
            ChangeHealth(newHealth);
        }
    }

    private void Die() {
        int score = playerScore.score;
        OnDie?.Invoke();
        OnDieWithScore?.Invoke(score);
        Destroy(gameObject);
    }

    private void ChangeHealth(int newHealth) {
        health = Clamp(newHealth, 0, Constants.MAX_HEALTH);
        OnHealthChanged?.Invoke(health);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag(GameObjectsTags.ObstacleTag)) {
            AudioManager.PlayCrashTreeSound();
            TakeDamage(Constants.HEALTH_DAMAGE);
            Handheld.Vibrate();
            StartCoroutine(camShake.Shake());
        }
        if (collision.gameObject.CompareTag(GameObjectsTags.CheeseTag)) {
            AudioManager.PlayEatCheeseSound();
            Heal(Constants.HEALTH_DAMAGE);
            //deactivate the game element to be added to the pool
            collision.gameObject.SetActive(false);
        }
        //if (collision.gameObject.CompareTag(GameObjectsTags.LakeTag)) {
        //    Die();
        //}
    }
}