using UnityEngine;

public class AIDeciderState : StateMachineBehaviour {

	private Transform player;
	[SerializeField]
	[Range(0.1f, 0.4f)]
	private float wantedDistanceToPlayer = 0.2f;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		float rand = Random.value;
		GameObject playerGameObject = GameObject.FindWithTag("Player");
		if (playerGameObject == null) {
			Debug.LogError("No GameObject with the \"Player\" tag found");
		}
		else {
			player = playerGameObject.transform;
		}

		Vector3 vectorToPlayer = player.position - animator.transform.position;
		float distanceToPlayer = vectorToPlayer.magnitude;


		if (distanceToPlayer < wantedDistanceToPlayer) {
			//	Debug.LogError(distanceToPlayer);
			if(player.GetChild(1).gameObject.activeSelf ){ //|| player.GetChild(0).gameObject.activeSelf) {
				if (rand <= 0.5f)
					{ animator.SetTrigger("ShouldDodge"); Debug.Log("dodge"); }
			}
		}

		if (rand <= 0.3f) { animator.SetBool("ShouldRetreat", true); }
		else if (rand <= 0.4f) { animator.SetTrigger("ShouldWait"); }
		else if (rand <= 1.0f) { animator.SetTrigger("ShouldAttack"); }

	}
}
