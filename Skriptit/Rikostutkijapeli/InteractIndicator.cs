using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractIndicator : MonoBehaviour
{
    public GameObject speakIndicator;
    public TMP_Text text;
    public Camera mainCamera;
    public float range = 10;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
        {
            InteractableObject InteractableObject = hit.transform.GetComponent<InteractableObject>();

            if (InteractableObject != null)
            {
                InteractableObject.DecideObjectIndicator();
            }
            else
            {
                speakIndicator.SetActive(false);
            }
        }
        else
        {
            speakIndicator.SetActive(false);
        }
    }
}
