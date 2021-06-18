using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBoltController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    private float destroyTime = 2;
    public Vector3 velocity;
    public float speed;
    private int dam = 100;
    void Start()
    {
        //transform.LookAt(transform.position + velocity);
        this.speed = 10f;
    }

    void OnCollisionEnter2D(Collision2D hitInfo) {

        if (hitInfo.gameObject.tag=="Enemy") {
            hitInfo.gameObject.GetComponent<EnemyController>().TakeDamage(dam);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + velocity * speed * Time.deltaTime;
        Destroy(gameObject, destroyTime); 
    }
}
