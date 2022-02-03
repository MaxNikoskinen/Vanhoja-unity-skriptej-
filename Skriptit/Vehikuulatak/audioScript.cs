using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour
{
    [SerializeField] AudioSource ‰‰ni;

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            ‰‰ni.Play();
        }
        else
        {
            ‰‰ni.Stop();
        }

    }

}
