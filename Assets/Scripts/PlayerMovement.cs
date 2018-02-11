using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float playerSpeed = 0.5f;
	public float maxSpeed = 20.0f;
	private Rigidbody2D playerBody;

	// Use this for initialization
	void Start () {
		playerBody = this.GetComponentInChildren<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		movePlayer ();
		limitSpeed ();
	}
	void movePlayer(){
		playerBody.velocity = new Vector2 (Input.GetAxis ("Horizontal") * playerSpeed, playerBody.velocity.y);
	}
	void limitSpeed(){
		Debug.Log (this + " speed: " + playerBody.velocity.magnitude);
		if (playerBody) {
			if (playerBody.velocity.magnitude > maxSpeed) {
				playerBody.velocity = playerBody.velocity.normalized * maxSpeed;
			}
		}
	}	
}
