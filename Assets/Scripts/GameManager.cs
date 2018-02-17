using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public float planeSpawnRate = 0.3f; //percent chance of a plane appearing per second
	public GameObject plane;
	private GameObject[] players;
	private Camera camera;

	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");
		camera = Camera.main;
	}

	float getLeftScreenEdge(){
		return camera.ScreenToWorldPoint (new Vector3(0, 0, 10.0f)).x;
	}
	
	float getRightScreenEdge(){
		return camera.ScreenToWorldPoint (new Vector3(camera.pixelWidth, 0, 10.0f)).x;
	}
}
