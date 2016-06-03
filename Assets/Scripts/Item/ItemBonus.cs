using UnityEngine;
using System.Collections;

public class ItemBonus : MonoBehaviour
{
	public int bonus;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") {
			Player.bonus += bonus;
			Destroy(transform.gameObject);
		}
	}
}
