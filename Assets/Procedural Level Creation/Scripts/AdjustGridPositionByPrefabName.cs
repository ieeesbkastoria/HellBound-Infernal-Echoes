using UnityEngine;
using UnityEditor;
using System.IO;

public class AdjustGridPositionByPrefabName : MonoBehaviour
{
    [MenuItem("Tools/Adjust Grid Position by Prefab Name")]
    static void AdjustGridPositionInPrefabs()
    {
        // Folder path where your prefabs are stored (relative to the Assets folder)
        string folderPath = "Assets/Procedural Level Creation/Prefabs/Layer 9"; // Change this to your folder's path
        
        // Find all prefab files in the folder
        string[] prefabFiles = Directory.GetFiles(folderPath, "*.prefab", SearchOption.AllDirectories);

        // Loop through all prefab files
        foreach (string prefabFile in prefabFiles)
        {
            // Load the prefab
            GameObject prefabInstance = PrefabUtility.LoadPrefabContents(prefabFile);

            if (prefabInstance != null)
            {
                // Find the "Grid" object inside the prefab
                GameObject gridObject = prefabInstance.transform.Find("Grid")?.gameObject;

                if (gridObject != null)
                {
                    // Get the prefab name without the file extension
                    string prefabName = Path.GetFileNameWithoutExtension(prefabFile);

                    // Determine new grid position based on the prefab name
                    Vector2 newPosition = GetNewGridPositionBasedOnName(prefabName);

                    // Apply the new position
                    gridObject.transform.localPosition = new Vector3(newPosition.x, newPosition.y, gridObject.transform.localPosition.z);

                    // Save the changes back to the prefab
                    PrefabUtility.SaveAsPrefabAsset(prefabInstance, prefabFile);

                    Debug.Log($"Adjusted Grid position in prefab: {prefabName} to {newPosition}");
                }
                else
                {
                    Debug.LogWarning($"Grid object not found in prefab: {Path.GetFileName(prefabFile)}");
                }

                // Unload the prefab to avoid memory leaks
                PrefabUtility.UnloadPrefabContents(prefabInstance);
            }
            else
            {
                Debug.LogWarning($"Failed to load prefab: {prefabFile}");
            }
        }

        Debug.Log("Grid positions adjusted in all prefabs in the folder.");
    }

    // Method to determine the new grid position based on the prefab name
    static Vector2 GetNewGridPositionBasedOnName(string prefabName)
    {
        if (prefabName.StartsWith("B"))
        {
            return new Vector2(-7, 7);
        }
        else if (prefabName.StartsWith("E") || prefabName.StartsWith("L") || prefabName.StartsWith("LR") || prefabName.StartsWith("TL"))
        {
            return new Vector2(-7, -7);
        }
        else if (prefabName.StartsWith("LB") || prefabName.StartsWith("TB"))
        {
            return new Vector2(-7, 7);
        }
        else if (prefabName.StartsWith("R") || prefabName.StartsWith("RB") || prefabName.StartsWith("TR"))
        {
            return new Vector2(7, 7);
        }
        else if (prefabName.StartsWith("T"))
        {
            return new Vector2(7, -7);
        }
        else
        {
            Debug.LogWarning($"No matching condition for prefab name: {prefabName}. Defaulting to (0,0).");
            return new Vector2(0, 0); // Default position if no conditions match
        }
    }
}

