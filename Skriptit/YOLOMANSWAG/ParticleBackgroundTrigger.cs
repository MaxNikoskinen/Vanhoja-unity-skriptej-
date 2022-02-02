using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBackgroundTrigger : MonoBehaviour
{
    [Tooltip("true = enable particles, false = disable particles")]
    [SerializeField] private bool portalMode;
    private Player playerClass;
    private string playerTag = "Player";
    [SerializeField] private GameObject backgroundParticles;

    void Start()
    {
        playerClass = GameObject.FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            if(portalMode)
            {
                backgroundParticles.SetActive(true);
            }
            else
            {
                backgroundParticles.SetActive(false);
            }
        }
    }
}
