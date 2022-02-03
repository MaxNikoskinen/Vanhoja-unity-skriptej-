using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    private Enemy enemyScript;
    private Player playerScript;

    private void Start()
    {
        playerScript = GameManager.Instance.GetPlayerScript();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(enemyScript != null)
        {
            enemyScript = collision.transform.GetComponent<Enemy>();
            enemyScript.TakeDamage(damage);
        }
        
        Destroy(gameObject);
    }
}
