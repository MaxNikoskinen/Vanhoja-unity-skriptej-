using UnityEngine;

//Stops game objects from getting destroyed on scene change

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
