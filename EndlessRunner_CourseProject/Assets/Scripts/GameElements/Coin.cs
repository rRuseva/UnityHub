using UnityEngine;
﻿using System.Collections;
using System.Collections.Generic;
using System;

public class Coin : MonoBehaviour, IPooledObject {

    public float RotationSpeed = 20.0f;
    public void OnObjectSpawn() {
        if (UnityEngine.Random.value >= 0.5) {
            Vector3 rot = this.transform.rotation.eulerAngles;
            rot = new Vector3(rot.x, rot.y + 45, rot.z);
            this.transform.rotation = Quaternion.Euler(rot);
        }
    }

    private void Update() {
        transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));
    }
}
