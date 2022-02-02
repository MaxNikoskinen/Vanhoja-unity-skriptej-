using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameOver : MonoBehaviour
{
    private GasSystem gasSystem;

    private void Start()
    {
        gasSystem = GameObject.FindObjectOfType<GasSystem>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Ground"))
        {
            gasSystem.EmptyGas();
        }
    }
}
