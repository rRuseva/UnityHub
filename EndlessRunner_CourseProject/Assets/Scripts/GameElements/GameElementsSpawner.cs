using UnityEngine;

public class GameElementsSpawner : MonoBehaviour {
    [SerializeField] private int minimumCoinCount = 3;
    [SerializeField] private int maximumCoinCount = 5;
    private readonly string[] ObstaclesTags = { GameObjectsTags.TreeTag, GameObjectsTags.SlantedTreeTag, GameObjectsTags.LakeTag };
    private readonly string[] BonusTags = { GameObjectsTags.CheeseTag, GameObjectsTags.CoinTag };
    private GameObjectsPooler objPooler;
    private Transform playerTransofrm;
    private float previousGameElementPositionX;
    private void Start() {
        objPooler = GameObjectsPooler.Instance;
        playerTransofrm = GameObject.FindGameObjectWithTag(GameObjectsTags.PlayerTag).transform;
        previousGameElementPositionX = playerTransofrm.position.x;
    }

    private void Update() {
        if (previousGameElementPositionX - playerTransofrm.position.x <= 2 * Constants.SAFE_ZONE) {
            SpawnNewGameElement();
            RemoveOldGameElements();
        }
    }

    private void SpawnNewGameElement() {
        bool shouldSpawnObstacle = randomBoolean();
        if (shouldSpawnObstacle) {
            SpawnNewObstacle();
        } else {
            SpawnNewBonus();
        }
    }

    private void RemoveOldGameElements() {
        foreach (string tag in ObstaclesTags) {
            DeactivateObjectsWithTag(tag);
        }
        foreach (string tag in BonusTags) {
            DeactivateObjectsWithTag(tag);
        }
    }

    private void SpawnNewObstacle() {
        string newObstacleTag = ChooseObstacleTag();
        float horizontalPosition = 0;

        // slanted trees and lakes should be always on 0 position by horizontal axis (Z)
        if (newObstacleTag == GameObjectsTags.TreeTag) {
            horizontalPosition = Random.Range(-1, 1) * Constants.SINGLE_HORIZONTAL_MOVEMENT_DISTANCE;
        }

        Vector3 newObstaclePosition = new Vector3(previousGameElementPositionX + Constants.MAX_OBJECT_LENGTH, 0, horizontalPosition);
        SpawnElements(newObstacleTag, 1, newObstaclePosition);
    }

    private void SpawnNewBonus() {
        //choose random number of bonus elements and random element from all tags;
        int count = Random.Range(minimumCoinCount, maximumCoinCount);
        string newBonusTag = ChooseBonusTag();
        float horizontalPosition = Random.Range(-1, 1) * Constants.SINGLE_HORIZONTAL_MOVEMENT_DISTANCE;

        Vector3 newBonusPosition = new Vector3(previousGameElementPositionX + Constants.MAX_OBJECT_LENGTH, 0, horizontalPosition);
        SpawnElements(newBonusTag, count, newBonusPosition);
    }

    private void SpawnElements(string tag, int count, Vector3 initialPosition) {
        for (int i = 0; i < count; i++) {
            Vector3 newElementPosition = initialPosition + new Vector3(i, 0, 0);
            previousGameElementPositionX = newElementPosition.x;
            SpawnElementOnPosition(tag, newElementPosition, Quaternion.identity);
        }
    }

    private void SpawnElementOnPosition(string tag, Vector3 position, Quaternion rotation) {
        objPooler.SpawnFromPool(tag, position, rotation);
    }

    private void DeactivateObjectsWithTag(string tag) {
        objPooler.DeactivateGameObjectByCondition(DeactivateByCondition, playerTransofrm.position, tag);
    }

    private bool DeactivateByCondition(GameObject go, Vector3 playerPosition) {
        return go.transform.position.x + 3 * Constants.SAFE_ZONE < playerPosition.x;
    }

    private string ChooseRandomGameElementTag(string[] tags) {
        return tags[Random.Range(0, tags.Length)];
    }

    private string ChooseBonusTag() {
        if (Random.value <= 0.7) {
            return GameObjectsTags.CoinTag;
        } else {
            return GameObjectsTags.CheeseTag;
        }
    }
    private string ChooseObstacleTag() {
        float random = Random.value;
        if (random < 0.5) {
            return GameObjectsTags.TreeTag;
        } else if (random >= 0.5 && random < 0.7) {
            return GameObjectsTags.SlantedTreeTag;
        } else {
            return GameObjectsTags.LakeTag;
        }
    }

    private bool randomBoolean() {
        return Random.value >= 0.5;
    }
}
