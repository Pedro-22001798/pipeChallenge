using System.Collections.Generic;
using UnityEngine;

public class FileDetection : MonoBehaviour
{
    private string levelDirectoryName = "Levels";

    public List<string> GetLevelFiles()
    {
        List<string> levelFileContents = new List<string>();

        TextAsset[] assets = Resources.LoadAll<TextAsset>(levelDirectoryName);

        foreach (TextAsset asset in assets)
        {
            levelFileContents.Add(asset.text);
        }

        return levelFileContents;
    }
}
