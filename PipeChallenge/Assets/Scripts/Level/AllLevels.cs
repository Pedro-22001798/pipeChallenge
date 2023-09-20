using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLevels : MonoBehaviour
{
    List<ILevel> allLevels = new List<ILevel>();

    public void CreateLevel(ILevel newLevel)
    {
        allLevels.Add(newLevel);
    }

    public bool IsLevelLocked(int levelNumber)
    {
        return allLevels[levelNumber].IsLocked;
    }
}
