using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    public static GameStateMachine Instance {get; private set;}
    public GameState CurrentGameState {get; private set;}

    private void Awake() 
    { 
        CurrentGameState = GameState.playing;
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public void ResumeGame()
    {
        if(CurrentGameState == GameState.paused)
        {
            CurrentGameState = GameState.playing;
        }
    }

    public void PauseGame()
    {
        if(CurrentGameState == GameState.playing)
        {
            CurrentGameState = GameState.paused;
        }
    }
}
