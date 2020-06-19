using UnityEngine;

public class PlayerMovementController : MonoBehaviour {
    [SerializeField] private float runningForwardSpeed = 7;
    private float horizontalDistanceToMove;

    //vertical movement: 
    private bool isGrounded = true;
    private float verticalVelocity = 0.0f;
    [SerializeField] private float gravity = 0.8f;
    [SerializeField] private float jumpVelocity = 0.4f;
    private Animator animator;
    private void Start() {
        InputRecognizer.swipe += OnMove;
        horizontalDistanceToMove = 0;
        animator = GetComponent<Animator>();
    }

    private void Update() {
        Vector3 moveForwardDirection = Time.deltaTime * new Vector3(runningForwardSpeed, 0, 0);
        Vector3 moveHorizontallyDirection = new Vector3(0, 0, horizontalDistanceToMove);
        horizontalDistanceToMove = 0;

        if (isGrounded) {
            verticalVelocity = 0f;
        } else {
            Fall();
        }

        Vector3 moveVerticalDirection = new Vector3(0, verticalVelocity, 0);
        Vector3 finalPosition = transform.position + moveForwardDirection + moveHorizontallyDirection + moveVerticalDirection;
        Vector3 targetPosition = ValidatePositionIfOutsidePath(finalPosition);

        transform.position = targetPosition;
    }

    private void OnDisable() {
        InputRecognizer.swipe -= OnMove;
    }

    void OnMove(SwipeDirection direction) {
        if (IsSwipeDirectionHorizontal(direction)) {
            horizontalDistanceToMove = calculateDistanceToMove(direction);
        } else if (direction == SwipeDirection.Up) {
            Jump();
        } else if (direction == SwipeDirection.Down) {
            Crouch();
        }
    }

    private float calculateDistanceToMove(SwipeDirection direction) {
        return direction == SwipeDirection.Left ?
         Constants.SINGLE_HORIZONTAL_MOVEMENT_DISTANCE :
          -Constants.SINGLE_HORIZONTAL_MOVEMENT_DISTANCE;
    }

    private bool IsSwipeDirectionHorizontal(SwipeDirection direction) {
        return direction == SwipeDirection.Left || direction == SwipeDirection.Right;
    }

    private Vector3 ValidatePositionIfOutsidePath(Vector3 positionToValidate) {
        float validHorizontalPosition = Mathf.Clamp(positionToValidate.z, -Constants.OFFSET_FROM_EDGES, Constants.OFFSET_FROM_EDGES);
        return new Vector3(positionToValidate.x, positionToValidate.y, validHorizontalPosition);
    }

    public void Jump() {
        if (isGrounded) {
            animator.SetTrigger("Jump");
            verticalVelocity += jumpVelocity;
            isGrounded = false;
        }
    }

    public void Crouch() {
        if (isGrounded) {
            animator.SetTrigger("Crouch");
        }
    }

    public void Fall() {
        verticalVelocity -= gravity * Time.deltaTime;
    }

    private bool isOnGround() {
        int mask = LayerMask.GetMask("Default");
        float rayLength = 0.99f;
        Vector3 origin = transform.position + new Vector3(0, 0.5f, 0);

        Vector3 rayDirection = new Vector3(0, -1, 0);

        if (Physics.Raycast(origin, rayDirection,
                                out RaycastHit hit, rayLength, mask, QueryTriggerInteraction.Collide)) {
            if (hit.collider.tag.Equals("Ground")) {
                isGrounded = true;
            } else
                isGrounded = false;

        }
        isGrounded = false;
        return isGrounded;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
            verticalVelocity = 0;
        }
        if (collision.gameObject.CompareTag("Lake")) {
            isGrounded = false;
            Fall();
        }
    }
}
