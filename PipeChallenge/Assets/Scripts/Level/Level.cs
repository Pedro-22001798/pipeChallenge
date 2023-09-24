using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : ILevel
{
    public int LevelNumber {get; private set;}
    List<IPipe> allPipes = new List<IPipe>();
    public bool IsLocked {get; private set;}
    public bool IsPassed {get; private set;}
    public int Score {get; private set;}

    public Level(int levelNumber, List<IPipe> allPipes, bool isPassed, bool isLocked)
    {
        this.LevelNumber = levelNumber;
        this.allPipes = allPipes;
        this.IsPassed = isPassed;
        this.IsLocked = isLocked;
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
