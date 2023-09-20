using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevel
{
    int LevelNumber {get;}
    bool IsLocked {get;}
    bool IsPassed {get;}
    void UnlockLevel();
    List<IPipe> GetAllPipes();
    List<IPipe> GetAllEndingPipes();
}
