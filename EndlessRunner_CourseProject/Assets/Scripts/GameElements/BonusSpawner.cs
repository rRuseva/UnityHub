using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour {

    [SerializeField] private int minimumCoinCount = 3;
    [SerializeField] private int maximumCoinCount = 5;
    private GameObjectsPooler objPooler; 
    private readonly string[] BonusTags = { "Cheese", "Coin" }; // just add more tags here: { "Cheese", "Coin", "CampFire" }

    // Two temp fields to test :
    private float nextActionTime = 0.0f;
    public float interval = 2f;

    private Transform playerTransofrm;
    private int safeZone = 18;

    void Start(){
        objPooler = GameObjectsPooler.Instance;
        playerTransofrm = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        if (Time.time > nextActionTime) {
            nextActionTime += interval;

            //choose random number of bonus elements and random element from all tags;
            int count = Random.Range(minimumCoinCount, maximumCoinCount);
            string newBonusTag = ChooseRandomBonusTag();

            for ( int i = 0; i< count; i++) {
                Vector3 newBonusPosition = new Vector3(playerTransofrm.position.x + 2 * safeZone, 0, 0) + new Vector3(1, 0, 0) * i ;
                SpawnBonuses(newBonusTag, newBonusPosition, Quaternion.identity);
            }

            DeactivateOldBonuses();

        }
    }

    private void SpawnBonuses(string tag, Vector3 position, Quaternion rotation) {
        objPooler.SpawnFromPool(tag, position, rotation);
    }

    private void DeactivateOldBonuses() {
        foreach (string tag in BonusTags) {
            foreach (GameObject go in objPooler.poolDictionary[tag]) {
                if (go.transform.position.x + 3 * safeZone < playerTransofrm.position.x) {
                    objPooler.DeactivateGameObject(tag, go);
                }
            }
        }
        
    }

    private string ChooseRandomBonusTag() {
        return BonusTags[Random.Range(0, BonusTags.Length)];
    }
}
