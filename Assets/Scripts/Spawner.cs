using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnCollection;
    public Vector2 bounds = new Vector2(1,1);
    private Vector2 centeredBounds;

    public float secondsTillStart = 3f;
    public float secondsTillRepeat = 1f;
    
    void Awake() {
        centeredBounds = bounds/2;
        InvokeRepeating("SpawnItemFromCollection", secondsTillStart, secondsTillRepeat);
    }

    void SpawnItemFromCollection()
    {
        var randomX = transform.position.x + Random.Range(-centeredBounds.x, centeredBounds.x);
        var randomY = transform.position.y + Random.Range(-centeredBounds.y, centeredBounds.y);
        var randomPositionInBounds =  new Vector3(randomX, randomY, 0);
        
        var randomGameObjectIndex = Random.Range(0, spawnCollection.Length);
        
        Instantiate(spawnCollection[randomGameObjectIndex], randomPositionInBounds, Quaternion.identity);
    }
    
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        var style = new GUIStyle();
        style.normal.textColor = Color.red;
        style.fontStyle = FontStyle.Bold;
        
        var editorCenteredBounds = bounds/2;
        Gizmos.DrawWireCube(transform.position, new Vector3(bounds.x, bounds.y, 1));
        Handles.Label(new Vector3(transform.position.x - editorCenteredBounds.x, transform.position.y + editorCenteredBounds.y, 1), "Spawner", style);
    }
}