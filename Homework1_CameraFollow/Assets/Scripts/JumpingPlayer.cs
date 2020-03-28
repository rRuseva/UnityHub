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

        if (onGround) {

            if (Input.GetButtonDown("Jump"))
            {
                //if (rb.velocity.y < 0)
                //{
                //    //rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
                //    rb.velocity = Vector3.up * 10 * (fallMultiplier - 1) * Time.deltaTime;
                //    Debug.Log("1");
                //}
                //else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
                //{
                //   // rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
                //    rb.velocity = Vector3.up * 10 * (lowJumpMultiplier - 1) * Time.deltaTime;
                //    Debug.Log("2");
                //}

                rb.velocity += new Vector3(0, 10, 0) * (lowJumpMultiplier - 1); // * Physics.gravity.y;
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
