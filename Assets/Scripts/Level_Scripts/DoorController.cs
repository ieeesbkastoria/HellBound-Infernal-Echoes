using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [System.Serializable]
    public class Gate
    {
        public GameObject gateObject; // The parent GameObject of the gate
        [HideInInspector] public GameObject hitbox; // The child GameObject representing the hitbox
        [HideInInspector] public GameObject trigger; // The child GameObject representing the trigger
        [HideInInspector] public Animator doorAnimator; // The Animator component on the door sprite
        [HideInInspector] public bool isOpen = true; // The state of the gate
    }

    public List<Gate> gates; // List of gates to control
    public string enemyTag = "Enemy"; // Tag used to identify enemy GameObjects
    public string playerTag = "Player"; // Tag used to identify the player GameObject

    // Start is called before the first frame update
    void Start()
    {
        foreach (Gate gate in gates)
        {
            if (gate.gateObject == null)
            {
                Debug.LogError("Gate GameObject is not assigned.");
                continue;
            }

            // Find the hitbox, trigger, and door sprite child objects
            gate.hitbox = gate.gateObject.transform.Find("hitbox").gameObject;
            gate.trigger = gate.gateObject.transform.Find("trigger").gameObject;
            GameObject doorSprite = gate.gateObject.transform.Find("DoorSprite").gameObject;

            if (gate.hitbox == null)
            {
                Debug.LogError("Hitbox GameObject is not found.");
                continue;
            }

            if (gate.trigger == null)
            {
                Debug.LogError("Trigger GameObject is not found.");
                continue;
            }

            if (doorSprite == null)
            {
                Debug.LogError("DoorSprite GameObject is not found.");
                continue;
            }

            // Get the Animator component from the door sprite
            gate.doorAnimator = doorSprite.GetComponent<Animator>();

            if (gate.doorAnimator == null)
            {
                Debug.LogError("Animator component is not found on the door sprite.");
                continue;
            }

            // Initially open the gate
            gate.hitbox.SetActive(false);
            gate.doorAnimator.SetTrigger("Open");
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Gate gate in gates)
        {
            if (!gate.isOpen)
            {
                CheckEnemies(gate);
            }
        }
    }

    void CheckEnemies(Gate gate)
    {
        // Find all enemies in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        // Check if all enemies are defeated
        if (enemies.Length == 0)
        {
            OpenGate(gate);
        }
    }

    void OpenGate(Gate gate)
    {
        if (gate.hitbox != null && gate.doorAnimator != null)
        {
            // Deactivate the hitbox to open the gate
            gate.hitbox.SetActive(false);

            // Trigger the open animation
            gate.doorAnimator.SetTrigger("Open");

            gate.isOpen = true;
            gate.doorAnimator.SetBool("IsClosed", false);
            Debug.Log("Gate is now open!");
        }
    }

    void CloseGate(Gate gate)
    {
        if (gate.hitbox != null && gate.doorAnimator != null)
        {
            // Activate the hitbox to close the gate
            gate.hitbox.SetActive(true);

            // Trigger the close animation
            gate.doorAnimator.SetTrigger("Close");

            gate.isOpen = false;
            gate.doorAnimator.SetBool("IsClosed", true);
            Debug.Log("Gate is now closed!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered OnTriggerEnter2D");
        if (other.CompareTag(playerTag))
        {
            Debug.Log("collision detected");
            foreach (Gate gate in gates)
            {
                Debug.Log("Loop Entered");
                if (!gate.isOpen)
                {
                    Debug.Log("Closing Gate");
                    CloseGate(gate);
                }
            }
        }
    }
}











