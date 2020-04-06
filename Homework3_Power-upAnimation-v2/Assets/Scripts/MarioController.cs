﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioController : MonoBehaviour
{
    [SerializeField] private bool isSmall = true;
    [SerializeField] private bool isGrowing = false;
    [SerializeField] private bool lookingForMushroom = false;

    private Animator animator;
    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
}

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.LogError("hit someting");
        if (collision.gameObject.CompareTag("Mushroom") && !lookingForMushroom) {
            Debug.Log("hit mushroom");
            lookingForMushroom = true;
            animator.SetBool("LookingForMushroom", true);
        }
        if (collision.gameObject.CompareTag("Mushroom") && lookingForMushroom) {
            Debug.Log("hit looking mushroom");
            lookingForMushroom = false;
            animator.SetBool("LookingForMushroom", false);
            isGrowing = true;
            animator.SetBool("IsGrowing", true);
            isSmall = false;
        }
    }
        
}