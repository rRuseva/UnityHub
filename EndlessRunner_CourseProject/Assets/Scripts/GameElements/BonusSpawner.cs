using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour {
    private GameObjectsPooler objPooler;

    // Two temp fields to test :
    private float nextActionTime = 0.0f;
    public float interval = 2f;

    private Transform playerTransofrm;

    [SerializeField]
    private int minimumCoinCount = 3;
    [SerializeField]
    private int maximumCoinCount = 5;

    // Start is called before the first frame update
    void Start() {
        objPooler = GameObjectsPooler.Instance;
        playerTransofrm = GameObject.FindGameObjectWithTag(GameObjectsTags.PlayerTag).transform;
    }

    // Update is called once per frame
    void Update() {
        if (Time.time > nextActionTime) {
            nextActionTime += interval;

            int count = Random.Range(minimumCoinCount, maximumCoinCount);

            for (int i = 0; i < count; i++) {
                Vector3 newCoinPosition = new Vector3(playerTransofrm.position.x + 2 * Constants.SAFE_ZONE, 0, 0) + new Vector3(1, 0, 0) * i;
                objPooler.SpawnFromPool("Coin", newCoinPosition, Quaternion.identity);

            }

            //not sure it is optimall
            foreach (GameObject go in objPooler.poolDictionary["Coin"]) {
                if (go.transform.position.x + 2 * Constants.SAFE_ZONE < playerTransofrm.position.x) {
                    objPooler.DeactivateGameObject("Coin", go);
                    Debug.LogWarning("deactivated unused coin");
                }

            }

        }
    }

}
