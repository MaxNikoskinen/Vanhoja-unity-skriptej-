using UnityEngine;
using System.Collections;

public class TimedSelfDestruct : MonoBehaviour
{
	public float timeToDestruction;

	void Start ()
	{
		Invoke("DestroyMe", timeToDestruction);
	}

	void DestroyMe()
	{
		Destroy(gameObject);
	}
}
