using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehaviour : MonoBehaviour {
	private bool facingLeft = true;
	public float speed = 0.5f;
	private float planeWidth;

	// Use this for initialization
	void Start () {
		planeWidth = GetComponent<BoxCollider2D> ().bounds.size.x;
	}
	void Awake() {
		//if the plane spawns on the left side of the screen it should face right
		Debug.Log(this + "spawned at: " + this.transform.position);
		if (this.transform.position.x < 0) {
			flip ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 pos = this.transform.position;
		if (facingLeft) {
			pos.x -= speed;
		} else {
			pos.x += speed;
		}
		this.transform.position = pos;
		if (pos.x >= getRightScreenEdge() + planeWidth || pos.x <= getLeftScreenEdge() - planeWidth) {
			//die ();
		}
	}
	void flip() {
		facingLeft = !facingLeft;
		Vector2 localScale = this.transform.localScale;
		localScale.x *= -1;
		this.transform.localScale = localScale;
	}
	void die() {
        //this is a function in case we want to play some animation and sound upon death
        Debug.Log(this + "died at: " + this.transform.position);
		Destroy (this.gameObject);
	}
	float getLeftScreenEdge(){
		return Camera.main.ScreenToWorldPoint (new Vector3(0, 0, 10.0f)).x;
	}

	float getRightScreenEdge(){
		return Camera.main.ScreenToWorldPoint (new Vector3(Camera.main.pixelWidth, 0, 10.0f)).x;
	}
}
