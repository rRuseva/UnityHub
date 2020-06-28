using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    [SerializeField] float minSecondsToNextObstacle = .5f;
    [SerializeField] float maxSecondsToNextObstacle = 3f;
    private string[] ObstaclesTags = { GameObjectsTags.TreeTag }; // just add more tags here: { "Tree", "Lake", "CampFire" }
    private GameObjectsPooler objPooler;
    private float nextActionTime = .0f;
    private Transform playerTransofrm;

    private void Start() {
        objPooler = GameObjectsPooler.Instance;
        playerTransofrm = GameObject.FindGameObjectWithTag(GameObjectsTags.PlayerTag).transform;
    }

    private void Update() {
        if (Time.time > nextActionTime) {
            float nextInterval = Random.Range(minSecondsToNextObstacle, maxSecondsToNextObstacle);
            nextActionTime += nextInterval;
            SpawnNewObstacle();
            RemoveOldObstacles();
        }
    }

    private void SpawnNewObstacle() {
        float horizontalPosition = Random.Range(-1, 1) * Constants.SINGLE_HORIZONTAL_MOVEMENT_DISTANCE;

        Vector3 newObstaclePosition = new Vector3(playerTransofrm.position.x + 2 * Constants.SAFE_ZONE, 0, horizontalPosition);
        string newObstacleTag = ChooseRandomObstacleTag();
        objPooler.SpawnFromPool(newObstacleTag, newObstaclePosition, Quaternion.identity);
    }

    private void RemoveOldObstacles() {
        foreach (string tag in ObstaclesTags) {
            DeactivateObjectsWithTag(tag);
        }
    }

    private void DeactivateObjectsWithTag(string tag) {
        objPooler.DeactivateGameObjectByCondition(DeactivateByCondition, playerTransofrm.position, tag);
    }

    private bool DeactivateByCondition(GameObject go, Vector3 playerPosition) {
        return go.transform.position.x + 2 * Constants.SAFE_ZONE < playerPosition.x;
    }

    private string ChooseRandomObstacleTag() {
        return ObstaclesTags[Random.Range(0, ObstaclesTags.Length)];
    }
}
