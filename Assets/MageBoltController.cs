using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBoltController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public Rigidbody2D rb;
    void Start()
    {
       rb.velocity = new Vector2(20f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
