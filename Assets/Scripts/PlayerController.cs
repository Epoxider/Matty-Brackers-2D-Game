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

    void Teleport() {
        Vector2 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mPos - (Vector2)transform.position;
        direction.Normalize();
        transform.position = transform.position + (Vector3) direction*7;
    }
    void ShootMageBolt() {
        Vector2 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mPos - (Vector2)transform.position;
        direction.Normalize();
        GameObject mageBolt = Instantiate(Magebolt, transform.position, Quaternion.identity); 
        mageBolt.GetComponent<MageBoltController>().velocity = direction;

        //rotaton
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;
        Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        mageBolt.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }
    void ShootKillBolt() {
        Vector2 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mPos - (Vector2)transform.position;
        direction.Normalize();
        GameObject mageBolt = Instantiate(Magebolt, transform.position, Quaternion.identity); 
        mageBolt.GetComponent<MageBoltController>().velocity = direction;

        //rotaton
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;
        Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        mageBolt.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

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
        GetSpeed();

        if (Input.GetMouseButtonDown(0)) {
            animator.ResetTrigger("Attack");
            animator.SetTrigger("Attack");
            ShootMageBolt();
        }

        if (Input.GetKeyDown(KeyCode.I)) {
            animator.ResetTrigger("Attack");
            animator.SetTrigger("Attack");
            ShootMageBolt();
        }
        if (Input.GetMouseButtonDown(1)) {
            Teleport();
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}