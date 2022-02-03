using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script that handles the player, health and stuff like that

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int health;

    private void Start()
    {
        UIManager.Instance.UpdatePlayerHealthUI(maxHealth);
        health = maxHealth;
    }

    //Method for taking damage
    public void TakeDamage(int amount)
    {
        health -= amount;
        UIManager.Instance.UpdatePlayerHealthUI(health);
        if (health <= 0)
        {
            UIManager.Instance.UpdatePlayerHealthUI(0);
            GameManager.Instance.FindPlayer(false); //Put to gamemanager that the player doesn't exist to prevent nre
            Die();
        }
    }

    //Method for dying
    public void Die()
    {
    
        Destroy(gameObject);
    }
}
