using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedTrigger : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private string playerTag = "Player";
    private GameObject player;
    private Rigidbody2D playerRb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        playerRb = player.GetComponent<Rigidbody2D>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            playerRb.velocity = Vector2.right * moveSpeed;
        }
    }
}
