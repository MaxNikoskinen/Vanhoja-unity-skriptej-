using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorTrigger : MonoBehaviour
{
    [SerializeField] private Renderer sprite;
    [SerializeField] private Color colorToChangeTo = Color.white;

    private void OnTriggerEnter2D(Collider2D colliderData)
    {
        sprite.material.color = colorToChangeTo;
    }
}
