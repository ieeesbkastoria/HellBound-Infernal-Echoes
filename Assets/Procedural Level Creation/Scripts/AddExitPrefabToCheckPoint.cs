using UnityEngine;
using UnityEditor;
using System.IO;

public class AddExitPrefabToCheckPoint : MonoBehaviour
{
    [MenuItem("Tools/Add Exit Prefab as Child to CheckPoint in Prefabs in Folder")]
    static void AddExitToCheckPointInPrefabs()
    {
        // Folder path where your prefabs are stored (relative to the Assets folder)
        string folderPath = "Assets/Procedural Level Creation/Prefabs/Layer 9"; // Change this to your folder's path
        
        // Path to the Exit prefab (relative to the Assets folder)
        string exitPrefabPath = "Assets/Procedural Level Creation/Prefabs/Exit.prefab"; // Change this to your Exit prefab path

        // Find all prefab files in the folder
        string[] prefabFiles = Directory.GetFiles(folderPath, "*.prefab", SearchOption.AllDirectories);

        // Loop through all prefab files
        foreach (string prefabFile in prefabFiles)
        {
            // Load the prefab
            GameObject prefabInstance = PrefabUtility.LoadPrefabContents(prefabFile);

            // Find the "CheckPoint" object inside the prefab
            GameObject checkPointObject = prefabInstance.transform.Find("ChackPoint")?.gameObject;

            if (checkPointObject != null)
            {
                // Load the Exit prefab
                GameObject exitPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(exitPrefabPath);

                if (exitPrefab != null)
                {
                    // Instantiate the Exit prefab and place it under the CheckPoint object
                    GameObject exitInstance = (GameObject)PrefabUtility.InstantiatePrefab(exitPrefab);

                    // Set the Exit prefab as a child of the CheckPoint
                    exitInstance.transform.SetParent(checkPointObject.transform, false);

                    // Set local position of the Exit prefab to (0, -1.3, 0)
                     exitInstance.transform.localPosition = new Vector3(0, -1.3f, 0);

                    // Save the changes back to the prefab
                    PrefabUtility.SaveAsPrefabAsset(prefabInstance, prefabFile);
                }
                else
                {
                    Debug.LogWarning($"Exit prefab not found at path: {exitPrefabPath}");
                }
            }
            else
            {
                Debug.LogWarning($"CheckPoint object not found in prefab: {Path.GetFileName(prefabFile)}");
            }

            // Unload the prefab to avoid memory leaks
            PrefabUtility.UnloadPrefabContents(prefabInstance);
        }

        Debug.Log("Exit prefab added to all prefabs with CheckPoint in the folder.");
    }
}
