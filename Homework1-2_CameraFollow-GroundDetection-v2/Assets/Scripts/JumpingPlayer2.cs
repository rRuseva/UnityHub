using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlayer2 : MonoBehaviour {
	[SerializeField]
	float force = 5;
	[SerializeField]
	float jumpForce =5 ;
	bool isJumping;
	Vector3 moveDirection;

	Rigidbody rb; 
    // Start is called before the first frame update
    void Start() {
		rb = GetComponent<Rigidbody>();
		isJumping = false;
    }

	// Update is called once per frame
	void Update() {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		if (Input.GetKeyDown("space")) {
			isJumping = true;
		}
		if (Input.GetKeyUp("space")) { isJumping = false; }
	}

	void FixedUpdate() {
		if (isJumping) {
			int mask = LayerMask.GetMask("Default");
			float rayLength = 0.99f;
			Vector3 origin = transform.position;
			Vector3 rayDirection = new Vector3(0, -1, 0);

			if(Physics.Raycast(origin, rayDirection, 
								out RaycastHit hit, rayLength, mask, QueryTriggerInteraction.Collide)) {
				if(hit.collider.tag.Equals("Ground")) {
					rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
				}
			}

		}
		rb.AddForce(moveDirection * force); 
	}
}
