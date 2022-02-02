using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public int health = 50;
    public int damage = 5;
    public float seeRange = 10f;
    public float speed = 3f;
    public float attackCooldown = 2f;
    public bool canAttack = true;
    public bool canMove = true;
    public bool isBoss = false;

    private Rigidbody rigidbodyRB;

    public GameObject player;
    public Ammobar healthbarScript;
    public TMP_Text healthStatusText;
    public GameObject deathEffect;
    public Ammobar bossHealthbar;
    public GameObject bossNotificaiton;
    public GameObject winScreen;

    private HealthSystem healthSystemScript;
    private AudioManager audioManagerScript;
    private BossShield bossShieldScript;

    private float nextTimeToAttack = 0f;
    private float nextTimeToNotification = 0f;



    private void Start()
    {
        healthSystemScript = FindObjectOfType<HealthSystem>();
        audioManagerScript = FindObjectOfType<AudioManager>();
        bossShieldScript = FindObjectOfType<BossShield>();
        rigidbodyRB = this.GetComponent<Rigidbody>();

        if(isBoss == true)
        {
            bossHealthbar.maximum = health;
        }
    }

    private void Update()
    {
        if (canMove == true && healthSystemScript.isDead == false)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < seeRange)
            {
                Vector3 playerDirection = player.transform.position - transform.position;

                rigidbodyRB.velocity = playerDirection.normalized * speed;
            }
            else
            {
                rigidbodyRB.velocity = Vector2.zero;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && healthSystemScript.currentHealth > 0 && canAttack == true && Time.time >= nextTimeToAttack)
        {
            nextTimeToAttack = Time.time + 1f / attackCooldown;
            healthSystemScript.currentHealth -= damage;
            healthbarScript.current = healthSystemScript.currentHealth;
            healthStatusText.text = healthSystemScript.currentHealth.ToString() + " %";
            audioManagerScript.Play("Hit");
        }
    }

    public void TakeDamage(int amount)
    {
        if(isBoss == true && bossShieldScript.killedEnemies < 14)
        {
            bossNotificaiton.SetActive(true);


            if (Time.time >= nextTimeToNotification)
            {
                bossNotificaiton.SetActive(false);
                nextTimeToNotification = Time.time + 1f / 0.2f;
            }
            
        }

        if(isBoss == false || bossShieldScript.killedEnemies >= 14)
        {
            health -= amount;

            if (health <= 0f)
            {
                Die();
            }

            if (isBoss == true)
            {
                bossHealthbar.current = health;
            }

            bossNotificaiton.SetActive(false);
        }

    }
    
    private void Die()
    {
        if(isBoss == false)
        {
            bossShieldScript.killedEnemies++;
        }

        if(isBoss == true)
        {
            audioManagerScript.StopPlaying("Boss Music");
            audioManagerScript.Play("Win");
            winScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
        Destroy(gameObject);
        GameObject blood = Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(blood, 5f);
        
    }
}
