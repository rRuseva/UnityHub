using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_FiringState : StateMachineBehaviour {
    private Animator animator;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        this.animator = animator;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        animator.SetBool("isFiring", false);
    }
}
