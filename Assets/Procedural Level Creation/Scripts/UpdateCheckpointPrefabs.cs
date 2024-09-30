using UnityEditor;
using UnityEngine;
using System.IO;

public class UpdateCheckpointPrefabs : MonoBehaviour
{
    [MenuItem("Tools/Deactivate Exit Component and Set ChackPoint Tag to Win")]
    static void UpdateCheckpointPrefabsInFolder()
    {
        // Folder path where your prefabs are stored (relative to the Assets folder)
        string folderPath = "Assets/Procedural Level Creation/Prefabs/Layer 9"; // Change this to your folder's path

        // Find all prefab files in the folder
        string[] prefabFiles = Directory.GetFiles(folderPath, "*.prefab", SearchOption.AllDirectories);

        foreach (string prefabFile in prefabFiles)
        {
            // Load the prefab
            GameObject prefabInstance = PrefabUtility.LoadPrefabContents(prefabFile);

            // Find the "ChackPoint" object inside the prefab
            GameObject chackPointObject = prefabInstance.transform.Find("ChackPoint")?.gameObject;

            if (chackPointObject != null)
            {
                // Deactivate the "Exit" component under "ChackPoint"
                GameObject exitObject = chackPointObject.transform.Find("Exit")?.gameObject;

                if (exitObject != null)
                {
                    exitObject.SetActive(false); // Deactivating the Exit object
                }
                else
                {
                    Debug.LogWarning($"Exit object not found in prefab: {Path.GetFileName(prefabFile)}");
                }

                // Set the tag of "ChackPoint" to "Win"
                chackPointObject.tag = "Win";

                // Save the changes back to the prefab
                PrefabUtility.SaveAsPrefabAsset(prefabInstance, prefabFile);
            }
            else
            {
                Debug.LogWarning($"ChackPoint object not found in prefab: {Path.GetFileName(prefabFile)}");
            }

            // Unload the prefab to avoid memory leaks
            PrefabUtility.UnloadPrefabContents(prefabInstance);
        }

        Debug.Log("Updated all prefabs in the folder.");
    }
}
