using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour {

	public Targeter targeter;

	public float scanFrequency = 0.5f;
	public float stopFollowDistance = 2;

	NavMeshAgent agent;

	float lastScanTime = 0;

	void Start() {
		agent = GetComponent<NavMeshAgent> ();
		targeter = GetComponent<Targeter> ();
	}

	void Update () {
	
		if (isReadyToScan () && !targeter.IsInRange(stopFollowDistance)) {
			Debug.Log ("scanning nav path");
			agent.SetDestination(targeter.target.position);
			lastScanTime = Time.time;
		}
	}

	bool isReadyToScan ()
	{
		return Time.time - lastScanTime > scanFrequency && targeter.target;
	}
}
