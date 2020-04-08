using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    //[SerializeField] 
    public bool isActivated = false;
    //[SerializeField] 
    public bool isFalling = false;
    private Animator animator;
    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
       // animator.enabled = true;
        animator.SetBool("IsActivated", false);
    }

    // Update is called once per frame
    void Update() {
        //if (isActivated) {
        //    //animator.enabled = true;
        //    isFalling = true;
        //    animator.SetBool("IsFalling", true);
        //}
    }
    void InitializeFall() {
        if (isActivated) {
            isFalling = true;
            animator.SetBool("IsFalling", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        //if (collision.gameObject.CompareTag("Player")) {
        //    isActivated = true;
        //    animator.SetBool("isActivated", true);
        //}
    }
}
