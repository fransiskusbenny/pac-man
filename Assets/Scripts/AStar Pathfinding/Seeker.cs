using UnityEngine;
using System.Collections;

public class Seeker : MonoBehaviour
{
	bool isDead;
	public float speed;
	Vector3[] path;
	int targetindex;

	public void StartPathing(Vector3 target)
	{
		PathRequestManager.RequestPath(transform.position, target, OnPathFound);
	}

	public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
	{
		if (pathSuccessful) {
			if (!isDead) {
				path = newPath;
				StopCoroutine("FollowPath");
				StartCoroutine("FollowPath");
			}
		}
	}

	IEnumerator FollowPath()
	{
		if (path.Length > 0) {
			Vector3 currentWayPoint = path[0];

			while (true) {
				if (transform.position == currentWayPoint) {
					targetindex++;
					if (targetindex >= path.Length) {
						targetindex = 0;
						path = new Vector3[0];
						yield break;
					}
					currentWayPoint = path[targetindex];
				}
				transform.position = Vector3.MoveTowards(transform.position, currentWayPoint, speed * Time.fixedDeltaTime);
				yield return null;
			}
		}
	}

	public void OnDrawGizmos()
	{
		if (path != null) {
			for (int i = targetindex; i < path.Length; i++) {
				Gizmos.color = Color.black;
				Gizmos.DrawCube(path[i], Vector3.one);

				if (i == targetindex) {
					Gizmos.DrawLine(transform.position, path[i]);
				} else {
					Gizmos.DrawLine(path[i - 1], path[i]);
				}
			}
		}
	}
}