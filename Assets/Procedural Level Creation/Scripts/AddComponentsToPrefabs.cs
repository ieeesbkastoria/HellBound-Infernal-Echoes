using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;

public class AddComponentsToPrefabs : MonoBehaviour
{
    [MenuItem("Tools/Add Tilemap and Composite Collider to Prefabs in Folder")]
    static void AddComponentsToPrefabsInFolder()
    {
        // Folder path where your prefabs are stored (relative to the Assets folder)
        string folderPath = "Assets/IsaacGenTut/Assets/Prefabs/Layer 9"; // Change this to your folder's path

        // Find all prefab files in the folder
        string[] prefabFiles = Directory.GetFiles(folderPath, "*.prefab", SearchOption.AllDirectories);

        foreach (string prefabFile in prefabFiles)
        {
            // Load the prefab
            GameObject prefabInstance = PrefabUtility.LoadPrefabContents(prefabFile);

            // Find the "Grid" object inside the prefab
            GameObject gridObject = prefabInstance.transform.Find("Grid")?.gameObject;

            if (gridObject != null)
            {
                // Find the "Tilemap" object as a child of "Grid"
                GameObject tilemapObject = gridObject.transform.Find("Tilemap")?.gameObject;

                if (tilemapObject != null)
                {
                    // Add TilemapCollider2D if it doesn't already exist
                    if (tilemapObject.GetComponent<TilemapCollider2D>() == null)
                    {
                        tilemapObject.AddComponent<TilemapCollider2D>();
                    }

                    // Add CompositeCollider2D if it doesn't already exist
                    if (tilemapObject.GetComponent<CompositeCollider2D>() == null)
                    {
                        tilemapObject.AddComponent<CompositeCollider2D>();
                    }

                    // Ensure Rigidbody2D exists, as CompositeCollider2D requires it
                    Rigidbody2D rb2D = tilemapObject.GetComponent<Rigidbody2D>();
                    if (rb2D == null)
                    {
                        rb2D = tilemapObject.AddComponent<Rigidbody2D>();
                    }

                    // Set Rigidbody2D to be Kinematic, which is required for CompositeCollider2D to work properly
                    rb2D.bodyType = RigidbodyType2D.Static;

                    // Enable the "Used by Composite" flag on the TilemapCollider2D
                    TilemapCollider2D tilemapCollider = tilemapObject.GetComponent<TilemapCollider2D>();
                    if (tilemapCollider != null)
                    {
                        tilemapCollider.usedByComposite = true;
                    }

                    // Save the changes back to the prefab
                    PrefabUtility.SaveAsPrefabAsset(prefabInstance, prefabFile);
                }
                else
                {
                    Debug.LogWarning($"Tilemap object not found in prefab: {Path.GetFileName(prefabFile)}");
                }
            }
            else
            {
                Debug.LogWarning($"Grid object not found in prefab: {Path.GetFileName(prefabFile)}");
            }

            // Unload the prefab to avoid memory leaks
            PrefabUtility.UnloadPrefabContents(prefabInstance);
        }

        Debug.Log("Components added to all prefabs in the folder.");
    }
}
