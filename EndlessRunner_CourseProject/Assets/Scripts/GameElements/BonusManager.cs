using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    [SerializeField]
    private int minimumCoinCount = 3;
    [SerializeField]
    private int maximumCoinCount = 5;
    public int distanceBetweenBonuses = 10;
    public void SpawnCoins(Vector3 startPosition, int prefabIndex = -1) {
        GameObject go;
        go = ObjectPooler.SharedInstance.GetPooledObject("Coin", prefabIndex);
        if (go != null) {
            go.transform.position = startPosition;
            go.SetActive(true);
        }
    }
}
