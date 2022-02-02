using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPortal : MonoBehaviour
{
    private Player playerClass;
    private string playerTag = "Player";

    private void Start()
    {
        playerClass = GameObject.FindObjectOfType<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            playerClass.Win();
        }
    }
}
