using UnityEngine;
using UnityEditor;
using System.IO;

public class AdjustGridScaleInPrefabs : MonoBehaviour
{
    [MenuItem("Tools/Adjust Grid Scale in Prefabs in Folder")]
    static void AdjustGridScaleInPrefab()
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
                    // Modify the Transform scale of the Grid object
                    gridObject.transform.localScale = new Vector3(1.4f, 1.4f, gridObject.transform.localScale.z);

                    // Save the changes back to the prefab
                    PrefabUtility.SaveAsPrefabAsset(prefabInstance, prefabFile);

                    Debug.Log($"Adjusted scale of Grid in prefab: {Path.GetFileName(prefabFile)}");
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

        Debug.Log("Grid scale adjusted in all prefabs in the folder.");
    }
}

