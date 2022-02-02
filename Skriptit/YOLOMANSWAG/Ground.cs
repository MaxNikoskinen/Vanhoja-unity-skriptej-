using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private Player playerClass;
    private string playerTag = "Player";

    private void Start()
    {
        playerClass = GameObject.FindObjectOfType<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(playerTag))
        {
            if(!playerClass.levelCompleted)
            {
                playerClass.canJump = true;
            }   
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            if (!playerClass.levelCompleted)
            {
                playerClass.canJump = false;
            }
        }
    }
}
