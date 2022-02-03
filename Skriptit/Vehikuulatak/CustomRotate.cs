using UnityEngine;
using TMPro;
using System.Collections;

//Script that spins car wheels

[RequireComponent(typeof(Rigidbody2D))]
public class CustomRotate : MonoBehaviour
{
    public float speed = 1f;
    private float spin;
    private Rigidbody2D rb;

    //Takes rigidbody and saves it to variable
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Detecs if player wants to move
        if (Input.GetKey(KeyCode.RightArrow))
        {
            spin = speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            spin = 0 - speed;
        }
        else
        {
            spin = 0;
        }
    }

    //Spins wheels
    void FixedUpdate()
    {
            rb.AddTorque(-spin * speed);
    }
}