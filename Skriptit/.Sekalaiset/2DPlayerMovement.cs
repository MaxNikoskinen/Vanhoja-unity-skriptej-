using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    float regularSpeedOriginal;

    public float runSpeed = 7.5f;
    public float slowSpeed = 2.5f;

    public SpriteRenderer hitBox;
    public Color regularHitboxColor = Color.clear;
    public Color focusHitboxColor = Color.red;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        regularSpeedOriginal = runSpeed;
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        // Hidastus
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            runSpeed = slowSpeed;
            hitBox.color = focusHitboxColor;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            runSpeed = regularSpeedOriginal;
            hitBox.color = regularHitboxColor;
        }
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
