using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;

    void Update()
    {
        if (waitTime <= 0 && spawnedBoss == false)
        {
            if (rooms.Count > 0)
            {
                // Get the last room in the list
                GameObject bossRoom = rooms[rooms.Count - 1];

                // Instantiate the boss in the last room
                Instantiate(boss, bossRoom.transform.position, Quaternion.identity);

                // Attempt to find and enable the checkpoint in the boss room
                EnableCheckpointInRoom(bossRoom);

                spawnedBoss = true;
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    private void EnableCheckpointInRoom(GameObject room)
    {
        // Look for the checkpoint in the room's children
        Transform checkpointTransform = room.transform.Find("ChackPoint");  // Replace "Checkpoint" with the name of your checkpoint prefab if it's different

        if (checkpointTransform != null)
        {
            checkpointTransform.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Checkpoint not found in the boss room. Make sure the checkpoint is named correctly and is a child of the room.");
        }
    }
}


