using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRaycast : MonoBehaviour
{
    public Camera mainCamera;
    public float range = 100f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
        {
            InteractableObject InteractableObject = hit.transform.GetComponent<InteractableObject>();

            if(InteractableObject != null)
            {
                Debug.Log("Interactable object : " + hit.transform.name);
                InteractableObject.DecideObject();
            }
            else
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}
