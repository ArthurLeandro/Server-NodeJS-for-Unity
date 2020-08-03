using UnityEngine;
using System.Collections;

public class ClickFollow : MonoBehaviour, IClickable {

	public GameObject myPlayer;
	public NetworkEntity networkEntity;

	Targeter myPlayerTarget;

	void Start() { 
		networkEntity = GetComponent<NetworkEntity> ();
		myPlayerTarget = myPlayer.GetComponent<Targeter> ();
	}

	public void OnClick (RaycastHit hit)
	{
		Debug.Log ("following " + hit.collider.gameObject.name);

		Network.Follow (networkEntity.id);

		myPlayerTarget.target = transform;
	}
}
