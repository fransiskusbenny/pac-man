using UnityEngine;
using System.Collections;

public class PelletEaten : MonoBehaviour
{
	public int scoreValue = 10;


	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") {
			Player.score += scoreValue * Player.bonus;
			Destroy(transform.gameObject);
		} else if (col.tag == "Ghost")
			Destroy(transform.gameObject);
	}
}