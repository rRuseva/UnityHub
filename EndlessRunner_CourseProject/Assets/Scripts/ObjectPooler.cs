using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ObjectPoolItem {
    public bool shouldExpand = true;
    public GameObject objectToPool;
    public int amountToPool;
}

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<ObjectPoolItem> itemsToPool;
    public List<GameObject> pooledObjects;

    private int lastChosenIndex = 0;

    void Awake() {
        SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start() {
        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool) {
            for (int i = 0; i < item.amountToPool; i++) {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }

        }

        
    }

    
    public GameObject GetPooledObject(string tag, bool randomize) {
        int index = RandomIndex();
        if (!randomize) {
            for (int i = 0; i < pooledObjects.Count; i++) {
                if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag) {
                    return pooledObjects[i];
                }
            }
        }
        else {
            while (pooledObjects[index])
                if (!pooledObjects[index].activeInHierarchy && pooledObjects[index].tag == tag) {
                    return pooledObjects[index];
                }
                else index = RandomIndex();
        }
        foreach (ObjectPoolItem item in itemsToPool) {
            if (item.objectToPool.tag == tag) {
                if (item.shouldExpand) {
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }

    private int RandomIndex() {
        if (pooledObjects.Count <= 1) return 0;
        int randomIndex = lastChosenIndex;
        while (randomIndex == lastChosenIndex) {
            randomIndex = Random.Range(0, pooledObjects.Count);
        }
        lastChosenIndex = randomIndex;
        return randomIndex;
    }
}
