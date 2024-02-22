using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : ILevel
{
    public int LevelNumber {get; private set;}
    public int StageNumber {get; private set;}
    List<IPipe> allPipes = new List<IPipe>();
    public bool IsLocked {get; private set;}
    public bool IsPassed {get; private set;}
    public int Score {get; private set;}
    public int MaxMoves {get; private set;}
    public int UsedMoves {get; private set;}

    public Level(int levelNumber, int stageNumber, List<IPipe> allPipes, bool isPassed, bool isLocked)
    {
        this.LevelNumber = levelNumber;
        this.StageNumber = stageNumber;
        this.allPipes = allPipes;
        this.IsPassed = isPassed;
        this.IsLocked = isLocked;
    }

    public void LoadSavedLevel(int newScore, bool newLocked)
    {
        this.IsLocked = newLocked;
        this.Score = newScore;
        //Dar load dos usedmoves
        if(IsLocked)
        {
            IsPassed = false;
        }
    }

    public void UnlockLevel()
    {
        IsLocked = false;
    }

    public void PassLevel(int score)
    {
        if(!IsPassed)
            IsPassed = true;
        if(score > this.Score)
            this.Score = score;
        //Meter novo num de moves se for inferior
    }

    public List<IPipe> GetAllPipes()
    {
        return allPipes;
    }

    public List<IPipe> GetAllEndingPipes()
    {
        List<IPipe> endPipes = new List<IPipe>();
        foreach(IPipe p in allPipes)
        {
            if(p.TypeOfPipe == PipeType.end)
                endPipes.Add(p);
        }

        return endPipes;
    }
}
