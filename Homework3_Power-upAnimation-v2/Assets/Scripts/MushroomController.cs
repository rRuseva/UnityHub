using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    [SerializeField] private bool isHit = false;

    private Animator animator;
    private new Rigidbody2D rigidbody;
    private BoxCollider2D boxColl;
    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        // animator.enabled = false;
        //animator.SetBool("IsHit", false);
        boxColl = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update() {
        if (isHit) {
            //animator.enabled = true;
            //boxColl.enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            isHit = true;
            animator.SetBool("IsHit", true);
        }
    }
}
