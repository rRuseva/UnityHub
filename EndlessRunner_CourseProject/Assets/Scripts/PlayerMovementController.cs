using UnityEngine;

public class PlayerMovementController : MonoBehaviour {
    [SerializeField] private float runningForwardSpeed = 3;
    private readonly float OFFSET_FROM_EDGES = 1.8f;
    private readonly float SINGLE_HORIZONTAL_MOVEMENT_DISTANCE = 70f;
    private float horizontalDistanceToMove;
    //vertical movement: 
    private bool isGrounded = true;
    private float verticalVelocity = 0.0f;
    [SerializeField] private float gravity = 0.8f;
    [SerializeField] private float jumpVelocity = 7.0f;

    Animator animator; 
    private void Start() {
        InputRecognizer.swipe += OnMove;
        horizontalDistanceToMove = 0;
        animator = GetComponent<Animator>();

    }

    private void Update() {
        Vector3 moveForwardDirection = Time.deltaTime * new Vector3(runningForwardSpeed, 0, 0);
        Vector3 moveHorizontallyDirection = Time.deltaTime * new Vector3(0, 0, horizontalDistanceToMove);
        horizontalDistanceToMove = 0;
       
        if (isGrounded) 
            verticalVelocity = 0.0f;
        else 
            Fall();
        Vector3 moveVerticalDirection = Time.deltaTime * new Vector3(0, verticalVelocity, 0);
        
        Vector3 finalPosition = transform.position + moveForwardDirection + moveHorizontallyDirection + moveVerticalDirection;
        transform.position = ValidatePositionIfOutsidePath(finalPosition);

    }

    private void OnDisable() {
        InputRecognizer.swipe -= OnMove;
    }

    void OnMove(SwipeDirection direction) {
        if (IsSwipeDirectionHorizontal(direction)) {
            horizontalDistanceToMove = calculateDistanceToMove(direction);
        }
        else if (direction == SwipeDirection.Up) {
            // TODO: Start jump animation
            Jump();
            
        }
        else if (direction == SwipeDirection.Down) {
            // TODO: Start crouch animation
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

    public void Jump() {
        if (isGrounded) {
          //  animator.SetTrigger("Jump");
            verticalVelocity += jumpVelocity;
            isGrounded = false;

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
            }
            else
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
            //runningForwardSpeed = 1; 
            //gravity = 15;
            Fall();
        }
    }
}
