using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    private Player playerScript;
    private Enemy enemyScript;

    private void Start()
    {
        playerScript = GameManager.Instance.GetPlayerScript();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerScript.TakeDamage(damage);
        Destroy(gameObject);
    }
}
