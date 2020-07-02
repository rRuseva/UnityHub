using System;
using UnityEngine;

public class KeyboardInputRecognizer : MonoBehaviour {
    void Update() {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            InputRecognizer.OnSwipe(SwipeDirection.Right);
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            InputRecognizer.OnSwipe(SwipeDirection.Left);
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            InputRecognizer.OnSwipe(SwipeDirection.Up);
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            InputRecognizer.OnSwipe(SwipeDirection.Down);
        }
    }
}
