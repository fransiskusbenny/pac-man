using UnityEngine;
using System.Collections;

public class GhostGuard : MonoBehaviour
{
	BehaviorRules behaviorRules;
	Transform target;
	Seeker seeker;

	GameObject[] waypoints;
	int waypointIndex;
	bool isGuard;
	// Use this for initialization
	void Start()
	{
		behaviorRules = new BehaviorRules();

		seeker = GetComponent<Seeker>();
		target = GameObject.FindGameObjectWithTag("Player").transform as Transform;

		waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		StartCoroutine(CheckBehavior());
	}
	
	// Update is called once per frame
	void Update()
	{
		float result = behaviorRules.Rule(Player.distance, Player.health, Player.bonus, Player.score);
		if (result >= 0 && result <= 0.33f) {
			isGuard = true;
		} else {
			isGuard = false;
		}
	}

	IEnumerator CheckBehavior()
	{
		while (true) {
			Debug.Log("Guard " + isGuard);
			if (isGuard)
				StartCoroutine(Guard(isGuard));
			else
				StartCoroutine(Patrol(isGuard));
			
			yield return new WaitForSeconds(5f);
		}
	}

	IEnumerator Guard(bool isGuard)
	{
		while (isGuard) {
			seeker.StartPathing(ClosestItem().position);
			yield return new WaitForSeconds(0.5f);
		}

	}

	Transform ClosestItem()
	{
		GameObject[] items;
		items = GameObject.FindGameObjectsWithTag("Item");
		Transform tmin = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = transform.position;
		foreach (GameObject t in items) {
			float dist = Vector3.Distance(t.transform.position, currentPos);
			if (dist < minDist) {
				tmin = t.transform;
				minDist = dist;
			}
		}
		return tmin;
	}

	IEnumerator Patrol(bool isGuard)
	{
		while (!isGuard) {
			//Enamy Patrol
			waypointIndex = Random.Range(0, waypoints.Length);
			Transform waypoint = waypoints[waypointIndex].transform;
			//					float distance = Vector3.Distance(transform.position, target.position);
			//					if (distance < 500f) {
			//						seeker.StartPathing(target.position);
			//					}
			seeker.StartPathing(waypoint.position);

			yield return new WaitForSeconds(7f);
		}
	}

}
