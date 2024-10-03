using UnityEngine;

public class BossLogicManager : MonoBehaviour
{
    // Reference to the main BOSS GameObject
    public GameObject boss;

    void Start()
    {
        // Find the Player object in the scene (make sure the Player tag is set correctly)
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player not found in the scene. Make sure the Player has the 'Player' tag.");
            return;
        }

        // Handle case for "Boss Demon 1" child and EnemyAI script
        AttachEnemyAITarget(player);

        // Handle case for "Undead Executioner" or "Hero Knight" as children of the boss object and Boss script
        AttachBossTarget(player);
    }

    // Method to attach the player to the EnemyAI script on "Boss Demon 1" child
    void AttachEnemyAITarget(GameObject player)
    {
        // Find the child game object "Boss Demon 1" under the boss
        Transform bossDemon1 = boss.transform.Find("Boss Demon 1");

        if (bossDemon1 != null)
        {
            // Get the EnemyAI component on the "Boss Demon 1" child object
            EnemyAi enemyAI = bossDemon1.GetComponent<EnemyAi>();

            if (enemyAI != null)
            {
                // Attach the Player as the target for the EnemyAI script
                enemyAI.target = player.transform;
                Debug.Log("Player successfully assigned to the EnemyAI target.");
            }
            else
            {
                Debug.LogError("EnemyAI component not found on Boss Demon 1.");
            }
        }
        else
        {
            Debug.Log("Boss Demon 1 not found as a child of the boss object.");
        }
    }

    // Method to attach the player to the Boss script on "Undead Executioner" or "Hero Knight" child objects
    void AttachBossTarget(GameObject player)
    {
        // Find the "Undead Executioner" or "Hero Knight" as children of the boss object
        Transform undeadExecutioner = boss.transform.Find("Undead executioner");
        Transform heroKnight = boss.transform.Find("Hero Knight");

        // Handle Undead Executioner
        if (undeadExecutioner != null)
        {
            AttachPlayerToBossScript(undeadExecutioner, player);
        }
        // Handle Hero Knight
        else if (heroKnight != null)
        {
            AttachPlayerToBossScript(heroKnight, player);
        }
        else
        {
            Debug.LogError("Neither 'Undead Executioner' nor 'Hero Knight' found as children of the boss object.");
        }
    }

    // Helper method to attach the player to the Boss script on the given child
    void AttachPlayerToBossScript(Transform bossChild, GameObject player)
    {
        // Get the Boss component from the child object
        Boss bossScript = bossChild.GetComponent<Boss>();

        if (bossScript != null)
        {
            // Attach the Player as the target for the Boss script
            bossScript.player = player.transform;
            Debug.Log($"Player successfully assigned to the {bossChild.name} player field.");
        }
        else
        {
            Debug.LogError($"Boss component not found on {bossChild.name}.");
        }
    }
}


