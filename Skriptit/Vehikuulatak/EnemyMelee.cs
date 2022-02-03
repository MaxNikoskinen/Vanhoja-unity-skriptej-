using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Deals damage to player when enemy touches him

public class EnemyMelee : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackSpeed = 1f;
    private float damageDelay = 0f;
    private GameObject player;
    private Player playerScript;
    private bool dealDamage;

    private void Start()
    {
        player = GameManager.Instance.GetPlayer();
        playerScript = GameManager.Instance.GetPlayerScript();
    }

    //Deals damage to player if the player touches the enemy
    private void Update()
    {
        if(dealDamage && Time.time >= damageDelay)
        {
            playerScript.TakeDamage(damage);
            damageDelay = Time.time + 1f / attackSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        dealDamage = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        dealDamage = false;
    }
}
