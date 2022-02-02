using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPortal : MonoBehaviour
{
    [Tooltip("true = reverse gravity, false = normal gravity")]
    [SerializeField] private bool portalMode;
    private Player playerClass;
    private float reversedGravity;
    private float normalGravity;
    private string playerTag = "Player";
    private GameObject player;
    private Rigidbody2D playerRb;
    private float normalJumpStrength;
    private float reversedJumpStrength;

    void Start()
    {
        playerClass = GameObject.FindObjectOfType<Player>();
        player = GameObject.FindGameObjectWithTag(playerTag);
        playerRb = player.GetComponent<Rigidbody2D>();
        normalGravity = playerRb.gravityScale;
        reversedGravity = 0f - playerRb.gravityScale;
        normalJumpStrength = playerClass.jumpStrength;
        reversedJumpStrength = 0f - playerClass.jumpStrength;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            if(portalMode == true)
            {
                playerRb.gravityScale = reversedGravity;
                player.transform.Rotate(0, 0, 180);
                playerClass.jumpStrength = reversedJumpStrength;
            }
            else
            {
                playerRb.gravityScale = normalGravity;
                player.transform.Rotate(0, 0, 180);
                playerClass.jumpStrength = normalJumpStrength;
            }

            playerClass.canJump = false;
        }
    }
}
