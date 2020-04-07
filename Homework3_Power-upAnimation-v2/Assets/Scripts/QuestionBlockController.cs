using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlockController : MonoBehaviour
{
    [SerializeField] private bool isHit = false;

    private Animator animator; 
    private new Rigidbody2D rigidbody;
    private SpriteRenderer sprite;
    [SerializeField]  private GameObject mushroom;
    private Animator mushroomAnimator;
    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        mushroomAnimator = mushroom.GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator.SetBool("IsHit", false);

    }

    // Update is called once per frame
    void Update()
    {
        if (isHit) {
            sprite.color = new Color(193, 193, 193);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            isHit = true;
            animator.SetBool("IsHit", true);
            ActivateMushroom();
        }
    }
    void ActivateMushroom() { 
        if (isHit) {
          //  mushroomAnimator.enabled = true;
            mushroomAnimator.SetBool("IsActivated", true);
            mushroom.GetComponent<MushroomController>().isActivated = true;
            //mushroomAnimator.SetBool("IsFalling", true);
            //mushroom.GetComponent<MushroomController>().isFalling = true;

        }
    }
}
