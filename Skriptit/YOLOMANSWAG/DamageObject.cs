using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    private Player playerClass;
    private string playerTag = "Player";
    [Tooltip("False = normal, true = trigger")]
    [SerializeField] private bool collisionType;

    private void Start()
    {
        playerClass = GameObject.FindObjectOfType<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag) && collisionType == false)
        {
            playerClass.Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(playerTag) && collisionType == true)
        {
            playerClass.Death();
        }
    }
}
