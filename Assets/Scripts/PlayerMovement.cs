using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speedScaleFactor = 1.0f;
	public float airSpeed = 2.0f;
	public float groundSpeed = 5.0f;
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
		float playerSpeed = 0.0f;
		//check if player touches ground
		if (this.isGrounded()) {
			playerSpeed = groundSpeed * speedScaleFactor;
		} else {
			playerSpeed = airSpeed * speedScaleFactor;
		}
		//apply speed to rigidbody
		playerBody.velocity = new Vector2 (Input.GetAxis ("Horizontal") * playerSpeed, playerBody.velocity.y);
	}
	void limitSpeed(){
		//Debug.Log (this + " speed: " + playerBody.velocity.magnitude);
		if (playerBody) {
			if (playerBody.velocity.magnitude > maxSpeed) {
				playerBody.velocity = playerBody.velocity.normalized * maxSpeed;
			}
		}
	}
	bool isGrounded(){
		if (Mathf.Abs (playerBody.velocity.y) < 0.01) {
			return true;
		}
		return false;
	}
}
