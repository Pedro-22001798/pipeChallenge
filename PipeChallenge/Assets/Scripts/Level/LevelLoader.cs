using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    private LevelController levelController;

    public void StartGame(LevelController levelController)
    {
        this.levelController = levelController;
    }

    public void LoadNewLevel(int levelNumber)
    {
        
    }
}
