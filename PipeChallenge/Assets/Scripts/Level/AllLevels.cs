using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLevels : MonoBehaviour
{
    List<ILevel> allLevels = new List<ILevel>();
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private View view;
    private bool canPassLevel = true;

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
        if(canPassLevel)
        {
            if(!IsLevelLocked(levelLoader.CurrentLevel+1))
            {
                canPassLevel = false;
                view.LevelTransition();
                StartCoroutine(LoadAndChangeLevel(levelLoader.CurrentLevel+1));
            }
        }
    }

    public void PreviousLevel()
    {
        if(canPassLevel)
        {
            if(levelLoader.CurrentLevel > 0)
            {
                canPassLevel = false;
                view.LevelTransition();
                StartCoroutine(LoadAndChangeLevel(levelLoader.CurrentLevel-1));
            }
        }
    }

    public ILevel GetLevel(int numLevel)
    {
        return allLevels[numLevel];
    }

    private IEnumerator LoadAndChangeLevel(int level)
    {
        yield return new WaitForSeconds(0.3f);
        levelLoader.LoadNewLevel(level);
        levelLoader.ChangeLevel(level);  
        canPassLevel = true;      
    }
}
