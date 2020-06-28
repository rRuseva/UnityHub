using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cheese : MonoBehaviour, IPooledObject {
    public void OnObjectSpawn() {
        transform.position += new Vector3(0, 0.5f, 0);
        transform.rotation = Quaternion.Euler(0f, 45f, 0f);
    }
    void Start() {
    }
}