using UnityEngine;

public class SwipeGestureRecognizer : MonoBehaviour {
    private bool swiping = false;
    private bool eventSent = false;
    private Vector2 lastPosition;

    // Copied from here: https://answers.unity.com/questions/600148/detect-swipe-in-four-directions-android.html
    void Update() {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);
        if (touch.deltaPosition.sqrMagnitude != 0) {
            if (swiping == false) {
                swiping = true;
                lastPosition = touch.position;
                return;
            } else if (!eventSent) {
                Vector2 direction = Input.GetTouch(0).position - lastPosition;
                SendSwipeEvent(direction);
                eventSent = true;
            }
        }
        if (touch.phase == TouchPhase.Ended && eventSent) {
            swiping = false;
            eventSent = false;
        }
    }

    private void SendSwipeEvent(Vector3 direction) {
        SwipeDirection swipeDirection;
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
            swipeDirection = direction.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
        } else {
            swipeDirection = direction.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
        }
        InputRecognizer.OnSwipe(swipeDirection);
    }
}
