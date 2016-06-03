using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{

	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "Player") {
			Destroy(transform.gameObject);
		}
	}
		
}