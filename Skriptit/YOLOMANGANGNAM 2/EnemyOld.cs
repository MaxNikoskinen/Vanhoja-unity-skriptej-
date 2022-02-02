using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOld : MonoBehaviour
{/*
    public GameObject deathEffect;
    private Rigidbody theRB;

    private PlayerMovement playerMovementScript;
    private AudioManager audioManagerScript;

    public float health = 50f;
    public float seeRange = 10f;
    public float speed = 0f;
    public bool canAttack = true;
    


    private void Start()
    {
        audioManagerScript = FindObjectOfType<AudioManager>();
        theRB = this.GetComponent<Rigidbody>();
        playerMovementScript = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if(canAttack == true && playerMovementScript.isDead == false)
        {
            if (Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) < seeRange)
            {
                Vector3 playerDirection = PlayerMovement.instance.transform.position - transform.position;

                theRB.velocity = playerDirection.normalized * speed;
            }
            else
            {
                theRB.velocity = Vector2.zero;
            }
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        audioManagerScript.Play("Hitmarker");
        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        GameObject impactGO = Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(impactGO, 2f);
        Destroy(gameObject);
    }*/
}
