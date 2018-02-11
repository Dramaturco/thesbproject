using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private int frameCount = 0;
	public float planeSpawnRate = 0.3f; //percent chance of a plane appearing per second
	public GameObject plane;
	private GameObject[] players;
	private Camera camera;
	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");
		camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		frameCount++;
		spawnPlane ();
		Debug.DrawLine (new Vector3 (0, 0, 0), new Vector3 (Screen.width, 0, 0), Color.red);
	}
	void spawnPlane() {
		if (frameCount > 60) {
			frameCount = 0;
			if (Random.value < planeSpawnRate) {
				Instantiate (plane, getSpawnPos(), Quaternion.identity);
			}
		}
	}
	Vector3 getSpawnPos(){
		Vector3 spawnPos = new Vector3 (0, 500, 0);
		foreach (GameObject player in players) {
			float playerY = player.transform.position.y;
			if (playerY < spawnPos.y) {
				spawnPos.y = playerY;
			}
		}
		if (Random.value < 0.5f) {
			spawnPos.x = getLeftScreenEdge ();
		} else {
			spawnPos.x = getRightScreenEdge ();
		}
		spawnPos.y -= 20f;
		return spawnPos;
	}
	float getLeftScreenEdge(){
		return camera.ScreenToWorldPoint (new Vector3(0, 0, 10.0f)).x;
	}
	float getRightScreenEdge(){
		return camera.ScreenToWorldPoint (new Vector3(camera.pixelWidth, 0, 10.0f)).x;
	}
}
