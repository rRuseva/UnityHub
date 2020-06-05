using System;

public class InputRecognizer {
    public static event Action<SwipeDirection> swipe;
    public static void OnSwipe(SwipeDirection swipeDirection) {
        swipe?.Invoke(swipeDirection);
    }
}