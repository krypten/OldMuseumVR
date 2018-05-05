using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public GameObject player;
	public GameObject raycastHolder;
	public GameObject raycastIndicator;
	public float height = 2;
	public bool teleport = true;
	public float maxMoveDistance = 10;

	RaycastHit hit;
	float theDistance;
	private bool isMoving = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 forwardDir = raycastHolder.transform.TransformDirection (Vector3.forward);
		Debug.DrawRay (raycastHolder.transform.position, forwardDir, Color.green);
		Debug.Log("Debug entered");

		if (Physics.Raycast (raycastHolder.transform.position, (forwardDir), out hit)) {
			Debug.Log("Raycast Hit ");

			if (hit.collider.gameObject.tag == "movementCapable") {
				Debug.Log("Raycast Hit movementCapable");
				ManageIndicator ();
				if (hit.distance <= maxMoveDistance) { //If we are close enough
					Debug.Log("Raycast Hit movementCapable in distance");

					//If the indicator isn't active already make it active.
					if (raycastIndicator.activeSelf == false) {
						raycastIndicator.SetActive (true);
					}

					if (Input.GetMouseButtonDown (0)) {
						if (teleport) {
							teleportMove (hit.point);
						} else {
							DashMove (hit.point);
						}
					}
				} else {
					Debug.Log("Raycast Hit movementCapable out distance");
					if (raycastIndicator.activeSelf == true) {
						raycastIndicator.SetActive (false);
					}
				}
			}
				
		}
	}

	public void ManageIndicator() {
		if (!teleport) {
			if (isMoving != true) {
				raycastIndicator.transform.position = hit.point;
			}
			if(Vector3.Distance(raycastIndicator.transform.position, player.transform.position) <= 2.5) {
				isMoving = false;
			}

		} else {
			raycastIndicator.transform.position = hit.point;
		}
	}

	public void DashMove(Vector3 location) {
		isMoving = true;

		iTween.MoveTo (player, 
			iTween.Hash (
				"position", new Vector3 (location.x, location.y + height, location.z), 
				"time", .2F, 
				"easetype", "linear"
			)
		);
	}

	public void teleportMove(Vector3 location) {
		player.transform.position = new Vector3 (location.x, location.y + height, location.z);
	}
}
