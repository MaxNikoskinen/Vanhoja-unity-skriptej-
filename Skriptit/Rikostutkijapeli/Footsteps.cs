using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private PlayerMovementCC playerMovementScript;
    private AudioManager audioManagerScript;

    public Rigidbody player;

    void Start()
    {
        playerMovementScript = GameObject.FindObjectOfType<PlayerMovementCC>();
        audioManagerScript = GameObject.FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (playerMovementScript.isGrounded == true && player.velocity.magnitude > 2f && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}