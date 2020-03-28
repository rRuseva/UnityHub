using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : MonoBehaviour {
    public float moveSpeed = 13;
 
    void Update() {

        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * Time.deltaTime * moveSpeed;

        // moveDirection = new Vector3(Input.GetAxis("Horizontal"), heightMultiplier * Input.GetAxis("Jump"), Input.GetAxis("Vertical")).normalized * Time.deltaTime * moveSpeed;

        Vector3 pointToLookAt = transform.position + moveDirection * 100;
        //pointToLookAt.y = transform.position.y;

        // NOT TESTED
       // Vector3 smoothetMovement = Vector3.Lerp(transform.position, transform.position + moveDirection, 0.75f);
        transform.position += moveDirection;
        transform.LookAt(pointToLookAt);


    }
}
