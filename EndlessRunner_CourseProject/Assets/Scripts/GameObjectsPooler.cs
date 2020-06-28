using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate bool DeleteConditionDelegate(GameObject gameObject, Vector3 position);

public class GameObjectsPooler : MonoBehaviour {
    [System.Serializable]
    public class Pool {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public static GameObjectsPooler Instance;



    private void Awake() {
        Instance = this;
    }
    void Start() {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools) {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++) {
                GameObject go = Instantiate(pool.prefab);
                go.SetActive(false);
                objectPool.Enqueue(go);

            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation) {

        if (!poolDictionary.ContainsKey(tag)) {
            Debug.LogWarning("Pool with tag" + tag + "doesn't exist!");
            return null;
        }

        GameObject goToSpawn = poolDictionary[tag].Dequeue();

        goToSpawn.SetActive(true);
        goToSpawn.transform.position = position;
        goToSpawn.transform.rotation = rotation;

        IPooledObject pooledObj = goToSpawn.GetComponent<IPooledObject>();

        if (pooledObj != null) {
            pooledObj.OnObjectSpawn();
        }
        poolDictionary[tag].Enqueue(goToSpawn);

        return goToSpawn;
    }

    public void DeactivateGameObject(string tag, GameObject go) {
        go.SetActive(false);
        poolDictionary[tag].Enqueue(go);
    }

    public void DeactivateGameObjectByCondition(DeleteConditionDelegate condition, Vector3 position, string tag) {
        foreach (GameObject go in poolDictionary[tag]) {
            if (condition(go, position)) {
                Debug.Log("delete " + tag);
                // DeactivateGameObject(tag, go);
                go.SetActive(false);
            }
        }
    }
}
