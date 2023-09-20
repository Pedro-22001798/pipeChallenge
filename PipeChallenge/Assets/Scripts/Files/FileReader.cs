using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileReader : MonoBehaviour
{
    public void ReadFile(string file)
    {
        if (File.Exists(file))
        {
            string[] lines = File.ReadAllLines(file);

            for (int row = 0; row < lines.Length; row++)
            {
                string[] cells = lines[row].Split(',');

                for (int col = 0; col < cells.Length; col += 2)
                {
                    string pipeType = cells[col];
                    float rotation = float.Parse(cells[col + 1]);
                    
                }
            }

        }
    }

    // PipeType GetPipePrefabByType(string type)
    // {
    //     // Implement logic to return the appropriate prefab based on the type.
    //     // You'll need to set up these mappings in the Unity Editor.
    //     foreach (GameObject prefab in pipePrefabs)
    //     {
    //         if (prefab.name.ToLower() == type.ToLower())
    //         {
    //             return prefab;
    //         }
    //     }
    //     return null;
    // }
}
