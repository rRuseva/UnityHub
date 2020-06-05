using UnityEngine;

public class PlayerMovementController : MonoBehaviour {
    [SerializeField] private float runningForwardSpeed = 3;
    private readonly float OFFSET_FROM_EDGES = 1.8f;
    private readonly float SINGLE_HORIZONTAL_MOVEMENT_DISTANCE = 70f;
    private float horizontalDistanceToMove;

    private void Start() {
        InputRecognizer.swipe += OnMove;
        horizontalDistanceToMove = 0;
    }

    private void Update() {
        Vector3 moveForwardDirection = Time.deltaTime * new Vector3(runningForwardSpeed, 0, 0);
        Vector3 moveHorizontallyDirection = Time.deltaTime * new Vector3(0, 0, horizontalDistanceToMove);
        horizontalDistanceToMove = 0;

        Vector3 finalPosition = transform.position + moveForwardDirection + moveHorizontallyDirection;
        transform.position = ValidatePositionIfOutsidePath(finalPosition);
    }

    private void OnDisable() {
        InputRecognizer.swipe -= OnMove;
    }

    void OnMove(SwipeDirection direction) {
        if (IsSwipeDirectionHorizontal(direction)) {
            horizontalDistanceToMove = calculateDistanceToMove(direction);
        } else if (direction == SwipeDirection.Up) {
            // TODO: Start jump animation
        } else if (direction == SwipeDirection.Down) {
            // TODO: Start chouch animation
        }
    }

    private float calculateDistanceToMove(SwipeDirection direction) {
        return direction == SwipeDirection.Left ?
         SINGLE_HORIZONTAL_MOVEMENT_DISTANCE :
          -SINGLE_HORIZONTAL_MOVEMENT_DISTANCE;
    }

    private bool IsSwipeDirectionHorizontal(SwipeDirection direction) {
        return direction == SwipeDirection.Left || direction == SwipeDirection.Right;
    }

    private Vector3 ValidatePositionIfOutsidePath(Vector3 positionToValidate) {
        float validHorizontalPosition = Mathf.Clamp(positionToValidate.z, -OFFSET_FROM_EDGES, OFFSET_FROM_EDGES);
        return new Vector3(positionToValidate.x, positionToValidate.y, validHorizontalPosition);
    }
}
