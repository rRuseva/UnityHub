using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class PathManager : MonoBehaviour
{

    private Transform playerTransofrm;
    private float spawnX = -10.0f;
    private float pathLenght = 10.0f;
    private int amnPathsOnScreen = 9;
    private int safeZone = 18;
    private List<GameObject> activePaths;

    // Start is called before the first frame update
    void Start() {
        activePaths = new List<GameObject>();
        playerTransofrm = GameObject.FindGameObjectWithTag("Player").transform;
        

        for(int i = 0; i < amnPathsOnScreen; i++) {
            // the first 4 paths infront will always be a clean paths (with no obstacle)
            if (i < 4) {
                SpawnPath(0);
            }
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
      //  go = ObjectPooler.SharedInstance.GetPooledObject("Ground", prefabIndex);
        go = ObjectPooler.SharedInstance.GetPooledCleanPath();
        if (go != null) {
            go.SetActive(true);
            go.transform.SetParent(transform);
            go.transform.position = new Vector3(1, 0, 0) * spawnX;
            spawnX += pathLenght;
            activePaths.Add(go);
        }
    }
    private void DeletePath() {
        activePaths[0].SetActive(false);
        activePaths.RemoveAt(0);
    }

}
