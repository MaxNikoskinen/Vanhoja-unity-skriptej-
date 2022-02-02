using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    private AudioManager audioManagerScript;

    public CharacterController controller;

    public Healthbar healthbarScript;

    public TMP_Text healthText;

    public GameObject deathScreen;


    private float nextTimeToFire = 0f;
    public GameObject player;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float health = 100f;

    private float currentHealth = 100f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    [HideInInspector] public bool isDead;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioManagerScript = FindObjectOfType<AudioManager>();
        healthbarScript.SetMaxHealth(health);
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(currentHealth > 0)
        {
            if (hit.gameObject.CompareTag("Enemy") && Time.time >= nextTimeToFire)
            {
                TakeDamage(5);
                nextTimeToFire = Time.time + 1f / 1;
            }
        }
        
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        audioManagerScript.Play("Sword Swing");
        healthText.text = currentHealth.ToString() + "%";
        healthbarScript.SetHealth(currentHealth);
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        speed = 0;
        gravity = 0;
        jumpHeight = 0;
        currentHealth = 0;
        healthText.text = currentHealth.ToString() + "%";
        healthbarScript.SetHealth(currentHealth);
        isDead = true;
        deathScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
