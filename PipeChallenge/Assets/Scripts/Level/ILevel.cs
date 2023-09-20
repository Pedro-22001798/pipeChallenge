using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevel
{
    int LevelNumber {get;}
    bool IsLocked {get;}
    void UnlockLevel();
}
