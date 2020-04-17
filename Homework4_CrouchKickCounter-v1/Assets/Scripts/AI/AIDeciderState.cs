using UnityEngine;

public class AIDeciderState : StateMachineBehaviour {
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		float rand = Random.value;
		if      (rand <= 0.1f) { animator.SetTrigger("ShouldDodge"); Debug.Log("dodge"); }
		else if (rand <= 0.3f) { animator.SetBool("ShouldRetreat", true); }
		else if (rand <= 0.4f) { animator.SetTrigger("ShouldWait"); }
		else if (rand <= 1.0f) { animator.SetTrigger("ShouldAttack"); }
	}
}
