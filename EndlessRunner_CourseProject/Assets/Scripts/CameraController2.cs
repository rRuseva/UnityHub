using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour
{
	public Transform target; 
	public Vector3 cameraOffset; 
	
	public float moveSpeed = 5; 
	public float turnSpeed = 10; 
	public float smoothSpeed = 0.5f;
	
	Quaternion targetRotation;
	Vector3 targetPos;
	bool smoothRotating = false;
	
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        MoveWithTarget();
		LookAtTarget();
		
		if(Input.GetKeyDown(KeyCode.G) && !smoothRotating) {
			StartCoroutine("RotateAroundTarget", 45);
		}
		
		if(Input.GetKeyDown(KeyCode.H) && !smoothRotating) {
			StartCoroutine("RotateAroundTarget", -45);
		}
    }
	
	void MoveWithTarget() {
		targetPos = target.position + cameraOffset;
		transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
	}
	
	void LookAtTarget() {
		targetRotation = Quaternion.LookRotation(target.position - transform.position); 
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
	}
	
	IEnumerator RotateAroundTarget(float angle){
		Vector3 vel = Vector3.zero; 
		Vector3 targetOffsetPos = Quaternion.Euler(0, angle, 0) * cameraOffset;
		
		float dist = Vector3.Distance (cameraOffset, targetOffsetPos); 
		
		while (dist > 0.0f) {
			
			cameraOffset = Vector3.SmoothDamp(cameraOffset, targetOffsetPos, ref vel, smoothSpeed);
			dist = Vector3.Distance (cameraOffset, targetOffsetPos); 
			
			yield return null; 
		}
		
		smoothRotating = false; 
		cameraOffset = targetOffsetPos; 
	}
}
