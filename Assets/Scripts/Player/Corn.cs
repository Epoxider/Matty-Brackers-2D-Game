using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Corn : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D hitInfo) {
        if (hitInfo.gameObject.tag=="Player") {
            Destroy(gameObject);
        }
    }  
}
