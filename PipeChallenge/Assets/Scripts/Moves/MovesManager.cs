using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesManager : MonoBehaviour
{
    public static MovesManager Instance {get; private set;}
    private LevelController levelController;
    private View view;
    private ILevel currentLevel;
    public int MaxMoves {get; private set;}
    public int CurrentMoves {get; private set;}

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
    }

    public void DefineProperties(LevelController levelController, View view)
    {
        this.levelController = levelController;
        this.view = view;
    }

    public void LoadLevel(ILevel level)
    {
        this.currentLevel = level;
        this.MaxMoves = currentLevel.MaxMoves;
        this.CurrentMoves = 0;
        view.UpdateMovesText(MaxMoves-CurrentMoves,MaxMoves);
    }

    public void AddMove()
    {
        this.CurrentMoves++;
        view.UpdateMovesText(MaxMoves-CurrentMoves,MaxMoves);
        ViewMoves.Instance.AddMove();
        if(CurrentMoves == MaxMoves)
        {
            levelController.ChangeMoveStatus(false);
        }
    }

    public bool HasMoreMoves()
    {
        if(CurrentMoves < MaxMoves)
        {
            return true;
        }
        
        return false;
    }
}
