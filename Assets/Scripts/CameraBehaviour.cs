using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {
	GameObject[] players;
	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		float minY = 500f;
		foreach (GameObject player in players) {
			float playerY = player.transform.position.y;
			if (playerY < minY) {
				minY = playerY;
			}
		}
		updateCameraY (minY);
	}
	void updateCameraY(float newY){
		Vector3 cameraPos = this.transform.position;
		cameraPos.y = newY;
		this.transform.position = cameraPos;
	}
}
