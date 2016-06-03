using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySightTest : MonoBehaviour
{
	//	public float sightDist;
	public float viewRadius;
	public float viewAngle;
	public LayerMask targetMask;

	void Start()
	{
		StartCoroutine(FindTargetsWithDelay(0.2f));
	}

	Vector3 DirFromAngle(float angleInDegrees)
	{
		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
	}

	//	void OnDrawGizmos()
	//	{
	//		UnityEditor.Handles.color = Color.white;
	//		UnityEditor.Handles.DrawWireArc(transform.position, Vector3.up, Vector3.forward, 360, viewRadius);
	//	}

	IEnumerator FindTargetsWithDelay(float delay)
	{
		while (true) {
			yield return new WaitForSeconds(delay);
			FindVisibleTargets();
		}
	}

	void FindVisibleTargets()
	{
		Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

		for (int i = 0; i < targetInViewRadius.Length; i++) {
			if (targetInViewRadius[i].tag == "Player") {
				Debug.Log("Player in view radius");
			} else {
				Debug.Log("Player not in view radius");
			}
		}
	}



}
