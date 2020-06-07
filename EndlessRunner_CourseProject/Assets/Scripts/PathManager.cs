using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public GameObject[] pathPrefabs;

    private Transform playerTransofrm;
    private float spawnX = 0.0f;
    private float pathLenght = 10.0f;
    private int amnPathsOnScreen = 7;
    // Start is called before the first frame update
    void Start() {
        playerTransofrm = GameObject.FindGameObjectWithTag("Player").transform;
        SpawnPaths();
        for(int i = 0; i < amnPathsOnScreen; i++) {
            SpawnPaths();
        }
    }

    // Update is called once per frame
    void Update() { 
        if(playerTransofrm.position.x > (spawnX - amnPathsOnScreen * pathLenght)) {
            SpawnPaths();
        }
    }

    private void SpawnPaths(int prefabIndex = -1) {
        GameObject go;
        go = Instantiate(pathPrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(1, 0, 0) * spawnX;
        spawnX += pathLenght; 
    }
}
