using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlayer : MonoBehaviour
{
    public float fallMultiplier = -2.5f;
    public float lowJumpMultiplier = 2f;
    public bool onGround = true;
	public bool jumpRequest = false;
	public float jumpVelocity = 13f;
	
    
    Rigidbody rb;
    void Start() {
        rb = GetComponent<Rigidbody>(); 
        
    }
    
    void Update() {
		
		if(onGround && Input.GetButtonDown("Jump")) {
			jumpRequest = true; 
		}
        
    }
	void FixedUpdate(){
		if(jumpRequest){
			
			rb.AddForce (Vector3.up * jumpVelocity, ForceMode.Impulse); 
			
			if (rb.velocity.y <= 0) {
			   rb.velocity += Vector3.up  * fallMultiplier * Time.deltaTime;
			}
			else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
			{
			   rb.velocity += Vector3.up * lowJumpMultiplier * Time.deltaTime;
			}
			
			jumpRequest = false; 
			onGround = false;
		}
		
		
	}
    void OnCollisionEnter (Collision other) { 

        if(other.gameObject.CompareTag("Ground")) {
            onGround = true;
        }
    }
	
}
