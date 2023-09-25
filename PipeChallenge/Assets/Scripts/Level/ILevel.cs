using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevel
{
    void LoadSavedLevel(int newScore, bool newLocked);
    int LevelNumber {get;}
    bool IsLocked {get;}
    bool IsPassed {get;}
    int Score {get;}
    void PassLevel(int score);
    void UnlockLevel();
    List<IPipe> GetAllPipes();
    List<IPipe> GetAllEndingPipes();
}
