using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    [SerializeField]
    private int minimumCoinCount = 3;
    [SerializeField]
    private int maximumCoinCount = 5;
	
    [SerializeField]
    private int distanceBetweenBonuses = 10;
    private int safeZone = 18;
    private Transform playerTransofrm;
    private List<GameObject> activeBonuses;

    //private ObjectPooler objPooler;

    // Two temp fields to test :
    private float nextActionTime = 0.0f;
    public float interval = 2f;
	
    private void OnEnable() {
        playerTransofrm = GameObject.FindGameObjectWithTag("Player").transform;
        activeBonuses = new List<GameObject>();
        //objPooler = GetComponent<ObjectPooler>();
    }
    void Update() {

        // Simulate the winning of bonuses for test purposes
        if (Time.time > nextActionTime) {
            nextActionTime += interval;

            Vector3 newCoinPosition = new Vector3(playerTransofrm.position.x + 2 * safeZone, 0, 0);
            //SpawnCoins(newCoinPosition, -1);
            Debug.Log("coin 2");

        }
        // if (playerTransofrm.position.x + safeZone < (spawnX)) {
            // DeleteBonus();
        // }
    }

    public void SpawnCoins(Vector3 startPosition, int prefabIndex = -1) {
        //List<GameObject> coins = new List<GameObject>();
        GameObject go;
        //for (int i = 0; i < maximumCoinCount; i++) {
            go = ObjectPooler.SharedInstance.GetPooledObject("Coin", -1);
            if (go != null) {
                go.SetActive(true);
                go.transform.position = startPosition;
                //startPosition = new Vector3(1, 0, 0) * i;
                activeBonuses.Add(go);
                Debug.Log("coin");
            }
            else Debug.LogError("coin null");
        //}

    }
    private void DeleteBonus() {
        activeBonuses[0].SetActive(false);
        activeBonuses.RemoveAt(0);
    }
}
