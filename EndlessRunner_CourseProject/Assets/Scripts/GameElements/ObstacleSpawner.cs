using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    [SerializeField] float minSecondsToNextObstacle = .5f;
    [SerializeField] float maxSecondsToNextObstacle = 3f;
    private readonly string[] ObstaclesTags = { "Tree", "SlantedTree" }; // just add more tags here: { "Tree", "Lake", "CampFire" }
    private GameObjectsPooler objPooler;
    private float nextActionTime = .0f;
    private Transform playerTransofrm;
    private int safeZone = 18;

    private void Start() {
        objPooler = GameObjectsPooler.Instance;
        playerTransofrm = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update() {
        if (Time.time > nextActionTime) {
            float nextInterval = Random.Range(minSecondsToNextObstacle, maxSecondsToNextObstacle);
            nextActionTime += nextInterval;
            SpawnNewObstacle();
            //това не трябва ли да се вика поне с някакъв delay; май за това изчезват елементи преди да сме стигнали до тях;
            RemoveOldObstacles();
        }
    }

    private void SpawnNewObstacle() {
        string newObstacleTag = ChooseRandomObstacleTag();
        Vector3 newObstaclePosition;
        
        //slantedTrees should be always on 0 position by horizontal axis (Z)
        if (newObstacleTag == "SlantedTree") {
            newObstaclePosition = new Vector3(playerTransofrm.position.x + 2 * safeZone, 0, 0);
        }
        else {
            float horizontalPosition = Random.Range(-1, 1) * Constants.SINGLE_HORIZONTAL_MOVEMENT_DISTANCE;
            newObstaclePosition = new Vector3(playerTransofrm.position.x + 2 * safeZone, 0, horizontalPosition);
        }
        
        objPooler.SpawnFromPool(newObstacleTag, newObstaclePosition, Quaternion.identity);
    }
    
    private void RemoveOldObstacles() {
        foreach (string tag in ObstaclesTags) {
            DeactivateObjectsWithTag(tag);
        }
    }

    private void DeactivateObjectsWithTag(string tag) {
        foreach (GameObject go in objPooler.poolDictionary[tag]) {
            if (go.transform.position.x + 3 * safeZone < playerTransofrm.position.x) {
                objPooler.DeactivateGameObject(tag, go);
            }
        }
    }

    private string ChooseRandomObstacleTag() {
        return ObstaclesTags[Random.Range(0, ObstaclesTags.Length)];
    }
}
