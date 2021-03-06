using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{
    public Rigidbody2D rb;
    private float destroyTime = 10;
    public Vector3 velocity;
    public float speed;
    private int dam = 10;
    void Start()
    {
        //transform.LookAt(transform.position + velocity);
        this.speed = 10f;
    }

    void OnCollisionEnter2D(Collision2D hitInfo) {
        if (hitInfo.gameObject.tag=="Enemy") {
            if(hitInfo.gameObject.GetComponent<EnemyController>() != null){ 
            hitInfo.gameObject.GetComponent<EnemyController>().TakeDamage(dam);
            Destroy(gameObject);
            }
        }
    }
    void Update()
    {
        transform.position = transform.position + velocity * speed * Time.deltaTime;
        Destroy(gameObject, destroyTime); 
    }
    // Start is called before the first frame update
}
