using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 3;
    public Rigidbody2D rb;
    public Animator animator;

    public GameObject Magebolt;

    private bool facingRight;

    Vector2 movement;
    void Start()
    {

    }

    void Shoot() {
        Instantiate(Magebolt, this.transform.position, this.transform.rotation);
    }

    void GetSpeed() {
        movement.x = Input.GetAxisRaw("Horizontal") * speed;
        movement.y = Input.GetAxisRaw("Vertical") * speed;

        if (movement.x >= 0) facingRight = true; else facingRight = false;

        if (facingRight) {
            animator.SetFloat("Horizontal", 1f);
        } else {
            animator.SetFloat("Horizontal", -1.1f);
        }
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    // Update is called once per frame
    void Update()
    {
        this.GetSpeed();

        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.ResetTrigger("Attack");
            animator.SetTrigger("Attack");
        }

        if (Input.GetKeyDown(KeyCode.K)) {
            Shoot();
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}