using UnityEngine;
using System.Collections;

public class GhostBrutal : MonoBehaviour
{

	BehaviorRules behaviorRules;
	Transform target;
	Seeker seeker;

	GameObject[] waypoints;
	int waypointIndex;

	bool isBrutal;

	void Start()
	{
		behaviorRules = new BehaviorRules();

		seeker = GetComponent<Seeker>();
		target = GameObject.FindGameObjectWithTag("Player").transform as Transform;

		waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		StartCoroutine(CheckBehavior());
	}

	void Update()
	{
		float result = behaviorRules.Rule(Player.distance, Player.health, Player.bonus, Player.score);
		if (result >= 0.67f && result <= 1) {
			isBrutal = true;
		} else {
			isBrutal = false;
		}
	}

	IEnumerator CheckBehavior()
	{
		while (true) {
			Debug.Log("Brutal " + isBrutal);
			if (isBrutal)
				StartCoroutine(Brutal(isBrutal));
			else
				StartCoroutine(Patrol(isBrutal));
			
			yield return new WaitForSeconds(4f);
		}
	}

	IEnumerator Brutal(bool isBrutal)
	{
		while (isBrutal) {
			seeker.StartPathing(target.position);
			yield return new WaitForSeconds(0.5f);
		}

	}

	IEnumerator Patrol(bool isBrutal)
	{
		while (!isBrutal) {
			//Enamy Patrol
			waypointIndex = Random.Range(0, waypoints.Length);
			Transform waypoint = waypoints[waypointIndex].transform;
			//					float distance = Vector3.Distance(transform.position, target.position);
			//					if (distance < 500f) {
			//						seeker.StartPathing(target.position);
			//					}
			seeker.StartPathing(waypoint.position);

			yield return new WaitForSeconds(5f);
		}
	}
}
