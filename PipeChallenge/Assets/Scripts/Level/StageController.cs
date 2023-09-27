using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public int CurrentStage {get; private set;} = 1;
    [SerializeField] private AllLevels allLevels;
    List<ILevel> allGameLevels;

    public void LoadGame(List<ILevel> allLevels)
    {
        allGameLevels = new List<ILevel>();
        this.allGameLevels = allLevels;
    }

    public void LoadLevel(ILevel currentLevel)
    {
        CurrentStage = currentLevel.StageNumber;
    }

    public void ChangeStage(int newStage)
    {
        this.CurrentStage = newStage;
    }

    public List<ILevel> GetAllStageLevels(int stage)
    {
        List<ILevel> tempLevels = new List<ILevel>();
        foreach(ILevel level in allGameLevels)
        {
            if(level.StageNumber == stage)
            {
                tempLevels.Add(level);
            }
        }
        return tempLevels;
    }

    public bool IsThereStage(int stage)
    {
        if(stage == 0)
        {
            return false;
        }
        else
        {
            int numLevels = allGameLevels.Count;
            ILevel lastLevel = allGameLevels[numLevels-1];
            int maxStage = lastLevel.StageNumber;
            if(maxStage >= stage)
            {
                return true;
            }
            return false;
        }
    }
}
