using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public int objectStyle;
    public GameObject trollFaceDialogue = null;
    public CursorChange cursorChangeScript = null;
    public PlayerMovementCC playerMovementScript = null;
    public MouseLookCC mouseLookScript = null;
    public InteractIndicator interactIndicatorScript = null;
    public Animator doorAnim = null;
    public float rateOfDoorOpening = 1f;
    public string indicatorText = "(E) Avaa";
    public string indicatorTextAlt = "(E) Sulje";




    private Inventory inventoryScript = null;
    private UIInventory uiInventoryScript = null;
    private float nextTimeToOpen = 0f;
    private bool doorOpen = false;



    private void Start()
    {
        inventoryScript = GameObject.FindObjectOfType<Inventory>();
        uiInventoryScript = GameObject.FindObjectOfType<UIInventory>();
    }

    public void DecideObject()
    {
        if(objectStyle == 0)
        {
            Conversation();
        }
        else if (objectStyle == 1)
        {
            CollectItem();
        }
        else if (objectStyle == 2)
        {
            DoDoor();
        }
    }

    public void DecideObjectIndicator()
    {
        if (objectStyle == 0)
        {
            ConversationIndicator();
        }
        else if (objectStyle == 1)
        {
            CollectItemIndicator();
        }
        else if (objectStyle == 2)
        {
            DoDoorIndicator();
        }
    }



    
    public void Conversation()
    {
        trollFaceDialogue.SetActive(true);
        cursorChangeScript.ShowCursor();
        mouseLookScript.allowLooking = false;
        playerMovementScript.allowMovement = false;
    }

    public void ConversationIndicator()
    {
        interactIndicatorScript.speakIndicator.SetActive(true);
        interactIndicatorScript.text.text = indicatorText;
    }




    public void CollectItem()
    {
        uiInventoryScript.RefreshInventoryItems();
        uiInventoryScript.AddItemMap();
        Destroy(gameObject);
        
    }

    public void CollectItemIndicator()
    {
        interactIndicatorScript.speakIndicator.SetActive(true);
        interactIndicatorScript.text.text = indicatorText;
  
    }







    public void DoDoor()
    {
        if(Time.time >= nextTimeToOpen)
        {
            if (doorOpen == false)
            {
                doorAnim.Play("DoorOpen", 0, 0.0f);
                doorOpen = true;
                nextTimeToOpen = Time.time + 1f / rateOfDoorOpening;
            }
            else
            {
                doorAnim.Play("DoorClose", 0, 0.0f);
                doorOpen = false;
                nextTimeToOpen = Time.time + 1f / rateOfDoorOpening;
            }
        }
        
    }

    public void DoDoorIndicator()
    {
        interactIndicatorScript.speakIndicator.SetActive(true);
        if (doorOpen == false)
        {
            interactIndicatorScript.text.text = indicatorText;
        }
        else
        {
            interactIndicatorScript.text.text = indicatorTextAlt;
        }
    }
}
