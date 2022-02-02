using UnityEngine;
using TMPro;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class CustomRotate : Physics2DObject
{
	public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;
	public float speed = 1f;
	private float spin;
    public GasSystem gasSystem;

    void Start()
    {
        gasSystem = GameObject.FindObjectOfType<GasSystem>();
        speed = PlayerPrefs.GetFloat("Speed", 1);
    }

    void Update ()
	{
        PlayerPrefs.SetFloat("Speed", speed);

        if (gasSystem.amountOfGasoline > 0)
        {
            if (typeOfControl == Enums.KeyGroups.ArrowKeys)
            {
                spin = Input.GetAxis("Horizontal");
            }
            else
            {
                spin = Input.GetAxis("Horizontal2");
            }
        }
        else return;
    }

	void FixedUpdate ()
	{
        if (gasSystem.amountOfGasoline > 0)
        {
            rigidbody2D.AddTorque(-spin * speed);
        }
	}

    public void MoreEnginePower()
    {
        PlayerPrefs.SetFloat("Speed", speed);
        speed++;
    }

    public void LessEnginePower()
    {
        PlayerPrefs.SetFloat("Speed", speed);
        if (speed > 1)
        {
            speed--;
        }
        else return;
    }
}
