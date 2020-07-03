using UnityEngine;

public class PlayerMovementController : MonoBehaviour {
    [SerializeField] private float runningForwardSpeed = 9;
    private float horizontalDistanceToMove = 0;
    private Animator animator;

    //vertical movement: 
    private bool isGrounded = true;
    private float verticalVelocity = 0.0f;
    //[SerializeField] 
    private float gravity = 0.9f;
    //[SerializeField] 
    private float jumpVelocity = 0.18f;

    private void Start() {
        InputRecognizer.swipe += OnMove;
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
        
        Vector3 moveVerticalDirection = Time.deltaTime * 100 * new Vector3(0, verticalVelocity, 0);
        Vector3 finalPosition = transform.position + moveForwardDirection + moveHorizontallyDirection + moveVerticalDirection;
        Vector3 targetPosition = ValidatePositionIfOutsidePath(finalPosition);

        transform.position = targetPosition;
    }

    private void OnEnable() {
        PauseButtonHandler.OnPauseStateChanged += ChangeInputEventsSubscription;
    }

    private void OnDisable() {
        InputRecognizer.swipe -= OnMove;
        PauseButtonHandler.OnPauseStateChanged -= ChangeInputEventsSubscription;
    }

    private void ChangeInputEventsSubscription(bool shouldUnsubscribe) {
        if (shouldUnsubscribe) {
            InputRecognizer.swipe -= OnMove;
        } else {
            InputRecognizer.swipe += OnMove;
        }
    }

    private void OnMove(SwipeDirection direction) {
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
        float validHorizontalPosition = Mathf.Clamp(positionToValidate.z, -Constants.OFFSET_FROM_CENTER, Constants.OFFSET_FROM_CENTER);
        return new Vector3(positionToValidate.x, positionToValidate.y, validHorizontalPosition);
    }

    public void Jump() {
        if (isGrounded && !AnimatorIsPlaying()) {
            animator.SetTrigger("Jump");
            AudioManager.PlayJumpSound();
            verticalVelocity += jumpVelocity;
            isGrounded = false;
        }
    }

    public void Crouch() {
        if (isGrounded && !AnimatorIsPlaying()) {
            animator.SetTrigger("Crouch");
        }
    }

    public void Fall() {
        verticalVelocity -= gravity * Time.deltaTime;
    }

    
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag(GameObjectsTags.GroundTag)) {
            isGrounded = true;
            verticalVelocity = 0;
        }
        if (collision.gameObject.CompareTag(GameObjectsTags.LakeTag)) {
            isGrounded = false;
            Fall();
        }
    }

    private bool AnimatorIsPlaying() {
        return animator.GetCurrentAnimatorStateInfo(0).length >
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}
