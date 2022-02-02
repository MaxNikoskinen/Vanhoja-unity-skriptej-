using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private PlayerMovement playerMovementScript;
    private AudioManager audioManagerScript;
    private PauseScreen pauseScreenScript;
    private HealthSystem healthSystem;

    public Rigidbody player;

    void Start()
    {
        playerMovementScript = GameObject.FindObjectOfType<PlayerMovement>();
        audioManagerScript = GameObject.FindObjectOfType<AudioManager>();
        pauseScreenScript = GameObject.FindObjectOfType<PauseScreen>();
        healthSystem = GameObject.FindObjectOfType<HealthSystem>();
    }

    void Update()
    {
        if (playerMovementScript.grounded == true && player.velocity.magnitude > 2f && GetComponent<AudioSource>().isPlaying == false && pauseScreenScript.isPaused == false && healthSystem.isDead == false)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}