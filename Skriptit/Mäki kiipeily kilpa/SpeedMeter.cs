using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class SpeedMeter : MonoBehaviour
{
    public TMP_Text speedMeterText;
    public Rigidbody2D rb;
    float speed = 1;

    private void Update()
    {
        speed = rb.velocity.magnitude;
        speed = Mathf.Round(speed);
        speedMeterText.text = speed.ToString() + " kmh";
    }
}
