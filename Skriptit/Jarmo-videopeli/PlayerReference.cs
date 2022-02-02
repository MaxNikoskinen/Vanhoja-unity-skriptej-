using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReference : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.player = this.gameObject;
    }
}
