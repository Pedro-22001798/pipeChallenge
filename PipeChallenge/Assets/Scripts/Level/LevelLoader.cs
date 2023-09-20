using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    private LevelController levelController;
    private FileDetection fileDetection;
    private FileReader fileReader;
    private AllLevels allLevels;
    public int CurrentLevel {get; private set;} = 1;
    List<string> allStringLevels;

    public void StartGame(LevelController levelController, FileDetection fileDetection, FileReader fileReader, AllLevels allLevels)
    {
        this.levelController = levelController;
        this.fileDetection = fileDetection;
        this.fileReader = fileReader;
        this.allLevels = allLevels;
        allStringLevels = new List<string>();
        allStringLevels = fileDetection.GetLevelFiles();
        LoadNewLevel(CurrentLevel-1);
    }

    public void LoadNewLevel(int levelNumber)
    {
        fileReader.ReadFile(allStringLevels[levelNumber], levelNumber);
    }
}
