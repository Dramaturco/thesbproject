using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingForBGObjects : MonoBehaviour {

    /// <summary>
    /// Scrolling speed
    /// </summary>
    public Vector2 speed = new Vector2(2, 2);

    /// <summary>
    /// Moving direction
    /// </summary>
    public Vector2 direction = new Vector2(0, 1);

    /// <summary>
    /// Movement should be applied to camera
    /// </summary>
    public bool isLinkedToCamera = false;
    private void Awake()
    {
        speed = new Vector2(Random.Range(0.5f, 1.5f), Random.Range(0.5f, 1.5f));
    }
    void Update()
    {
        // Movement
        Vector3 movement = new Vector3(
          speed.x * direction.x,
          speed.y * direction.y,
          0);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        // Move the camera
        if (isLinkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }
    }
}
