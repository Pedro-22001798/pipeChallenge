using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    public static GameModeManager Instance { get; private set; }
    public GameMode CurrentGameMode {get; private set;}
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        CurrentGameMode = GameMode.None;
    }

    public bool ChangeCurrentGameMode(GameMode newGameMode)
    {
        if(newGameMode == GameMode.Normal)
        {
            if(CurrentGameMode == GameMode.Hardcore || CurrentGameMode == GameMode.Daily || CurrentGameMode == GameMode.None)
            {
                CurrentGameMode = GameMode.Normal;
                return true;
            }
        }
        else if(newGameMode == GameMode.Hardcore)
        {
            if(CurrentGameMode == GameMode.Normal || CurrentGameMode == GameMode.Daily || CurrentGameMode == GameMode.None)
            {
                CurrentGameMode = GameMode.Hardcore;
                return true;
            }
        }
        else if(newGameMode == GameMode.Daily)
        {
            if(CurrentGameMode == GameMode.Hardcore || CurrentGameMode == GameMode.Normal || CurrentGameMode == GameMode.None)
            {
                CurrentGameMode = GameMode.Daily;
                return true;
            }
        }
        else if(newGameMode == GameMode.None)
        {
            if(CurrentGameMode == GameMode.Hardcore || CurrentGameMode == GameMode.Normal || CurrentGameMode == GameMode.Daily)
            {
                CurrentGameMode = GameMode.None;
                return true;
            }
        }

        return false;
    }
}
