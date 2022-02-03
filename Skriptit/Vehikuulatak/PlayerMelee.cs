using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Deals damage to player when enemy touches him

public class PlayerMelee : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackSpeed = 1f;
    private float damageDelay = 0f;
    private bool dealDamage;
    private Enemy enemyScript;

    private void Start()
    {

    }

    //Deals damage to player if the player touches the enemy
    private void Update()
    {
        if(dealDamage && Time.time >= damageDelay)
        {
            
            enemyScript.TakeDamage(damage);
            damageDelay = Time.time + 1f / attackSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        dealDamage = true;
        enemyScript = collision.transform.GetComponent<Enemy>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        dealDamage = false;
    }
}
