using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class MessageTrigger : MonoBehaviour
{
    public GameObject panel; // The UI panel that will show the message
    public TextMeshProUGUI messageText; // The TextMeshProUGUI component to display the message
    public string message;   // The message that will be displayed

    private bool isMessageActive = false;

    void Start()
    {
        // Ensure the panel is initially inactive
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    // This function gets called when the BoxCollider is triggered
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure it's the player that triggered the collider
        {
            ShowMessage();
        }
    }

    // Function to display the message and activate the panel
    void ShowMessage()
    {
        if (panel != null && messageText != null)
        {
            messageText.text = message;
            panel.SetActive(true);
            isMessageActive = true;
        }
    }

    // Function to hide the message and deactivate the panel
    void HideMessage()
    {
        if (panel != null)
        {
            panel.SetActive(false);
            isMessageActive = false;
        }
    }

    void Update()
    {
        // If the message is active, check if the user presses the "X" key
        if (isMessageActive && Input.GetKeyDown(KeyCode.X))
        {
            HideMessage();
        }
    }
}

