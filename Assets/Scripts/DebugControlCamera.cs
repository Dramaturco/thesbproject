using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugControlCamera : MonoBehaviour {
	public float cameraSpeed = 0.5f;
	public bool debugMode = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (debugMode) {
			this.transform.position = moveCamera (this.transform.position);
		}
	}
	Vector3 moveCamera(Vector3 initPos){
		Vector3 newPos = initPos;
		newPos.x += Input.GetAxis ("Horizontal") * cameraSpeed;
		newPos.y += Input.GetAxis ("Vertical") * cameraSpeed;
		return newPos;
	}
}
