using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IPooledObject {
    public void OnObjectSpawn() {
        if (Random.value >= 0.5) {
            Vector3 rot = this.transform.rotation.eulerAngles;
            rot = new Vector3(rot.x, rot.y + 90, rot.z);
            this.transform.rotation = Quaternion.Euler(rot);
        }
    }

}
