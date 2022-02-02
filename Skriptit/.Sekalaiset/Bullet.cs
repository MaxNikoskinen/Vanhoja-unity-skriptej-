using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private ScoreSystem scoreSystem;
    public int damage = 1;

    private void Start()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.transform.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            scoreSystem.ChangeAmount(50);

        }

        Destroy(gameObject);
    }
}
