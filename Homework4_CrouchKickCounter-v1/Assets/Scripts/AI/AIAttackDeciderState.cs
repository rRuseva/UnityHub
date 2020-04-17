using UnityEngine;

public class AIAttackDeciderState : StateMachineBehaviour {
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		float rand = Random.value;
		if      (rand <= 0.1f) { animator.SetTrigger("ShouldCrouch"); Debug.Log("attack with crouch"); }
		else if (rand <= 0.50f) { animator.SetTrigger("ShouldJump"); }
		else if (rand <= 1.00f) { animator.SetTrigger("ShouldMoveToPlayer"); }
	}
}
