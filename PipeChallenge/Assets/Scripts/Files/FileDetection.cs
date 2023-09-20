using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileDetection : MonoBehaviour
{
    private string levelDirectoryPath = "Assets/Levels";

    public List<string> GetLevelFiles()
    {
        List<string> levelFiles = new List<string>();

        // Check if the specified directory exists.
        if (Directory.Exists(levelDirectoryPath))
        {
            // Get all files with the ".pipes" extension in the directory.
            string[] files = Directory.GetFiles(levelDirectoryPath, "*.pipes");

            // Add each level file to the list.
            foreach (string file in files)
            {
                levelFiles.Add(file);
            }
        }
        else
        {
            Debug.LogError("Level directory not found: " + levelDirectoryPath);
        }

        return levelFiles;
    }
}
