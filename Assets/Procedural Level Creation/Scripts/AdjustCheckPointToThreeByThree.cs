using UnityEngine;
using UnityEditor;
using System.IO;

public class AdjustCheckPointToThreeByThree : MonoBehaviour
{
    [MenuItem("Tools/Adjust ChackPoint to 3x3")]
    static void AdjustChackPointInPrefabs()
    {
        // Folder path where your prefabs are stored (relative to the Assets folder)
        string folderPath = "Assets/Procedural Level Creation/Prefabs/Layer 8"; // Change this to your folder's path
        
        // Find all prefab files in the folder
        string[] prefabFiles = Directory.GetFiles(folderPath, "*.prefab", SearchOption.AllDirectories);

        // Loop through all prefab files
        foreach (string prefabFile in prefabFiles)
        {
            // Load the prefab
            GameObject prefabInstance = PrefabUtility.LoadPrefabContents(prefabFile);

            if (prefabInstance != null)
            {
                // Find the "ChackPoint" object inside the prefab
                GameObject chackPointObject = prefabInstance.transform.Find("ChackPoint")?.gameObject;

                if (chackPointObject != null)
                {
                    // Retrieve the current position of ChackPoint
                    Vector3 oldPosition = chackPointObject.transform.localPosition;

                    // Calculate the new position based on the scaling factor
                    // In this case, we're keeping the scaling factor as a constant 1.4
                    float scaleFactor = 1.4f;
                    Vector3 newPosition = oldPosition * scaleFactor;

                    // Apply the new position
                    chackPointObject.transform.localPosition = newPosition;

                    // Set the size of the ChackPoint to exactly 3x3, keeping the original z-scale
                    Vector3 oldScale = chackPointObject.transform.localScale;
                    Vector3 newSize = new Vector3(3f, 3f, oldScale.z);

                    // Apply the new size
                    chackPointObject.transform.localScale = newSize;

                    // Save the changes back to the prefab
                    PrefabUtility.SaveAsPrefabAsset(prefabInstance, prefabFile);

                    Debug.Log($"Adjusted ChackPoint position and size to 3x3 in prefab: {Path.GetFileName(prefabFile)}");
                }
                else
                {
                    Debug.LogWarning($"ChackPoint object not found in prefab: {Path.GetFileName(prefabFile)}");
                }

                // Unload the prefab to avoid memory leaks
                PrefabUtility.UnloadPrefabContents(prefabInstance);
            }
            else
            {
                Debug.LogWarning($"Failed to load prefab: {prefabFile}");
            }
        }

        Debug.Log("ChackPoint positions and sizes adjusted to 3x3 in all prefabs in the folder.");
    }
}


