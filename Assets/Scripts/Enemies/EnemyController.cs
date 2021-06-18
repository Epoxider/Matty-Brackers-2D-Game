using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int dam) {
        health -= dam;
        if (health <= 0) Die();
    }

    public void Die() {
        Destroy(gameObject);
    }
}
