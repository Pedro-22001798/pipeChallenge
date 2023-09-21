using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLevels : MonoBehaviour
{
    List<ILevel> allLevels = new List<ILevel>();
    [SerializeField] private LevelLoader levelLoader;

    public void CreateLevel(ILevel newLevel)
    {
        allLevels.Add(newLevel);
    }

    public bool IsLevelLocked(int levelNumber)
    {
        return allLevels[levelNumber].IsLocked;
    }

    public void NextLevel()
    {
        if(!IsLevelLocked(levelLoader.CurrentLevel+1))
        {
            levelLoader.LoadNewLevel(levelLoader.CurrentLevel+1);
            levelLoader.ChangeLevel(levelLoader.CurrentLevel+1);
        }
    }

    public void PreviousLevel()
    {
        if(levelLoader.CurrentLevel > 0)
        {
            levelLoader.LoadNewLevel(levelLoader.CurrentLevel-1);
            levelLoader.ChangeLevel(levelLoader.CurrentLevel-1);
        }
    }

    public ILevel GetLevel(int numLevel)
    {
        return allLevels[numLevel];
    }
}
