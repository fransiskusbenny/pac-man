using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
	public Slider playerHealth;

	public static float distance;
	public static float health = 100f;
	public static float score = 0;
	public static float bonus = 1;

	public Text scoreText;
	public float damageMin;
	public float damageMax;


	void Start()
	{

	}

	void Update()
	{ 
		distance = Vector3.Distance(transform.position * 100, GetClosestGhost().position * 100);
		scoreText.text = score.ToString();
		playerHealth.value = health;
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Ghost") {
			TakeDamage();
		}
	}

	Transform GetClosestGhost()
	{
		GameObject[] ghost;
		ghost = GameObject.FindGameObjectsWithTag("Ghost");
		Transform tMin = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = transform.position;
		foreach (GameObject t in ghost) {
			float dist = Vector3.Distance(t.transform.position, currentPos);
			if (dist < minDist) {
				tMin = t.transform;
				minDist = dist;
			}
		}

		return tMin;
	}

	void TakeDamage()
	{
		health -= Mathf.RoundToInt(Random.Range(damageMin, damageMax));
	}
}
