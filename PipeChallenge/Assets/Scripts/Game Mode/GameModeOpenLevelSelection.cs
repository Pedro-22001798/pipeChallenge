using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeOpenLevelSelection : MonoBehaviour
{
    [SerializeField] private GameObject normalLevelSelection, hardCoreLevelSelection, dailyLevelSelection;
    public void EnterNormalGameMode()
    {
        GameModeManager.Instance.ChangeCurrentGameMode(GameMode.Normal);
    }

    public void EnterHardCoreGameMode()
    {
        GameModeManager.Instance.ChangeCurrentGameMode(GameMode.Hardcore);
    }

    public void EnterDailyGameMode()
    {
        GameModeManager.Instance.ChangeCurrentGameMode(GameMode.Daily);
    }

    public void LeaveCurrentGameMode()
    {
        GameMode currentGameMode = GameModeManager.Instance.CurrentGameMode;
        
        switch(currentGameMode)
        {
            case GameMode.Normal:
                normalLevelSelection.SetActive(false);
                break;
            case GameMode.Hardcore:
                hardCoreLevelSelection.SetActive(false);
                break;
            case GameMode.Daily:
                dailyLevelSelection.SetActive(false);
                break;
        }

        GameModeManager.Instance.ChangeCurrentGameMode(GameMode.None);
    }
}
