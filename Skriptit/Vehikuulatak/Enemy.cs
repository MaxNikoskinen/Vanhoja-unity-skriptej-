using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for handling enemy behaviour

public class Enemy : MonoBehaviour
{
    private int health = 35;

    private void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {

            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
