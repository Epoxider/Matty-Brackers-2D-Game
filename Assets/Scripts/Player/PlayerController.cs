using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    //Game Objects
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject Magebolt;
    public GameObject Killbolt;
    public HealthBar healthBar;
    public ComboPointController comboPoint;


    //Player values
    public float speed = 3;
    private bool facingRight;
    public int maxHealth = 100;
    public int currentHealth;

    Vector2 movement;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void TakeDam(int dam) {
        currentHealth -= dam;
        healthBar.SetHealth(currentHealth);
    }

    void Teleport() {
        Vector2 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mPos - (Vector2)transform.position;
        direction.Normalize();
        transform.position = transform.position + (Vector3) direction*7;
    }
    void ShootMageBolt() {
        if (comboPoint.GetComboPoints() == 3) { 
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
            comboPoint.SetComboPoints(0);
        }
    }
    void ShootKillBolt() {
        Vector2 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mPos - (Vector2)transform.position;
        direction.Normalize();
        GameObject killBolt = Instantiate(Killbolt, transform.position, Quaternion.identity); 
        killBolt.GetComponent<KillBoltController>().velocity = direction;

        //rotaton
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;
        Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        killBolt.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        comboPoint.AddComboPoints(1);
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
        if (Input.GetMouseButtonDown(1)) {
            animator.ResetTrigger("Attack");
            animator.SetTrigger("Attack");
            ShootKillBolt();
        }
        if (Input.GetKeyDown(KeyCode.Tab)) {
            animator.ResetTrigger("Attack");
            animator.SetTrigger("Attack");
            ShootKillBolt();
            ShootMageBolt();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Teleport();
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            TakeDam(20);
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}