using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : IStage
{
    public int CurrentStage {get; private set;}
    public int MinStars {get; private set;}
    public int CurrentStars {get; private set;}
    public bool IsUnlocked {get; private set;}
    public List<LevelInformation> CurrentLevels {get; private set;}

    public Stage(int currentStage, List<LevelInformation> levels)
    {
        this.CurrentStage = currentStage;
        CurrentLevels = new List<LevelInformation>();
        this.CurrentLevels = levels;        
    }

    public void CheckIfCanUnlock(int currentPlayerStars)
    {
        if(!IsUnlocked)
        {
            if(currentPlayerStars >= MinStars)
            {
                UnlockStage();
            }
        }
    }

    private void UnlockStage()
    {
        IsUnlocked = true;
        // Make it visible
    }
}