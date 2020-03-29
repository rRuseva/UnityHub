using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script for 8-directional movment and stop and face current direction when no input;
public class PlayerController : MonoBehaviour {
    public float moveSpeed = 13;
	public float turnSpeed = 10;
	public float velocity = 5;
	
	Vector2 input;
	float angle;
	
	Quaternion targetRotation;
	Transform cam;
	
	void Start(){
		cam = Camera.main.transform; 
	}
 
    void Update() {
		GetInput();
		if(Mathf.Abs(input.x)<1 && Mathf.Abs(input.y)<1) return;

		CalculateDirection();
		Rotate();
		Move();
    }
	
	// get input based on vertical and horizontalaxis 
	// buttondepends on project settings // in this case - arrows
	
	void GetInput() {
		input.x = Input.GetAxisRaw("Horizontal");
		input.y = Input.GetAxisRaw("Vertical");
		
	}
	
	void CalculateDirection() {
		angle = Mathf.Atan2(input.x, input.y);
		angle = Mathf.Rad2Deg * angle;
		
		angle += cam.eulerAngles.y ;
	}
	
	void Rotate() {
		targetRotation = Quaternion.Euler(0, angle, 0);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
		
	}
	
	void Move() {
		transform.position += transform.forward * velocity * Time.deltaTime;
	}

}

