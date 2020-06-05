using UnityEngine;

public class SwipeGestureRecognizer : MonoBehaviour {
    private bool swiping = false;
    private bool eventSent = false;
    private Vector2 lastPosition;

    // Copied from here: https://answers.unity.com/questions/600148/detect-swipe-in-four-directions-android.html
    void Update() {
        if (Input.touchCount == 0)
            return;

        if (Input.GetTouch(0).deltaPosition.sqrMagnitude != 0) {
            if (swiping == false) {
                swiping = true;
                lastPosition = Input.GetTouch(0).position;
                return;
            } else if (!eventSent) {
                Vector2 direction = Input.GetTouch(0).position - lastPosition;

                if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
                    if (direction.x > 0)
                        InputRecognizer.OnSwipe(SwipeDirection.Right);
                    else
                        InputRecognizer.OnSwipe(SwipeDirection.Left);
                } else {
                    if (direction.y > 0)
                        InputRecognizer.OnSwipe(SwipeDirection.Up);
                    else
                        InputRecognizer.OnSwipe(SwipeDirection.Down);
                }
                eventSent = true;
            }
        } else {
            swiping = false;
            eventSent = false;
        }
    }
}
