using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlayer : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public bool onGround = true;
    
    Rigidbody rb;
    void Start() {
        rb = GetComponent<Rigidbody>(); 
        
    }
    
    void Update() {
		
		if(onGround){

			if ( Input.GetButtonDown("Jump")) {

				//if (rb.velocity.y < 0)
				//{
				//    //rb.velocity += vector3.up * physics.gravity.y * (fallmultiplier - 1) * time.deltatime;
				//    rb.velocity = vector3.up * 10 * (fallmultiplier - 1) * time.deltatime;
				//    debug.log("1");
				//}
				//else if (rb.velocity.y > 0 && !input.getbutton("jump"))
				//{
				//   // rb.velocity += vector3.up * physics.gravity.y * (lowjumpmultiplier - 1) * time.deltatime;
				//    rb.velocity = vector3.up * 10 * (lowjumpmultiplier - 1) * time.deltatime;
				//    debug.log("2");
				//}

				rb.velocity += new Vector3(0,10,0) * (lowJumpMultiplier -1) ; //* Physics.gravity.y;
				onGround = false;
				
			}
		}
        
    }
    void OnCollisionEnter (Collision other) { 

        if(other.gameObject.CompareTag("Ground")) {
            onGround = true;
        }
    }
}
