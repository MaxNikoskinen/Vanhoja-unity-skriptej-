using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Medkit : MonoBehaviour
{
    private HealthSystem healthSystemScript;

    public int healthToGive;
    public Ammobar healthbarScript;
    public TMP_Text healthStatusText;
    public GameObject pickupEffect;

    private AudioManager audioManagerScript;

    private void Start()
    {
        healthSystemScript = FindObjectOfType<HealthSystem>();
        audioManagerScript = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && healthSystemScript.currentHealth < healthSystemScript.health)
        {
            healthSystemScript.currentHealth += healthToGive;

            if(healthSystemScript.currentHealth > healthSystemScript.health)
            {
                healthSystemScript.currentHealth = healthSystemScript.health;
            }

            healthbarScript.current = healthSystemScript.currentHealth;
            healthStatusText.text = healthSystemScript.currentHealth.ToString() + " %";
            audioManagerScript.Play("Medkit Use");
            Destroy(gameObject);
            GameObject particle = Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(particle, 5f);
        }
    }
}
