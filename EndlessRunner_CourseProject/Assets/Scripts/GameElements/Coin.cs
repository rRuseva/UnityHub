using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IPooledObject {

    void Start() {
    }
    public void OnObjectSpawn() {
        Quaternion rotation = Quaternion.Euler(1, 5, 1);
        transform.rotation = rotation;
    }

}
