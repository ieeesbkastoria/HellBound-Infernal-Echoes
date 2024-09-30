using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

 void OnTriggerEnter2D(Collider2D other)
{
    // Check if the object's name is NOT "Tilemap"
    if (other.gameObject.name != "Tilemap" && other.gameObject.name != "Player")
    {
        // If the object is not named "Tilemap", destroy it
        Destroy(other.gameObject);
    }
    else
    {
        // Optional: Log message if the object is "Tilemap" to verify it's not destroyed
        Debug.Log("Tilemap object entered the trigger but was not destroyed.");
    }
}
}
