using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slantedTree : MonoBehaviour, IPooledObject {
    public void OnObjectSpawn() {
       if( Random.value >= 0.7){
            Vector3 rot = this.transform.rotation.eulerAngles;
            rot = new Vector3(rot.x, rot.y + 180, rot.z +14);
            this.transform.rotation = Quaternion.Euler(rot);
        }
    }
}
