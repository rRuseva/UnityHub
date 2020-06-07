﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class PathManager : MonoBehaviour
{
    public GameObject[] pathPrefabs;

    private Transform playerTransofrm;
    private float spawnX = -10.0f;
    private float pathLenght = 10.0f;
    private int amnPathsOnScreen = 7;
    private int safeZone = 14;
    private List<GameObject> activePaths;
    private int lastPrefabIndex = 0;

    // Start is called before the first frame update
    void Start() {
        activePaths = new List<GameObject>();
        playerTransofrm = GameObject.FindGameObjectWithTag("Player").transform;
        
        for(int i = 0; i < amnPathsOnScreen; i++) {
            // the first two paths infront will always be a clean paths (with no obsticles)
            if (i < 4)
                SpawnPath(0);
            else
                SpawnPath();
        }
    }

    // Update is called once per frame
    void Update() { 
        if(playerTransofrm.position.x - safeZone > (spawnX - amnPathsOnScreen * pathLenght)) {
            SpawnPath();
            DeletePath();
        }
    }

    private void SpawnPath(int prefabIndex = -1) {
        GameObject go;
        if(prefabIndex == -1)
            go = Instantiate(pathPrefabs[RandomPrefabIndex()]) as GameObject;
        else 
            go = Instantiate(pathPrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(1, 0, 0) * spawnX;
        spawnX += pathLenght;
        activePaths.Add(go);
    }
    private void DeletePath() {
        Destroy(activePaths[0]);
        activePaths.RemoveAt(0);
    }

    private int RandomPrefabIndex() {
        if (pathPrefabs.Length <= 1) return 0;
        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex) {
            randomIndex = Random.Range(0, pathPrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex; 
    }
}