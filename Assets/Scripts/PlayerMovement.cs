using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float playerSpeed = 0.5f;
	public float maxSpeed = 20.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = movePlayer (this.transform.position);
		Rigidbody2D playerBody = this.GetComponentInChildren<Rigidbody2D> ();
		limitSpeed (playerBody);
	}
	Vector3 movePlayer(Vector3 initPos){
		Vector3 newPos = initPos;
		newPos.x += Input.GetAxis ("Horizontal") * playerSpeed;
		newPos.y += Input.GetAxis ("Vertical") * playerSpeed;
		return newPos;
	}
	void limitSpeed(Rigidbody2D body){
		Debug.Log (this + " speed: " + body.velocity.magnitude);
		if (body) {
			if (body.velocity.magnitude > maxSpeed) {
				body.velocity = body.velocity.normalized * maxSpeed;
			}
		}
	}	
}
