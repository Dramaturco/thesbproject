using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speedScaleFactor = 1.0f;		//overall scale factor applied last (to tweak all speeds at once)
	public float airSpeed = 2.0f;				
	public float groundSpeed = 5.0f;
	public float maxSpeed = 15.0f;				//this is actually to limit fall speed and probably the most important dial
    public float umbrellaOpenSpeed = 7.5f;      //this is the fall speed limit when the umbrella is open
	public float playerJumpPower = 1000.0f;
	public int 	 playerJumpBoostLimit = 30;		//indicates how many frames you can hold the button to boost the jump
	private Rigidbody2D playerBody;
	private bool jumping = false;
	private int jumpFrameCounter = 0;
    private float jumpSwapVariable = 0.0f;

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
		if(Input.GetButtonDown("Jump")){
            if (isGrounded()){
                jumping = true;
            }
            else{
                jumpSwapVariable = maxSpeed;
                maxSpeed = umbrellaOpenSpeed;
            }
		}
		if (Input.GetButtonUp ("Jump")) {
			jumpFrameCounter = 0;
			jumping = false;
			if (jumpSwapVariable != 0.0f) {
				maxSpeed = jumpSwapVariable;
				jumpSwapVariable = 0.0f;
			}
		}
		if (jumping && jumpFrameCounter < playerJumpBoostLimit) {
			jumpFrameCounter++;
			jump ();
		}
	}
	void jump(){
		float diminisher = (jumpFrameCounter + 1);
		playerBody.AddForce (Vector2.up * playerJumpPower / diminisher);
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
