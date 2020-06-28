using System;
using UnityEngine;

public class Score : MonoBehaviour {
    public event Action<int> OnScoreChanged;
    public event Action<int> OnGameOverWithScore;
    private Health playerHealth; // todo - find a better way to detect when the player dies and the game finishes
    private static readonly int minScore = 0;
    private int score;

    // Two temp fields to test Score UI:
    private float nextActionTime = 0.0f;
    public float interval = 4f;

    private void Start() {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
        ChangeScore(minScore);
        playerHealth.OnDie += SaveScore;
    }

    private void Update() {

        // Simulate the winning of bonuses for test purposes
        //if (Time.time > nextActionTime) {
        //    nextActionTime += interval;
        //    EarnPoints(10);
        //}
    }

    private void OnDisable() {
        playerHealth.OnDie -= SaveScore;
    }

    private void SaveScore() {
        int maxScoreValue = PlayerPrefs.GetInt(Constants.MAX_SCORE_PLAYER_PREFS);
        if (score > maxScoreValue) {
            PlayerPrefs.SetInt(Constants.MAX_SCORE_PLAYER_PREFS, score);
        }
        OnGameOverWithScore?.Invoke(score);
    }

    private void EarnPoints(int pointsToAdd) {
        ChangeScore(score + pointsToAdd);
    }

    private void ChangeScore(int newScore) {
        score = newScore;
        OnScoreChanged?.Invoke(score);
    }

    public int GetScore() {
        return score;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Coin")) {
            EarnPoints(10);
            collision.gameObject.SetActive(false);
        }
    }
}
