using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehaviour : MonoBehaviour {
	private bool facingLeft = true;
	public float speed = 0.5f;
	// Use this for initialization
	void Start () {
		if (Random.value < 0.5) {
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
	}
	void flip() {
		facingLeft = !facingLeft;
		Vector2 localScale = this.transform.localScale;
		localScale.x *= -1;
		this.transform.localScale = localScale;
	}
}
