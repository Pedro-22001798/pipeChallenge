using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : ILevel
{
    public int LevelNumber {get; private set;}
    List<IPipe> allPipes = new List<IPipe>();
    public bool IsLocked {get; private set;}

    public Level(int levelNumber, List<IPipe> allPipes)
    {
        this.LevelNumber = levelNumber;
        this.allPipes = allPipes;
    }

    public void UnlockLevel()
    {
        IsLocked = false;
    }
}
