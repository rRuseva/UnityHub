using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    public bool isActivated = false;
    public bool isFalling = false;
    [SerializeField]
    bool fading = false;
    private Animator animator;
    private new BoxCollider2D boxCol;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
       // animator.enabled = true;
        animator.SetBool("IsActivated", false);

        boxCol = GetComponent<BoxCollider2D>(); 

    }

    // Update is called once per frame
    void Update() {

    }
    void InitializeFall() {
        if (isActivated) {
            isFalling = true;
            animator.SetBool("IsFalling", true);
        }
    }
    void Fade() {
        if (isFalling) {
            fading = true;
            animator.SetBool("Fading", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player") && isActivated && isFalling ) {
            //boxCol.enabled = false;
            //isActivated = false;
            Fade();
        }

    }
}
