using UnityEngine;
using static UnityEngine.Mathf;
using static StateMachineUtil;

public class MonkCrouchKickingState : StateMachineBehaviour
{
    private Animator animator;
    private MovementController movementController;
    private GameObject hitbox;

    [SerializeField]
    [Range(0.1f, 0.5f)]
    private float delay = 0.2f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        this.animator = animator;
        float kickDirection = Sign(animator.transform.localScale.x);
        hitbox = animator.transform.GetChild(2).gameObject;
        hitbox.SetActive(true);

        DoWithDelay(delay, () => animator.SetBool("IsCrouchKicking", false));
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        hitbox.SetActive(false);
        ResetAnimationState();
    }

    private void ResetAnimationState() {
        animator.SetBool("IsCrouching", false);
        animator.SetBool("IsCrouchKicking", false);

    }
    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
